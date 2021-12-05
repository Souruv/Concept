using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.AuthService.Persistence.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "FelStages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("bfc7d1e9-f9be-4bb6-b8ff-9dc1e0429dae"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "PRE-FEL" },
                    { new Guid("e365b29a-18e2-4c42-a054-72ec17c7b286"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL-1" },
                    { new Guid("ee616698-2eef-460f-bc02-72f25695a6fa"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL-2" },
                    { new Guid("32965527-1fd5-4275-b567-e633da25c737"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL-3" }
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("03afecc4-887a-43e7-bd1e-86971fd2ccad"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "CE TM" },
                    { new Guid("27f828b4-5f4f-4c02-8d70-b94a1456869a"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "COE" },
                    { new Guid("ac90d13c-2cae-4a0c-a447-7ef333492ee0"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("03afecc4-887a-43e7-bd1e-86971fd2ccad"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("27f828b4-5f4f-4c02-8d70-b94a1456869a"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ac90d13c-2cae-4a0c-a447-7ef333492ee0"));
        }
    }
}
