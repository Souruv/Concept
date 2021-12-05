using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class AddFlowrateLimitInDesalting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlowRateLimit",
                schema: "concept",
                table: "OilDesaltingSetting",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowRateLimit",
                schema: "concept",
                table: "OilDesaltingSetting");
        }
    }
}
