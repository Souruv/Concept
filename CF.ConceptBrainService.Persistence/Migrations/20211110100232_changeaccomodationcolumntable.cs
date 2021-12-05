using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class changeaccomodationcolumntable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accomodation",
                schema: "concept",
                table: "Concepts");

            migrationBuilder.AddColumn<string>(
                name: "Accomodation",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accomodation",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.AddColumn<string>(
                name: "Accomodation",
                schema: "concept",
                table: "Concepts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
