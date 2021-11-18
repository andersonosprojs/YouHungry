using YouHungry.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(table => table.Id);

            builder.Property(table => table.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(table => table.Nome)
                .HasMaxLength(100)
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

            builder.HasData(
                new Usuario(1, "email1@teste.com", "Usuario 1", "32070080","Rua Teste 1, 123", "Contagem", "123456"),
                new Usuario(2, "email2@teste.com", "Usuario 2", "32070081", "Rua Teste 2, 234", "Belo Horizonte", "234567"),
                new Usuario(3, "email3@teste.com", "Usuario 3", "32070082", "Rua Teste 2, 345", "Betim", "345678")
                );
        }
    }
}
