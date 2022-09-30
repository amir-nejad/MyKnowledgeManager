using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyKnowledgeManager.Infrastructure.Migrations
{
    public partial class ojweifweo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTrashItem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTrashItem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonwledgeLevel = table.Column<int>(type: "int", nullable: false),
                    KnowledgeImportance = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTrashItem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knowledges_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeTagsRelation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KnowledgeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KnowledgeTagId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTrashItem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeTagsRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnowledgeTagsRelation_Knowledges_KnowledgeId",
                        column: x => x.KnowledgeId,
                        principalTable: "Knowledges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnowledgeTagsRelation_KnowledgeTags_KnowledgeTagId",
                        column: x => x.KnowledgeTagId,
                        principalTable: "KnowledgeTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_ApplicationUserId",
                table: "Knowledges",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeTagsRelation_KnowledgeId",
                table: "KnowledgeTagsRelation",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeTagsRelation_KnowledgeTagId",
                table: "KnowledgeTagsRelation",
                column: "KnowledgeTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnowledgeTagsRelation");

            migrationBuilder.DropTable(
                name: "Knowledges");

            migrationBuilder.DropTable(
                name: "KnowledgeTags");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
