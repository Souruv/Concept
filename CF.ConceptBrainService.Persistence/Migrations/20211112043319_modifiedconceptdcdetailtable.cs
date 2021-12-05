using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class modifiedconceptdcdetailtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DryWeight",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "WbsIdsCombined",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DryWeight",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "WbsIdsCombined",
                schema: "concept",
                table: "ConceptsDCDetails");
        }
    }
}
