using Bergle.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bergle.Data
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=bergle;Pooling=true;")
                .UseSnakeCaseNamingConvention();
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Leitor> Leitores { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
