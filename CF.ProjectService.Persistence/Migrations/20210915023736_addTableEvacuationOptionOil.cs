using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class addTableEvacuationOptionOil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvacuationOptionOil",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BSW = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    H2S = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NameFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VapourPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PressuresValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PressuresUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InfrastructureDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistanceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DistanceUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvacuationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBaseConcept = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvacuationOptionOil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionOil_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionOil_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionOil_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionOil_InfrastructureDatas_InfrastructureDataId",
                        column: x => x.InfrastructureDataId,
                        principalSchema: "prj",
                        principalTable: "InfrastructureDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionOil_CreatedByUserId",
                schema: "prj",
                table: "EvacuationOptionOil",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionOil_DeletedByUserId",
                schema: "prj",
                table: "EvacuationOptionOil",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionOil_InfrastructureDataId",
                schema: "prj",
                table: "EvacuationOptionOil",
                column: "InfrastructureDataId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionOil_ModifiedByUserId",
                schema: "prj",
                table: "EvacuationOptionOil",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvacuationOptionOil",
                schema: "prj");
        }
    }
}
