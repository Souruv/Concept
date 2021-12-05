using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class ConceptGenerationtables_modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DCName",
                schema: "concept",
                table: "ConceptsDCDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DCName",
                schema: "concept",
                table: "ConceptsDCDetails");
        }
    }
}
