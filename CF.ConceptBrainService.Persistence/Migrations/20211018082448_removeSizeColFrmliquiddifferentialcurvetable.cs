using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class removeSizeColFrmliquiddifferentialcurvetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                schema: "concept",
                table: "LiquidPressureDifferentialCurveSetting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                schema: "concept",
                table: "LiquidPressureDifferentialCurveSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
