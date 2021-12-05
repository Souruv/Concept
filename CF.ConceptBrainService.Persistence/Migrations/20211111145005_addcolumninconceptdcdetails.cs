using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class addcolumninconceptdcdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvacuationScheme",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessingScheme",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvacuationScheme",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "ProcessingScheme",
                schema: "concept",
                table: "ConceptsDCDetails");
        }
    }
}
