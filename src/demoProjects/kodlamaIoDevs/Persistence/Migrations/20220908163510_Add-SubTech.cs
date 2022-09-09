using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddSubTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubTech",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTech", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTech_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SubTech",
                columns: new[] { "Id", "ImageUrl", "Name", "ProgrammingLanguageId" },
                values: new object[,]
                {
                    { 1, "", "WPF", 1 },
                    { 2, "", "ASP.NET", 1 },
                    { 3, "", "Spring", 2 },
                    { 4, "", "JSP", 2 },
                    { 5, "", "Vue", 6 },
                    { 6, "", "React", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTech_ProgrammingLanguageId",
                table: "SubTech",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTech");
        }
    }
}
