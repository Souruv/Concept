using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class addTableEvacuationOptionCondensate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvacuationOptionCondensate",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BSW = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    H2S = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NameFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<int>(type: "int", nullable: true),
                    VapourPressure = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_EvacuationOptionCondensate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionCondensate_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionCondensate_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionCondensate_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionCondensate_InfrastructureDatas_InfrastructureDataId",
                        column: x => x.InfrastructureDataId,
                        principalSchema: "prj",
                        principalTable: "InfrastructureDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionCondensate_CreatedByUserId",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionCondensate_DeletedByUserId",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionCondensate_InfrastructureDataId",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                column: "InfrastructureDataId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionCondensate_ModifiedByUserId",
                schema: "prj",
                table: "EvacuationOptionCondensate",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvacuationOptionCondensate",
                schema: "prj");
        }
    }
}
