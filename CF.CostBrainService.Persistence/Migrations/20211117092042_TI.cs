using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class TI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "cost",
                table: "GeneralSettingsValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "cost",
                table: "GeneralSettingsValues",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TICostCalculation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContratorPMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InstallationEngineering = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransportationSpread = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MWB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Others = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BreakdownGrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BreakdownUSDEquivalent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MOB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DMOB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Installation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssociatedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalOptimizationCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdditionalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    USDEquivalent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICostCalculation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TICostCalculation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TICostCalculation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TICostCalculation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculation_CreatedByUserId",
                schema: "cost",
                table: "TICostCalculation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculation_DeletedByUserId",
                schema: "cost",
                table: "TICostCalculation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculation_ModifiedByUserId",
                schema: "cost",
                table: "TICostCalculation",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TICostCalculation",
                schema: "cost");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "cost",
                table: "GeneralSettingsValues",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                schema: "cost",
                table: "GeneralSettingsValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
