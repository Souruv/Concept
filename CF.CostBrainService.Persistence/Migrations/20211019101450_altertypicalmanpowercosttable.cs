using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class altertypicalmanpowercosttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysFactorperMonthId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropColumn(
                name: "FormulaId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                schema: "cost",
                table: "TypicalManpowerCost");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                schema: "cost",
                table: "TypicalManpowerCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DaysFactorperMonthId",
                schema: "cost",
                table: "TypicalManpowerCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormulaId",
                schema: "cost",
                table: "TypicalManpowerCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                schema: "cost",
                table: "TypicalManpowerCost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                schema: "cost",
                table: "TypicalManpowerCost",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
