using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class oildhydrationdesalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FlowlineType",
                schema: "concept",
                table: "FlowlineBoundary",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OilDesaltingSetting",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    GravityMin = table.Column<int>(type: "int", nullable: false),
                    GravityMax = table.Column<int>(type: "int", nullable: false),
                    GravityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_OilDesaltingSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilDesaltingSetting_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OilDesaltingSetting_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OilDesaltingSetting_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OilDhydrationSetting",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    GravityMin = table.Column<int>(type: "int", nullable: false),
                    GravityMax = table.Column<int>(type: "int", nullable: false),
                    GravityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_OilDhydrationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilDhydrationSetting_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OilDhydrationSetting_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OilDhydrationSetting_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OilDesaltingSetting_CreatedByUserId",
                schema: "concept",
                table: "OilDesaltingSetting",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OilDesaltingSetting_DeletedByUserId",
                schema: "concept",
                table: "OilDesaltingSetting",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OilDesaltingSetting_ModifiedByUserId",
                schema: "concept",
                table: "OilDesaltingSetting",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OilDhydrationSetting_CreatedByUserId",
                schema: "concept",
                table: "OilDhydrationSetting",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OilDhydrationSetting_DeletedByUserId",
                schema: "concept",
                table: "OilDhydrationSetting",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OilDhydrationSetting_ModifiedByUserId",
                schema: "concept",
                table: "OilDhydrationSetting",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OilDesaltingSetting",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "OilDhydrationSetting",
                schema: "concept");

            migrationBuilder.AlterColumn<string>(
                name: "FlowlineType",
                schema: "concept",
                table: "FlowlineBoundary",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
