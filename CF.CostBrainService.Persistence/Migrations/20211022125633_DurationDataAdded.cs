using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class DurationDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("13892e5d-c7b5-4c67-86c6-b4b71f9ec12b"),
                column: "Duration",
                value: 19m);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("1b3f2b69-2e35-4525-b620-bde0cde45184"),
                column: "Duration",
                value: 370m);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("3381dd1b-e7e1-4cf0-9140-a493acecc7d6"),
                column: "Duration",
                value: 3m);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("49748d93-5d39-46a8-bf8a-8fd48345bfbf"),
                column: "Duration",
                value: 178m);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("87dfc484-a578-4a43-ac68-c73ae47bf74b"),
                column: "Duration",
                value: 214m);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("c41cdc85-c587-47a7-a199-41ed7e7afd49"),
                column: "Duration",
                value: 223m);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("c68688f1-1216-4041-b514-ff2c342d2a6d"),
                column: "Duration",
                value: 342m);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("e8108adc-7267-4494-88aa-11d760eb1f86"),
                column: "Duration",
                value: 261m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("13892e5d-c7b5-4c67-86c6-b4b71f9ec12b"),
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("1b3f2b69-2e35-4525-b620-bde0cde45184"),
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("3381dd1b-e7e1-4cf0-9140-a493acecc7d6"),
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("49748d93-5d39-46a8-bf8a-8fd48345bfbf"),
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("87dfc484-a578-4a43-ac68-c73ae47bf74b"),
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("c41cdc85-c587-47a7-a199-41ed7e7afd49"),
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("c68688f1-1216-4041-b514-ff2c342d2a6d"),
                column: "Duration",
                value: null);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "InstallationDetails",
                keyColumn: "Id",
                keyValue: new Guid("e8108adc-7267-4494-88aa-11d760eb1f86"),
                column: "Duration",
                value: null);
        }
    }
}
