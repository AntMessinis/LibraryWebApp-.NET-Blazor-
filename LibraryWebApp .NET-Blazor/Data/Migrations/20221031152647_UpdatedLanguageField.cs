using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdatedLanguageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LanuageName",
                table: "Languages",
                newName: "LanguageName");

            migrationBuilder.RenameIndex(
                name: "IX_Languages_LanuageName",
                table: "Languages",
                newName: "IX_Languages_LanguageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LanguageName",
                table: "Languages",
                newName: "LanuageName");

            migrationBuilder.RenameIndex(
                name: "IX_Languages_LanguageName",
                table: "Languages",
                newName: "IX_Languages_LanuageName");
        }
    }
}
