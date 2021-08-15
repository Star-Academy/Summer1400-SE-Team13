using Microsoft.EntityFrameworkCore.Migrations;

namespace Search.Migrations
{
    public partial class InvertedIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Content = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Content);
                });

            migrationBuilder.CreateTable(
                name: "RelationTable",
                columns: table => new
                {
                    DocsName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WordsContent = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTable", x => new { x.DocsName, x.WordsContent });
                    table.ForeignKey(
                        name: "FK_RelationTable_Docs_DocsName",
                        column: x => x.DocsName,
                        principalTable: "Docs",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelationTable_Words_WordsContent",
                        column: x => x.WordsContent,
                        principalTable: "Words",
                        principalColumn: "Content",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelationTable_WordsContent",
                table: "RelationTable",
                column: "WordsContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelationTable");

            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
