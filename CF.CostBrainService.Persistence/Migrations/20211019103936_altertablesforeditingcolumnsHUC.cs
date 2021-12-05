using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class altertablesforeditingcolumnsHUC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost");

            migrationBuilder.DropColumn(
                name: "FormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost");

            migrationBuilder.DropColumn(
                name: "FormulaId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "cost",
                table: "MaterialsCost");

            migrationBuilder.DropColumn(
                name: "FormulaId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropColumn(
                name: "SubScheduleId",
                schema: "cost",
                table: "MarineSpreadCost");

            migrationBuilder.DropColumn(
                name: "FormulaId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "cost",
                table: "HUCSummaryCost");

            migrationBuilder.DropColumn(
                name: "FormulaId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropColumn(
                name: "SubScheduleId",
                schema: "cost",
                table: "FuelAndPWCost");

            migrationBuilder.DropColumn(
                name: "FormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "cost",
                table: "EquipmentToolsConsCost");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "cost",
                table: "EquipmentToolsConsCost");

            migrationBuilder.RenameColumn(
                name: "Cost",
                schema: "cost",
                table: "HUCSummaryCost",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "Cost",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                newName: "TotalCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCost",
                schema: "cost",
                table: "HUCSummaryCost",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                newName: "Cost");

            migrationBuilder.AddColumn<Guid>(
                name: "FormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormulaId",
                schema: "cost",
                table: "MaterialsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                schema: "cost",
                table: "MaterialsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "cost",
                table: "MaterialsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormulaId",
                schema: "cost",
                table: "MarineSpreadCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                schema: "cost",
                table: "MarineSpreadCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "cost",
                table: "MarineSpreadCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubScheduleId",
                schema: "cost",
                table: "MarineSpreadCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormulaId",
                schema: "cost",
                table: "HUCSummaryCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                schema: "cost",
                table: "HUCSummaryCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "cost",
                table: "HUCSummaryCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormulaId",
                schema: "cost",
                table: "FuelAndPWCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                schema: "cost",
                table: "FuelAndPWCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "cost",
                table: "FuelAndPWCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubScheduleId",
                schema: "cost",
                table: "FuelAndPWCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
