using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class TICostcalTableremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TICostCalculation",
                schema: "cost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TICostCalculation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssociatedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssociatedCost_Reduction = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CostBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOptimization_OptionalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_TICostCalculation_CostSummaryStructure_CostSummaryId",
                        column: x => x.CostSummaryId,
                        principalSchema: "cost",
                        principalTable: "CostSummaryStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculation_CostSummaryId",
                schema: "cost",
                table: "TICostCalculation",
                column: "CostSummaryId");

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
    }
}
