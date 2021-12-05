using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class altertableequipmentmasterandlookipgenweight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinPipeRating",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                newName: "MinCriteriaValue");

            migrationBuilder.RenameColumn(
                name: "MaxPipeRating",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                newName: "MaxCriteriaValue");

            migrationBuilder.AddColumn<string>(
                name: "Criteria",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CriteriaType",
                schema: "concept",
                table: "EquipmentMaster",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Criteria",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropColumn(
                name: "CriteriaType",
                schema: "concept",
                table: "EquipmentMaster");

            migrationBuilder.RenameColumn(
                name: "MinCriteriaValue",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                newName: "MinPipeRating");

            migrationBuilder.RenameColumn(
                name: "MaxCriteriaValue",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                newName: "MaxPipeRating");
        }
    }
}
