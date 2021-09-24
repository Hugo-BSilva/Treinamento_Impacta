using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMercado.Migrations
{
    public partial class DataTypeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATA_NASCIMENTO",
                table: "TB_USUARIO",
                newName: "Data_Nascimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data_Nascimento",
                table: "TB_USUARIO",
                newName: "DATA_NASCIMENTO");
        }
    }
}
