using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class addutccostcountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TargetUnitTechnicalCost",
                schema: "prj",
                table: "ProjectRevisions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UtcCountry",
                schema: "prj",
                table: "ProjectRevisions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetUnitTechnicalCost",
                schema: "prj",
                table: "ProjectRevisions");

            migrationBuilder.DropColumn(
                name: "UtcCountry",
                schema: "prj",
                table: "ProjectRevisions");
        }
    }
}
