using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class MasterWeightAndTtlDurationChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxWeight",
                schema: "cost",
                table: "MasterWeight",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinWeight",
                schema: "cost",
                table: "MasterWeight",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDuration_Days",
                schema: "cost",
                table: "CostSummaryStructure",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterWeight",
                keyColumn: "Id",
                keyValue: new Guid("5b8fa167-e802-4eee-9af8-47b0def1cf5c"),
                columns: new[] { "MaxWeight", "MinWeight" },
                values: new object[] { 1000, 501 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterWeight",
                keyColumn: "Id",
                keyValue: new Guid("6213bcf9-a424-4d10-942a-266cd825dc02"),
                columns: new[] { "MaxWeight", "MinWeight" },
                values: new object[] { 500, 0 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterWeight",
                keyColumn: "Id",
                keyValue: new Guid("6f191103-e823-45a6-951a-3362dad331e5"),
                columns: new[] { "MaxWeight", "MinWeight" },
                values: new object[] { 2500, 2001 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterWeight",
                keyColumn: "Id",
                keyValue: new Guid("8d2b0e8c-beed-40ec-bf0d-7b40dd2781b3"),
                columns: new[] { "MaxWeight", "MinWeight" },
                values: new object[] { 1500, 1001 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterWeight",
                keyColumn: "Id",
                keyValue: new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f"),
                column: "MinWeight",
                value: 2500);

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "MasterWeight",
                keyColumn: "Id",
                keyValue: new Guid("f6c025ce-0927-4f2a-b8a5-9b8e10bf36a2"),
                columns: new[] { "MaxWeight", "MinWeight" },
                values: new object[] { 2000, 1501 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxWeight",
                schema: "cost",
                table: "MasterWeight");

            migrationBuilder.DropColumn(
                name: "MinWeight",
                schema: "cost",
                table: "MasterWeight");

            migrationBuilder.AlterColumn<int>(
                name: "TotalDuration_Days",
                schema: "cost",
                table: "CostSummaryStructure",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
