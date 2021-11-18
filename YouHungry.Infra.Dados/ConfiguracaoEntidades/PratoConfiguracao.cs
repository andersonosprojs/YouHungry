using YouHungry.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class PratoConfiguracao : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.HasKey(table => table.Id);

            builder.Property(table => table.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(table => table.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(table => table.Preco)
                .IsRequired();

            builder.Property(table => table.TempoPreparo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(table => table.Imagem)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
