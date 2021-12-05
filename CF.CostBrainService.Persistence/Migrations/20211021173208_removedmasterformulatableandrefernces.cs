using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class removedmasterformulatableandrefernces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentToolsConsCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelAndPWCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropForeignKey(
                name: "FK_HUCSummaryCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropForeignKey(
                name: "FK_MarineSpreadCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirdPartyServicesSectionThreeCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirdPartyServicesSectionTwoCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalManpowerCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropTable(
                name: "MasterHUCFormula",
                schema: "cost");

            migrationBuilder.DropIndex(
                name: "IX_TypicalManpowerCost_MasterHUCFormulaId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropIndex(
                name: "IX_MaterialsCost_MasterHUCFormulaId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropIndex(
                name: "IX_MarineSpreadCost_MasterHUCFormulaId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropIndex(
                name: "IX_HUCSummaryCost_MasterHUCFormulaId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropIndex(
                name: "IX_FuelAndPWCost_MasterHUCFormulaId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentToolsConsCost_MasterHUCFormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost");

            migrationBuilder.DropColumn(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropColumn(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropColumn(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropColumn(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropColumn(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropColumn(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropColumn(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropColumn(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "TypicalManpowerCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "MaterialsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "MarineSpreadCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "HUCSummaryCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "FuelAndPWCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterHUCFormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MasterHUCFormula",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterHUCFormula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterHUCFormula_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterHUCFormula_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterHUCFormula_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_MasterHUCFormulaId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsCost_MasterHUCFormulaId",
                schema: "cost",
                table: "MaterialsCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_MasterHUCFormulaId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_HUCSummaryCost_MasterHUCFormulaId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_MasterHUCFormulaId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToolsConsCost_MasterHUCFormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterHUCFormula_CreatedByUserId",
                schema: "cost",
                table: "MasterHUCFormula",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterHUCFormula_DeletedByUserId",
                schema: "cost",
                table: "MasterHUCFormula",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterHUCFormula_ModifiedByUserId",
                schema: "cost",
                table: "MasterHUCFormula",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentToolsConsCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "MasterHUCFormulaId",
                principalSchema: "cost",
                principalTable: "MasterHUCFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelAndPWCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "MasterHUCFormulaId",
                principalSchema: "cost",
                principalTable: "MasterHUCFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HUCSummaryCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "MasterHUCFormulaId",
                principalSchema: "cost",
                principalTable: "MasterHUCFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarineSpreadCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "MasterHUCFormulaId",
                principalSchema: "cost",
                principalTable: "MasterHUCFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "MaterialsCost",
                column: "MasterHUCFormulaId",
                principalSchema: "cost",
                principalTable: "MasterHUCFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdPartyServicesSectionThreeCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "MasterHUCFormulaId",
                principalSchema: "cost",
                principalTable: "MasterHUCFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdPartyServicesSectionTwoCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "MasterHUCFormulaId",
                principalSchema: "cost",
                principalTable: "MasterHUCFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalManpowerCost_MasterHUCFormula_MasterHUCFormulaId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterHUCFormulaId",
                principalSchema: "cost",
                principalTable: "MasterHUCFormula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
