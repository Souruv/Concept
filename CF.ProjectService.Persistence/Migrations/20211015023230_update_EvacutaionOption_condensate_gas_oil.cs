using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class update_EvacutaionOption_condensate_gas_oil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PressuresValue",
                schema: "prj",
                table: "EvacuationOptionOil",
                newName: "PressuresRatedValue");

            migrationBuilder.RenameColumn(
                name: "PressuresUnit",
                schema: "prj",
                table: "EvacuationOptionOil",
                newName: "PressuresRatedUnit");

            migrationBuilder.RenameColumn(
                name: "PressuresValue",
                schema: "prj",
                table: "EvacuationOptionGas",
                newName: "PressuresRatedValue");

            migrationBuilder.RenameColumn(
                name: "PressuresUnit",
                schema: "prj",
                table: "EvacuationOptionGas",
                newName: "PressuresRatedUnit");

            migrationBuilder.RenameColumn(
                name: "PressuresValue",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                newName: "PressuresRatedValue");

            migrationBuilder.RenameColumn(
                name: "PressuresUnit",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                newName: "PressuresRatedUnit");

            migrationBuilder.AddColumn<string>(
                name: "PressuresOperatingUnit",
                schema: "prj",
                table: "EvacuationOptionOil",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PressuresOperatingValue",
                schema: "prj",
                table: "EvacuationOptionOil",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PressuresOperatingUnit",
                schema: "prj",
                table: "EvacuationOptionGas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PressuresOperatingValue",
                schema: "prj",
                table: "EvacuationOptionGas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PressuresOperatingUnit",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PressuresOperatingValue",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PressuresOperatingUnit",
                schema: "prj",
                table: "EvacuationOptionOil");

            migrationBuilder.DropColumn(
                name: "PressuresOperatingValue",
                schema: "prj",
                table: "EvacuationOptionOil");

            migrationBuilder.DropColumn(
                name: "PressuresOperatingUnit",
                schema: "prj",
                table: "EvacuationOptionGas");

            migrationBuilder.DropColumn(
                name: "PressuresOperatingValue",
                schema: "prj",
                table: "EvacuationOptionGas");

            migrationBuilder.DropColumn(
                name: "PressuresOperatingUnit",
                schema: "prj",
                table: "EvacuationOptionCondensate");

            migrationBuilder.DropColumn(
                name: "PressuresOperatingValue",
                schema: "prj",
                table: "EvacuationOptionCondensate");

            migrationBuilder.RenameColumn(
                name: "PressuresRatedValue",
                schema: "prj",
                table: "EvacuationOptionOil",
                newName: "PressuresValue");

            migrationBuilder.RenameColumn(
                name: "PressuresRatedUnit",
                schema: "prj",
                table: "EvacuationOptionOil",
                newName: "PressuresUnit");

            migrationBuilder.RenameColumn(
                name: "PressuresRatedValue",
                schema: "prj",
                table: "EvacuationOptionGas",
                newName: "PressuresValue");

            migrationBuilder.RenameColumn(
                name: "PressuresRatedUnit",
                schema: "prj",
                table: "EvacuationOptionGas",
                newName: "PressuresUnit");

            migrationBuilder.RenameColumn(
                name: "PressuresRatedValue",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                newName: "PressuresValue");

            migrationBuilder.RenameColumn(
                name: "PressuresRatedUnit",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                newName: "PressuresUnit");
        }
    }
}
