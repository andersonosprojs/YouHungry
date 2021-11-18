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
                new Usuario(1, "admin@admin.com", "Usuario Administrador", "99999999","Endereco Administrador", "Cidade", "@dmin")
                );
        }
    }
}
