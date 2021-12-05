using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class CostCalculation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AppUser_CreatedByUserId",
                schema: "cost",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AppUser_DeletedByUserId",
                schema: "cost",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AppUser_ModifiedByUserId",
                schema: "cost",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AppUser_CreatedByUserId",
                schema: "cost",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AppUser_DeletedByUserId",
                schema: "cost",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AppUser_ModifiedByUserId",
                schema: "cost",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_AppUser_CreatedByUserId",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_AppUser_DeletedByUserId",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_AppUser_ModifiedByUserId",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                schema: "cost",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                schema: "cost",
                newName: "AppUsers",
                newSchema: "cost");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_ModifiedByUserId",
                schema: "cost",
                table: "AppUsers",
                newName: "IX_AppUsers_ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_DeletedByUserId",
                schema: "cost",
                table: "AppUsers",
                newName: "IX_AppUsers_DeletedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_CreatedByUserId",
                schema: "cost",
                table: "AppUsers",
                newName: "IX_AppUsers_CreatedByUserId");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "cost",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                schema: "cost",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CostCalculation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CostType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCalculation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostCalculation_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "cost",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculation_EquipmentId",
                schema: "cost",
                table: "CostCalculation",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "AppUsers",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "AppUsers",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "AppUsers",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropTable(
                name: "CostCalculation",
                schema: "cost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                schema: "cost",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "cost",
                table: "Equipment");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                schema: "cost",
                newName: "AppUser",
                newSchema: "cost");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "AppUser",
                newName: "IX_AppUser_ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "AppUser",
                newName: "IX_AppUser_DeletedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "AppUser",
                newName: "IX_AppUser_CreatedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                schema: "cost",
                table: "AppUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AppUser_CreatedByUserId",
                schema: "cost",
                table: "AppUser",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AppUser_DeletedByUserId",
                schema: "cost",
                table: "AppUser",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AppUser_ModifiedByUserId",
                schema: "cost",
                table: "AppUser",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AppUser_CreatedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AppUser_DeletedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AppUser_ModifiedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_AppUser_CreatedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_AppUser_DeletedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_AppUser_ModifiedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
