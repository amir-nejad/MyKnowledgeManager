using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyKnowledgeManager.Infrastructure.Migrations
{
    public partial class woifjoeiwfjowejf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_ApplicationUsers_UserId",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeTagsRelation_Knowledges_KnowledgeId",
                table: "KnowledgeTagsRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Knowledges",
                table: "Knowledges");

            migrationBuilder.RenameTable(
                name: "Knowledges",
                newName: "Knowledge");

            migrationBuilder.RenameIndex(
                name: "IX_Knowledges_UserId",
                table: "Knowledge",
                newName: "IX_Knowledge_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Knowledge",
                table: "Knowledge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledge_ApplicationUsers_UserId",
                table: "Knowledge",
                column: "UserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeTagsRelation_Knowledge_KnowledgeId",
                table: "KnowledgeTagsRelation",
                column: "KnowledgeId",
                principalTable: "Knowledge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knowledge_ApplicationUsers_UserId",
                table: "Knowledge");

            migrationBuilder.DropForeignKey(
                name: "FK_KnowledgeTagsRelation_Knowledge_KnowledgeId",
                table: "KnowledgeTagsRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Knowledge",
                table: "Knowledge");

            migrationBuilder.RenameTable(
                name: "Knowledge",
                newName: "Knowledges");

            migrationBuilder.RenameIndex(
                name: "IX_Knowledge_UserId",
                table: "Knowledges",
                newName: "IX_Knowledges_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Knowledges",
                table: "Knowledges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_ApplicationUsers_UserId",
                table: "Knowledges",
                column: "UserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnowledgeTagsRelation_Knowledges_KnowledgeId",
                table: "KnowledgeTagsRelation",
                column: "KnowledgeId",
                principalTable: "Knowledges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
