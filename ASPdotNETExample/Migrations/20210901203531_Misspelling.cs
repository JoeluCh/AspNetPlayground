using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPdotNETExample.Migrations
{
    public partial class Misspelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseData",
                table: "Movie",
                newName: "ReleaseDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Movie",
                newName: "ReleaseData");
        }
    }
}
