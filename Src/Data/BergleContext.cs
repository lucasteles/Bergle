using System.Collections.Generic;
using Bergle.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bergle.Data
{
    public class BergleContext : DbContext
    {
        public BergleContext(DbContextOptions<BergleContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bergle");

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            // Livro
            /*
            var livro = modelBuilder.Entity<Livro>();
            livro.HasKey(l => l.Id);
            livro.Property(l => l.Titulo).IsRequired();
            livro.Property(l => l.Ano).IsRequired().HasColumnType("smallint");
            livro.Property(l => l.Edicao).HasDefaultValue(null).HasColumnType("smallint");
            livro.Property(l => l.Capa).HasDefaultValue(null).HasColumnType("smallint");
            */

            modelBuilder.Entity<Livro>(l => l
                .HasCheckConstraint("o_ano_deve_estar_dentro_do_range", $"ano >= {Livro.AnoMin} AND ano <= {Livro.AnoMax}")
                .HasCheckConstraint("a_edicao_deve_ser_um_inteiro_positivo", "edicao > 0")
            );

            // Autor
            modelBuilder.Entity<Autor>().HasKey(a => a.Id);
            modelBuilder.Entity<Autor>().Property(a => a.Nome).IsRequired();

            // Leitor
            modelBuilder.Entity<Leitor>().HasKey(l => l.Id);
            modelBuilder.Entity<Leitor>().Property(l => l.Nome).IsRequired();



            // Relacionamento Many-to-Many entre Livro e Autor
            modelBuilder.Entity<Livro>()
                .HasMany<Autor>(l => l.Autores)
                .WithMany(a => a.Obras)
                .UsingEntity<Dictionary<string, object>>(
                    joinEntityName: "Bibliografias",
                    configureRight: b => b.HasOne<Autor>().WithMany().HasForeignKey("AutorId"),
                    configureLeft: b => b.HasOne<Livro>().WithMany().HasForeignKey("ObraId")
            );

            // Relacionamento Many-to-Many entre Livro e Leitor
            modelBuilder.Entity<Livro>()
                .HasMany<Leitor>(l => l.Leitores)
                .WithMany(l => l.Estante)
                .UsingEntity<Dictionary<string, object>>(
                    joinEntityName: "Estantes",
                    configureRight: b => b.HasOne<Leitor>().WithMany().HasForeignKey("LeitorId"),
                    configureLeft: b => b.HasOne<Livro>().WithMany().HasForeignKey("LivroId")
            );



            // Editora
            modelBuilder.Entity<Editora>().ToTable("editoras");
            modelBuilder.Entity<Editora>().HasKey(e => e.Id);
            modelBuilder.Entity<Editora>().Property(e => e.Nome).IsRequired();

            // Relacionamento One-to-Many entre Editora e Livro
            modelBuilder.Entity<Editora>()
                .HasMany<Livro>(e => e.Publicacoes)
                .WithOne(l => l.Editora);



            // Biografia
            modelBuilder.Entity<Biografia>().ToTable("biografias");
            modelBuilder.Entity<Biografia>().HasKey(b => b.AutorId);
            modelBuilder.Entity<Biografia>().Property(b => b.Descricao).IsRequired();
            modelBuilder.Entity<Biografia>().Property(b => b.Falecimento).HasDefaultValue(null);

            // Relacionamento One-to-One entre Autor e Biografia
            modelBuilder.Entity<Autor>()
                .HasOne(a => a.Biografia)
                .WithOne(b => b.Autor)
                .HasForeignKey<Biografia>(b => b.AutorId);



            // Categoria
            modelBuilder.Entity<Categoria>().ToTable("categorias");
            modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
            modelBuilder.Entity<Categoria>().Property(c => c.Nome).IsRequired();

            // Relacionamento Many-to-Many entre Livro e Categoria
            modelBuilder.Entity<Livro>()
                .HasMany<Categoria>(l => l.Categorias)
                .WithMany(c => c.Livros)
                .UsingEntity<Dictionary<string, object>>(
                    joinEntityName: "Categorizacoes",
                    configureRight: b => b.HasOne<Categoria>().WithMany().HasForeignKey("CategoriaId"),
                    configureLeft: b => b.HasOne<Livro>().WithMany().HasForeignKey("LivroId")
            );



            // Subcategoria
            modelBuilder.Entity<Subcategoria>().ToTable("subcategorias");
            modelBuilder.Entity<Subcategoria>().HasKey(s => s.Id);
            modelBuilder.Entity<Subcategoria>().Property(s => s.Nome).IsRequired();

            // Relacionamento Many-to-Many entre Livro e Subcategoria
            modelBuilder.Entity<Livro>()
                .HasMany<Subcategoria>(l => l.Subcategorias)
                .WithMany(s => s.Livros)
                .UsingEntity<Dictionary<string, object>>(
                    joinEntityName: "Subcategorizacoes",
                    configureRight: b => b.HasOne<Subcategoria>().WithMany().HasForeignKey("SubcategoriaId"),
                    configureLeft: b => b.HasOne<Livro>().WithMany().HasForeignKey("LivroId")
            );

            // Relacionamento One-to-Many entre Leitor e Subcategoria
            modelBuilder.Entity<Leitor>()
                .HasMany<Subcategoria>(l => l.Subcategorias)
                .WithOne(s => s.Criador);



            // Review
            modelBuilder.Entity<Review>().HasKey(r => r.Id);
            modelBuilder.Entity<Review>().Property(r => r.Titulo).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Descricao).IsRequired();
            modelBuilder.Entity<Review>().Property(r => r.Avaliacao).HasColumnType("smallint");

            modelBuilder.Entity<Review>(r => r
                .HasCheckConstraint("a_avaliacao_deve_estar_dentro_do_range", $"avaliacao >= 1 AND avaliacao <= 5")
            );

            // Relacionamento One-to-Many entre Leitor e Review 
            modelBuilder.Entity<Leitor>()
                .HasMany<Review>(l => l.Reviews)
                .WithOne(r => r.Reviewer);

            // Relacionamento One-to-Many entre Livro e Review 
            modelBuilder.Entity<Livro>()
                .HasMany<Review>(l => l.Reviews)
                .WithOne(r => r.Livro);

            // Relacionamento Many-to-Many entre Leitor e Review
            modelBuilder.Entity<Leitor>()
                .HasMany<Review>(l => l.Apoios)
                .WithMany(r => r.Apoiadores)
                .UsingEntity<Dictionary<string, object>>(
                    joinEntityName: "Apoiamentos",
                    configureRight: b => b.HasOne<Review>().WithMany().HasForeignKey("ReviewId"),
                    configureLeft: b => b.HasOne<Leitor>().WithMany().HasForeignKey("ApoiadorId")
            );



            // Clube
            modelBuilder.Entity<Clube>().ToTable("clubes");
            modelBuilder.Entity<Clube>().HasKey(c => c.Id);
            modelBuilder.Entity<Clube>().Property(c => c.Nome).IsRequired();
            modelBuilder.Entity<Clube>().Property(c => c.Descricao).IsRequired();

            // Relacionamento Many-to-Many entre Clube e Leitor
            modelBuilder.Entity<Clube>()
                .HasMany<Leitor>(c => c.Membros)
                .WithMany(l => l.Clubes)
                .UsingEntity<Dictionary<string, object>>(
                    joinEntityName: "Membros",
                    configureRight: b => b.HasOne<Leitor>().WithMany().HasForeignKey("LeitorId"),
                    configureLeft: b => b.HasOne<Clube>().WithMany().HasForeignKey("ClubeId")
            );
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Biografia> Biografias { get; set; }

        public DbSet<Leitor> Leitores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Subcategoria> Subcategorias { get; set; }

        public DbSet<Editora> Editoras { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Clube> Clubes { get; set; }
    }
}
