using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMercado.Migrations
{
    public partial class AddSenhaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SENHA",
                table: "TB_USUARIO",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SENHA",
                table: "TB_USUARIO");
        }
    }
}
