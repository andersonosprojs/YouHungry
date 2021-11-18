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

            //builder.HasData(
            //    new Prato(1, "Tropeiro", "Tropeiro com torresmo e ovo", 20.00, "30 min", @"c:\imagens\tropeiro1.jpg"),
            //    new Prato(1, "Sushi", "Sushi bruto", 60.00, "40 min", @"c:\imagens\sushi1.jpg"),
            //    new Prato(1, "Esfirra", "Esfirra igual do habbibs", 10.00, "15 min", @"c:\imagens\esfirra1.jpg")
            //    );
        }
    }
}
