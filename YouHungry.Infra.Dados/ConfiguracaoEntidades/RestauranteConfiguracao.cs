using YouHungry.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class RestauranteConfiguracao : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.HasKey(table => table.Id);

            builder.Property(table => table.Cnpj)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(table => table.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(table => table.Especialidade)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(table => table.Cep)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(table => table.Endereco)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(table => table.Cidade)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(table => table.Senha)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
