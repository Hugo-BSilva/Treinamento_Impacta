using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEF.Migrations
{
    public partial class TBPedido_TBProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    ID_PRODUTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_PRODUTO = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    PRECO_PRODUTO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATA_VALIDADE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TIPO_PRODUTO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.ID_PRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_PEDIDO",
                columns: table => new
                {
                    ID_PEDIDO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PRODUTO_PEDIDO = table.Column<int>(type: "int", nullable: false),
                    VALOR_PEDIDO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATA_COMPRA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESCRICAO_PEDIDO = table.Column<string>(type: "VARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PEDIDO", x => x.ID_PEDIDO);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDO_TB_PRODUTO_ID_PRODUTO_PEDIDO",
                        column: x => x.ID_PRODUTO_PEDIDO,
                        principalTable: "TB_PRODUTO",
                        principalColumn: "ID_PRODUTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_ID_PRODUTO_PEDIDO",
                table: "TB_PEDIDO",
                column: "ID_PRODUTO_PEDIDO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PEDIDO");

            migrationBuilder.DropTable(
                name: "TB_PRODUTO");
        }
    }
}
