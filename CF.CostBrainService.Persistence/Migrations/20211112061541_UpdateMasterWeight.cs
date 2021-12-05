using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class UpdateMasterWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterWeight",
                keyColumn: "Id",
                keyValue: new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f"),
                columns: new[] { "MinWeight", "Weight" },
                values: new object[] { 2501, "2501 and above" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterWeight",
                keyColumn: "Id",
                keyValue: new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f"),
                columns: new[] { "MinWeight", "Weight" },
                values: new object[] { 2500, "2500 and above" });
        }
    }
}
