﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class AddLiquidPressureCurveSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiquidPressureCurveSetting",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    Size = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LiquidPressureCurveSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiquidPressureCurveSetting_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiquidPressureCurveSetting_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiquidPressureCurveSetting_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiquidPressureCurveSetting_CreatedByUserId",
                schema: "concept",
                table: "LiquidPressureCurveSetting",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidPressureCurveSetting_DeletedByUserId",
                schema: "concept",
                table: "LiquidPressureCurveSetting",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidPressureCurveSetting_ModifiedByUserId",
                schema: "concept",
                table: "LiquidPressureCurveSetting",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiquidPressureCurveSetting",
                schema: "concept");
        }
    }
}
