using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class changecolumnnameinProjectAuditLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RevisionStatus",
                schema: "prj",
                table: "ProjectAuditLogs",
                newName: "AuditLogStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuditLogStatus",
                schema: "prj",
                table: "ProjectAuditLogs",
                newName: "RevisionStatus");
        }
    }
}
