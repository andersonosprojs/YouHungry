using YouHungry.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class AcompanhamentoConfiguracao : IEntityTypeConfiguration<Acompanhamento>
    {
        public void Configure(EntityTypeBuilder<Acompanhamento> builder)
        {
            builder.HasKey(table => table.Id);

            builder.Property(table => table.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(
                new Acompanhamento(1, "Arroz"),
                new Acompanhamento(2, "Feijão"),
                new Acompanhamento(3, "Ovo frito"),
                new Acompanhamento(4, "Farofa"),
                new Acompanhamento(5, "Purê")
                );
        }
    }
}
