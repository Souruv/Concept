using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class Code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "cost",
                table: "EquipmentCost",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "cost",
                table: "EquipmentCost",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCost_CountryCode",
                schema: "cost",
                table: "EquipmentCost",
                column: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_Country_CountryCode",
                schema: "cost",
                table: "EquipmentCost",
                column: "CountryCode",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_Country_CountryCode",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentCost_CountryCode",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "cost",
                table: "EquipmentCost",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCost_Country",
                schema: "cost",
                table: "EquipmentCost",
                column: "Country");
        }
    }
}
