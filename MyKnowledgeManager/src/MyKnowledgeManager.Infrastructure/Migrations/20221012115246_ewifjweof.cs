using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyKnowledgeManager.Infrastructure.Migrations
{
    public partial class ewifjweof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "KnowledgeTags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeTags_TagName",
                table: "KnowledgeTags",
                column: "TagName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KnowledgeTags_TagName",
                table: "KnowledgeTags");

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "KnowledgeTags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
