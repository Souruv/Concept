using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class addedconceptdcdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GasInj",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GasProd",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OilProd",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WaterInj",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GasInj",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "GasProd",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "OilProd",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "WaterInj",
                schema: "concept",
                table: "ConceptsDCDetails");
        }
    }
}
