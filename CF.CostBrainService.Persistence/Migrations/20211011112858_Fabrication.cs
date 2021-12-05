using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class Fabrication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabrication",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManhoursPerMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Manhours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CountryCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Fabrication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fabrication_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fabrication_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fabrication_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fabrication_Country_CountryCode",
                        column: x => x.CountryCode,
                        principalSchema: "cost",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fabrication_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "cost",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fabrication_CountryCode",
                schema: "cost",
                table: "Fabrication",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrication_CreatedByUserId",
                schema: "cost",
                table: "Fabrication",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrication_DeletedByUserId",
                schema: "cost",
                table: "Fabrication",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrication_EquipmentId",
                schema: "cost",
                table: "Fabrication",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrication_ModifiedByUserId",
                schema: "cost",
                table: "Fabrication",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fabrication",
                schema: "cost");
        }
    }
}
