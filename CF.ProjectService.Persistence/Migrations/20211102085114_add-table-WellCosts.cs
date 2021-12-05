using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class addtableWellCosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WellCosts",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Wells = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    P50Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    P80Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    P50OutputCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    P80OutputCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_WellCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WellCosts_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WellCosts_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WellCosts_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WellCosts_ProjectRevisions_RevisionId",
                        column: x => x.RevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WellCosts_CreatedByUserId",
                schema: "prj",
                table: "WellCosts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WellCosts_DeletedByUserId",
                schema: "prj",
                table: "WellCosts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WellCosts_ModifiedByUserId",
                schema: "prj",
                table: "WellCosts",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WellCosts_RevisionId",
                schema: "prj",
                table: "WellCosts",
                column: "RevisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WellCosts",
                schema: "prj");
        }
    }
}
