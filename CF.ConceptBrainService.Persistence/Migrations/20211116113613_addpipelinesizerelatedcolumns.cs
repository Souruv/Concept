using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class addpipelinesizerelatedcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CondensateProcessingPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExternalWaterInjectionPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GasCondensateProcessingPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GasDisposalPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GasExportProcessPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GasInjectionPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OilProcessingPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PWTInjectionPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WaterDisposalPipeLineSize",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CondensateProcessingPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "ExternalWaterInjectionPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "GasCondensateProcessingPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "GasDisposalPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "GasExportProcessPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "GasInjectionPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "OilProcessingPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "PWTInjectionPipelineSize",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "WaterDisposalPipeLineSize",
                schema: "concept",
                table: "ConceptsDCDetails");
        }
    }
}
