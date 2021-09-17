using Microsoft.EntityFrameworkCore.Migrations;

namespace MaosAObra.Migrations
{
    public partial class UpdateUserBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "TB_BLOG");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_BLOG",
                newName: "DSC_BLOG");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "TB_BLOG",
                newName: "ID_USER_BLOG");

            migrationBuilder.RenameColumn(
                name: "CreatedTimeStamp",
                table: "TB_BLOG",
                newName: "DT_CREATED");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_BLOG",
                newName: "ID_BLOG");

            migrationBuilder.AlterColumn<string>(
                name: "DSC_BLOG",
                table: "TB_BLOG",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_BLOG",
                table: "TB_BLOG",
                column: "ID_BLOG");

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

            migrationBuilder.CreateIndex(
                name: "IX_TB_BLOG_ID_USER_BLOG",
                table: "TB_BLOG",
                column: "ID_USER_BLOG");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_BLOG_TB_USER_ID_USER_BLOG",
                table: "TB_BLOG",
                column: "ID_USER_BLOG",
                principalTable: "TB_USER",
                principalColumn: "ID_USER",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_BLOG_TB_USER_ID_USER_BLOG",
                table: "TB_BLOG");

            migrationBuilder.DropTable(
                name: "TB_USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_BLOG",
                table: "TB_BLOG");

            migrationBuilder.DropIndex(
                name: "IX_TB_BLOG_ID_USER_BLOG",
                table: "TB_BLOG");

            migrationBuilder.RenameTable(
                name: "TB_BLOG",
                newName: "Blog");

            migrationBuilder.RenameColumn(
                name: "ID_USER_BLOG",
                table: "Blog",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "DT_CREATED",
                table: "Blog",
                newName: "CreatedTimeStamp");

            migrationBuilder.RenameColumn(
                name: "DSC_BLOG",
                table: "Blog",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ID_BLOG",
                table: "Blog",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");
        }
    }
}
