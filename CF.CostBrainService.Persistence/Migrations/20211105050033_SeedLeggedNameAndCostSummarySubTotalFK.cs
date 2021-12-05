using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class SeedLeggedNameAndCostSummarySubTotalFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostSummarySubTotal_CostSummaryStructure_CostSummaryId",
                schema: "cost",
                table: "CostSummarySubTotal");

            migrationBuilder.DropIndex(
                name: "IX_CostSummarySubTotal_CostSummaryId",
                schema: "cost",
                table: "CostSummarySubTotal");

            migrationBuilder.DropColumn(
                name: "CostSummaryId",
                schema: "cost",
                table: "CostSummarySubTotal");

            migrationBuilder.AddColumn<Guid>(
                name: "ConceptId",
                schema: "cost",
                table: "CostSummarySubTotal",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterInstallation",
                keyColumn: "Id",
                keyValue: new Guid("a6ff30eb-47be-4fa8-8f7f-d2215b24bd79"),
                column: "InstallationName",
                value: "3 Legged Jacket");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterInstallation",
                keyColumn: "Id",
                keyValue: new Guid("ccbf5380-21e0-48f0-bf39-1db0df739420"),
                column: "InstallationName",
                value: "4 Legged Jacket");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterInstallation",
                keyColumn: "Id",
                keyValue: new Guid("eb983470-e461-4bb5-a632-39f093ce464b"),
                column: "InstallationName",
                value: "8 Legged Jacket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConceptId",
                schema: "cost",
                table: "CostSummarySubTotal");

            migrationBuilder.AddColumn<Guid>(
                name: "CostSummaryId",
                schema: "cost",
                table: "CostSummarySubTotal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterInstallation",
                keyColumn: "Id",
                keyValue: new Guid("a6ff30eb-47be-4fa8-8f7f-d2215b24bd79"),
                column: "InstallationName",
                value: "3 Legged Jacket Pile Installation");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterInstallation",
                keyColumn: "Id",
                keyValue: new Guid("ccbf5380-21e0-48f0-bf39-1db0df739420"),
                column: "InstallationName",
                value: "4 Legged Jacket Pile Installation");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterInstallation",
                keyColumn: "Id",
                keyValue: new Guid("eb983470-e461-4bb5-a632-39f093ce464b"),
                column: "InstallationName",
                value: "8 Legged Jacket Pile Installation");

            migrationBuilder.CreateIndex(
                name: "IX_CostSummarySubTotal_CostSummaryId",
                schema: "cost",
                table: "CostSummarySubTotal",
                column: "CostSummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostSummarySubTotal_CostSummaryStructure_CostSummaryId",
                schema: "cost",
                table: "CostSummarySubTotal",
                column: "CostSummaryId",
                principalSchema: "cost",
                principalTable: "CostSummaryStructure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
