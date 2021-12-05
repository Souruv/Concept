using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class changeWeightEstimateNametolookupgenericweightestimate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeightEstimate",
                schema: "concept");

            migrationBuilder.CreateTable(
                name: "Lookupgenericweightestimate",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    MinPipeRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxPipeRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Lookupgenericweightestimate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookupgenericweightestimate_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lookupgenericweightestimate_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lookupgenericweightestimate_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lookupgenericweightestimate_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "concept",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lookupgenericweightestimate_CreatedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookupgenericweightestimate_DeletedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookupgenericweightestimate_EquipmentId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookupgenericweightestimate_ModifiedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lookupgenericweightestimate",
                schema: "concept");

            migrationBuilder.CreateTable(
                name: "WeightEstimate",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PipeRating = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightEstimate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightEstimate_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeightEstimate_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeightEstimate_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeightEstimate_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "concept",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeightEstimate_CreatedByUserId",
                schema: "concept",
                table: "WeightEstimate",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightEstimate_DeletedByUserId",
                schema: "concept",
                table: "WeightEstimate",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightEstimate_EquipmentId",
                schema: "concept",
                table: "WeightEstimate",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightEstimate_ModifiedByUserId",
                schema: "concept",
                table: "WeightEstimate",
                column: "ModifiedByUserId");
        }
    }
}
