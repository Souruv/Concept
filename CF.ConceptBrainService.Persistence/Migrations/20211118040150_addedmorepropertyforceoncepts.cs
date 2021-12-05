using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class addedmorepropertyforceoncepts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PipelineRating",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBaseConcept",
                schema: "concept",
                table: "Concepts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PipelineRating",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropColumn(
                name: "IsBaseConcept",
                schema: "concept",
                table: "Concepts");
        }
    }
}
