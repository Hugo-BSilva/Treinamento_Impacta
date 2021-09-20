using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteEF.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DSC_USER = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "TB_BLOG",
                columns: table => new
                {
                    ID_BLOG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER_BLOG = table.Column<int>(type: "int", nullable: false),
                    DSC_BLOG = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    DT_CREATED = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BLOG", x => x.ID_BLOG);
                    table.ForeignKey(
                        name: "FK_TB_BLOG_TB_USER_ID_USER_BLOG",
                        column: x => x.ID_USER_BLOG,
                        principalTable: "TB_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_BLOG_ID_USER_BLOG",
                table: "TB_BLOG",
                column: "ID_USER_BLOG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_BLOG");

            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
