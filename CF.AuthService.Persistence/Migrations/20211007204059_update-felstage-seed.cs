using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.AuthService.Persistence.Migrations
{
    public partial class updatefelstageseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("32965527-1fd5-4275-b567-e633da25c737"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("bfc7d1e9-f9be-4bb6-b8ff-9dc1e0429dae"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("e365b29a-18e2-4c42-a054-72ec17c7b286"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("ee616698-2eef-460f-bc02-72f25695a6fa"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "FelStages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("eaa4148f-034c-486c-b8be-c93bacf7307f"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "PRE-FEL", 1 },
                    { new Guid("270a7711-e19e-4a13-9f77-352d14e57850"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL 1", 2 },
                    { new Guid("dc46e5db-82bf-4064-897b-17fc4099b8cb"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL 2", 3 },
                    { new Guid("99e346e9-13fb-488b-a5ad-7569e443e03e"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL 3", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("270a7711-e19e-4a13-9f77-352d14e57850"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("99e346e9-13fb-488b-a5ad-7569e443e03e"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("dc46e5db-82bf-4064-897b-17fc4099b8cb"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("eaa4148f-034c-486c-b8be-c93bacf7307f"));

            migrationBuilder.InsertData(
                schema: "auth",
                table: "FelStages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("bfc7d1e9-f9be-4bb6-b8ff-9dc1e0429dae"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "PRE-FEL", 1 },
                    { new Guid("e365b29a-18e2-4c42-a054-72ec17c7b286"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL 1", 2 },
                    { new Guid("ee616698-2eef-460f-bc02-72f25695a6fa"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL 2", 3 },
                    { new Guid("32965527-1fd5-4275-b567-e633da25c737"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL 3", 4 }
                });
        }
    }
}
