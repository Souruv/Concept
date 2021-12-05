using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class addProjectAuditLogtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectAuditLogs",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionStatus = table.Column<int>(type: "int", nullable: false),
                    RevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RespondedRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ProjectAuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAuditLogs_AppUsers_ActionByUserId",
                        column: x => x.ActionByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAuditLogs_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAuditLogs_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAuditLogs_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAuditLogs_ProjectRevisions_RevisionId",
                        column: x => x.RevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuditLogs_ActionByUserId",
                schema: "prj",
                table: "ProjectAuditLogs",
                column: "ActionByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuditLogs_CreatedByUserId",
                schema: "prj",
                table: "ProjectAuditLogs",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuditLogs_DeletedByUserId",
                schema: "prj",
                table: "ProjectAuditLogs",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuditLogs_ModifiedByUserId",
                schema: "prj",
                table: "ProjectAuditLogs",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuditLogs_RevisionId",
                schema: "prj",
                table: "ProjectAuditLogs",
                column: "RevisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectAuditLogs",
                schema: "prj");
        }
    }
}
