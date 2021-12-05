using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class addflowlineboundarytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowlineBoundary",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    FlowlineType = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_FlowlineBoundary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowlineBoundary_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FlowlineBoundary_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FlowlineBoundary_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowlineBoundary_CreatedByUserId",
                schema: "concept",
                table: "FlowlineBoundary",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowlineBoundary_DeletedByUserId",
                schema: "concept",
                table: "FlowlineBoundary",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowlineBoundary_ModifiedByUserId",
                schema: "concept",
                table: "FlowlineBoundary",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowlineBoundary",
                schema: "concept");
        }
    }
}
