using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class addGasCoolingGasDhydration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GasCoolingSetting",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    TempratureDiffMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempratureDiffMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true,defaultValue:"Temprature Difference value"),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false,defaultValue:false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasCoolingSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasCoolingSetting_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GasCoolingSetting_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GasCoolingSetting_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GasDhydrationSetting",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    GasExportSpecMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GasExportSpecMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true,defaultValue:"Water Content or Gas Export Specification"),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false,defaultValue:false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasDhydrationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasDhydrationSetting_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GasDhydrationSetting_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GasDhydrationSetting_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "concept",
                table: "EquipmentMaster",
                keyColumn: "Id",
                keyValue: new Guid("05b435fd-c0f1-4168-94ce-c4f99821cfe8"),
                column: "LevelType",
                value: "Input:No of gas injection wells, 1:Pipe Rating");

            migrationBuilder.CreateIndex(
                name: "IX_GasCoolingSetting_CreatedByUserId",
                schema: "concept",
                table: "GasCoolingSetting",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GasCoolingSetting_DeletedByUserId",
                schema: "concept",
                table: "GasCoolingSetting",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GasCoolingSetting_ModifiedByUserId",
                schema: "concept",
                table: "GasCoolingSetting",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GasDhydrationSetting_CreatedByUserId",
                schema: "concept",
                table: "GasDhydrationSetting",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GasDhydrationSetting_DeletedByUserId",
                schema: "concept",
                table: "GasDhydrationSetting",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GasDhydrationSetting_ModifiedByUserId",
                schema: "concept",
                table: "GasDhydrationSetting",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasCoolingSetting",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "GasDhydrationSetting",
                schema: "concept");

            migrationBuilder.UpdateData(
                schema: "concept",
                table: "EquipmentMaster",
                keyColumn: "Id",
                keyValue: new Guid("05b435fd-c0f1-4168-94ce-c4f99821cfe8"),
                column: "LevelType",
                value: "1");
        }
    }
}
