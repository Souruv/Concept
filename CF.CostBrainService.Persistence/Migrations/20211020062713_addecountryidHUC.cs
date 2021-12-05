using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class addecountryidHUC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "TypicalManpowerCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterTypicalManpowerId",
                schema: "cost",
                table: "TypicalManpowerCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "MaterialsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "MarineSpreadCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "HUCSummaryCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "FuelAndPWCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_CountryId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_MasterTypicalManpowerId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterTypicalManpowerId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsCost_CountryId",
                schema: "cost",
                table: "MaterialsCost",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_CountryId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_HUCSummaryCost_CountryId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_CountryId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToolsConsCost_CountryId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentToolsConsCost_Country_CountryId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelAndPWCost_Country_CountryId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HUCSummaryCost_Country_CountryId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarineSpreadCost_Country_CountryId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsCost_Country_CountryId",
                schema: "cost",
                table: "MaterialsCost",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdPartyServicesSectionThreeCost_Country_CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdPartyServicesSectionTwoCost_Country_CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalManpowerCost_Country_CountryId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalManpowerCost_MasterTypicalManpower_MasterTypicalManpowerId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterTypicalManpowerId",
                principalSchema: "cost",
                principalTable: "MasterTypicalManpower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentToolsConsCost_Country_CountryId",
                schema: "cost",
                table: "EquipmentToolsConsCost");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelAndPWCost_Country_CountryId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropForeignKey(
                name: "FK_HUCSummaryCost_Country_CountryId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropForeignKey(
                name: "FK_MarineSpreadCost_Country_CountryId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsCost_Country_CountryId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirdPartyServicesSectionThreeCost_Country_CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirdPartyServicesSectionTwoCost_Country_CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalManpowerCost_Country_CountryId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropForeignKey(
                name: "FK_TypicalManpowerCost_MasterTypicalManpower_MasterTypicalManpowerId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropIndex(
                name: "IX_TypicalManpowerCost_CountryId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropIndex(
                name: "IX_TypicalManpowerCost_MasterTypicalManpowerId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropIndex(
                name: "IX_MaterialsCost_CountryId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropIndex(
                name: "IX_MarineSpreadCost_CountryId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropIndex(
                name: "IX_HUCSummaryCost_CountryId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropIndex(
                name: "IX_FuelAndPWCost_CountryId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentToolsConsCost_CountryId",
                schema: "cost",
                table: "EquipmentToolsConsCost");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropColumn(
                name: "MasterTypicalManpowerId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "EquipmentToolsConsCost");
        }
    }
}
