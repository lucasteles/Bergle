using Bergle.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bergle.Data.Configuracoes
{
    public class LivroConfiguracao : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Titulo).IsRequired();
            builder.Property(l => l.Ano).IsRequired().HasColumnType("smallint");
            builder.Property(l => l.Edicao).HasDefaultValue(null).HasColumnType("smallint");
            builder.Property(l => l.Capa).HasDefaultValue(null).HasColumnType("smallint");
        }
    }
}