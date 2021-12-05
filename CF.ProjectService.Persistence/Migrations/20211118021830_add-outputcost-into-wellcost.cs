using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class addoutputcostintowellcost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "P50OutputCost",
                schema: "prj",
                table: "WellCosts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "P80OutputCost",
                schema: "prj",
                table: "WellCosts",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P50OutputCost",
                schema: "prj",
                table: "WellCosts");

            migrationBuilder.DropColumn(
                name: "P80OutputCost",
                schema: "prj",
                table: "WellCosts");
        }
    }
}
