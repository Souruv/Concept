using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class initdbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_Equipment_Id",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCost_EquipmentId",
                schema: "cost",
                table: "EquipmentCost",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_Equipment_EquipmentId",
                schema: "cost",
                table: "EquipmentCost",
                column: "EquipmentId",
                principalSchema: "cost",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_Equipment_EquipmentId",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentCost_EquipmentId",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_Equipment_Id",
                schema: "cost",
                table: "EquipmentCost",
                column: "Id",
                principalSchema: "cost",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
