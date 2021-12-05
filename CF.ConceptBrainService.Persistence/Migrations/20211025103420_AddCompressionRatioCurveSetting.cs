using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class AddCompressionRatioCurveSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompressionRatioCurveSetting",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    CompressionRatioMin = table.Column<int>(type: "int", nullable: false),
                    CompressionRatioMax = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowRateLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_CompressionRatioCurveSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompressionRatioCurveSetting_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompressionRatioCurveSetting_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompressionRatioCurveSetting_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompressionRatioCurveSetting_CreatedByUserId",
                schema: "concept",
                table: "CompressionRatioCurveSetting",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompressionRatioCurveSetting_DeletedByUserId",
                schema: "concept",
                table: "CompressionRatioCurveSetting",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompressionRatioCurveSetting_ModifiedByUserId",
                schema: "concept",
                table: "CompressionRatioCurveSetting",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompressionRatioCurveSetting",
                schema: "concept");
        }
    }
}
