using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class addtableEvacuationOptionProducedWater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvacuationOptionProducedWater",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OilInWater = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_EvacuationOptionProducedWater", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionProducedWater_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionProducedWater_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionProducedWater_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationOptionProducedWater_InfrastructureDatas_InfrastructureDataId",
                        column: x => x.InfrastructureDataId,
                        principalSchema: "prj",
                        principalTable: "InfrastructureDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionProducedWater_CreatedByUserId",
                schema: "prj",
                table: "EvacuationOptionProducedWater",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionProducedWater_DeletedByUserId",
                schema: "prj",
                table: "EvacuationOptionProducedWater",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionProducedWater_InfrastructureDataId",
                schema: "prj",
                table: "EvacuationOptionProducedWater",
                column: "InfrastructureDataId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOptionProducedWater_ModifiedByUserId",
                schema: "prj",
                table: "EvacuationOptionProducedWater",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvacuationOptionProducedWater",
                schema: "prj");
        }
    }
}
