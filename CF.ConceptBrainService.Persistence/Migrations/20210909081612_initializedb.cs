using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class initializedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "concept",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "DepartmentName", "Email", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name", "Role", "UserPrincipal" },
                values: new object[] { new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "admin", "admin", false, null, null, "ConceptorAdmin", 1, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "concept",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"));
        }
    }
}
