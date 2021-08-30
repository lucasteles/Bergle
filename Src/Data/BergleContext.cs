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
            // Livro
            modelBuilder.Entity<Livro>().HasKey(l => l.Id);
            modelBuilder.Entity<Livro>().Property(l => l.Titulo).IsRequired();
            modelBuilder.Entity<Livro>().Property(l => l.Ano).IsRequired();

            modelBuilder.Entity<Livro>(l => l
                .HasCheckConstraint("o_ano_deve_estar_dentro_do_range", $"ano >= {Livro.AnoMin} AND ano <= {Livro.AnoMax}")
                .HasCheckConstraint("a_edicao_deve_ser_um_inteiro_positivo", "edicao >= 0")
            );

            // Autor
            modelBuilder.Entity<Autor>().HasKey(x => x.Id);
            modelBuilder.Entity<Autor>().Property(x => x.Nome).IsRequired();

            // Leitor
            modelBuilder.Entity<Leitor>().HasKey(x => x.Id);
            modelBuilder.Entity<Leitor>().Property(x => x.Nome).IsRequired();

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
            modelBuilder.Entity<Editora>().HasKey(x => x.Id);
            modelBuilder.Entity<Editora>().Property(x => x.Nome).IsRequired();

            // Relacionamento One-to-Many entre Editora e Livro
            modelBuilder.Entity<Editora>()
                .HasMany<Livro>(e => e.Publicacoes)
                .WithOne(l => l.Editora);

            // Biografia
            modelBuilder.Entity<Biografia>().ToTable("biografias");
            modelBuilder.Entity<Biografia>().HasKey(x => x.AutorId);
            modelBuilder.Entity<Biografia>().Property(x => x.Descricao).IsRequired();

            // Relacionamento One-to-One entre Autor e Biografia
            modelBuilder.Entity<Autor>()
                .HasOne(a => a.Biografia)
                .WithOne(b => b.Autor)
                .HasForeignKey<Biografia>(b => b.AutorId);
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Leitor> Leitores { get; set; }
    }
}
