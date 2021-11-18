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

            //builder.HasData(
            //    new Restaurante(1, "12345678901234", "Restaurante 1", "Cozinha Mineira", "32070080", "Rua Teste 1", "Contagem", "123456"),
            //    new Restaurante(2, "11111111111111", "Restaurante 2", "Cozinha Japonesa", "32070081", "Rua Teste 2, 234", "Belo Horizonte", "234567"),
            //    new Restaurante(3, "22222222222222", "Restaurante 3", "Cozinha Mexicana", "32070082", "Rua Teste 3, 345", "Betim", "345678")
            //    );
        }
    }
}
