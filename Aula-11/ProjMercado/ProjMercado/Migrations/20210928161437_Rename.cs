using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMercado.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_VENDA_TB_USUARIO_ID_USUARIO",
                table: "TB_VENDA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_VENDA_ITEM_TB_PRODUTO_ID_PRODUTO",
                table: "TB_VENDA_ITEM");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_VENDA_ITEM_TB_VENDA_ID_VENDA",
                table: "TB_VENDA_ITEM");

            migrationBuilder.RenameColumn(
                name: "ID_USUARIO",
                table: "TB_VENDA",
                newName: "ID_USUARIO_VENDA");

            migrationBuilder.RenameIndex(
                name: "IX_TB_VENDA_ID_USUARIO",
                table: "TB_VENDA",
                newName: "IX_TB_VENDA_ID_USUARIO_VENDA");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_VENDA_TB_USUARIO_ID_USUARIO_VENDA",
                table: "TB_VENDA",
                column: "ID_USUARIO_VENDA",
                principalTable: "TB_USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_VENDA_ITEM_TB_PRODUTO_ID_PRODUTO",
                table: "TB_VENDA_ITEM",
                column: "ID_PRODUTO",
                principalTable: "TB_PRODUTO",
                principalColumn: "ID_PRODUTO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_VENDA_ITEM_TB_VENDA_ID_VENDA",
                table: "TB_VENDA_ITEM",
                column: "ID_VENDA",
                principalTable: "TB_VENDA",
                principalColumn: "ID_VENDA",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_VENDA_TB_USUARIO_ID_USUARIO_VENDA",
                table: "TB_VENDA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_VENDA_ITEM_TB_PRODUTO_ID_PRODUTO",
                table: "TB_VENDA_ITEM");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_VENDA_ITEM_TB_VENDA_ID_VENDA",
                table: "TB_VENDA_ITEM");

            migrationBuilder.RenameColumn(
                name: "ID_USUARIO_VENDA",
                table: "TB_VENDA",
                newName: "ID_USUARIO");

            migrationBuilder.RenameIndex(
                name: "IX_TB_VENDA_ID_USUARIO_VENDA",
                table: "TB_VENDA",
                newName: "IX_TB_VENDA_ID_USUARIO");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_VENDA_TB_USUARIO_ID_USUARIO",
                table: "TB_VENDA",
                column: "ID_USUARIO",
                principalTable: "TB_USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_VENDA_ITEM_TB_PRODUTO_ID_PRODUTO",
                table: "TB_VENDA_ITEM",
                column: "ID_PRODUTO",
                principalTable: "TB_PRODUTO",
                principalColumn: "ID_PRODUTO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_VENDA_ITEM_TB_VENDA_ID_VENDA",
                table: "TB_VENDA_ITEM",
                column: "ID_VENDA",
                principalTable: "TB_VENDA",
                principalColumn: "ID_VENDA",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
