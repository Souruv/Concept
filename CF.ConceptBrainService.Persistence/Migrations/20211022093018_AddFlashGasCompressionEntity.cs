using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class AddFlashGasCompressionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlashGasCompressionSetting",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlashGasCompressionCase = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_FlashGasCompressionSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlashGasCompressionSetting_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlashGasCompressionSetting_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlashGasCompressionSetting_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashGasCompressionSetting_CreatedByUserId",
                schema: "concept",
                table: "FlashGasCompressionSetting",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashGasCompressionSetting_DeletedByUserId",
                schema: "concept",
                table: "FlashGasCompressionSetting",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashGasCompressionSetting_ModifiedByUserId",
                schema: "concept",
                table: "FlashGasCompressionSetting",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashGasCompressionSetting",
                schema: "concept");
        }
    }
}
