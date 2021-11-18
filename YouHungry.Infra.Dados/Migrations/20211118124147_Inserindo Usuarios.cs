using Microsoft.EntityFrameworkCore.Migrations;

namespace YouHungry.Infra.Dados.Migrations
{
    public partial class InserindoUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cep", "Cidade", "Email", "Endereco", "Nome", "Senha" },
                values: new object[] { 1L, "32070080", "Contagem", "email1@teste.com", "Rua Teste 1, 123", "Usuario 1", "123456" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cep", "Cidade", "Email", "Endereco", "Nome", "Senha" },
                values: new object[] { 2L, "32070081", "Belo Horizonte", "email2@teste.com", "Rua Teste 2, 234", "Usuario 2", "234567" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cep", "Cidade", "Email", "Endereco", "Nome", "Senha" },
                values: new object[] { 3L, "32070082", "Betim", "email3@teste.com", "Rua Teste 2, 345", "Usuario 3", "345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
