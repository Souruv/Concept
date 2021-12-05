using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.AuthService.Persistence.Migrations
{
    public partial class fixrolelistandsortorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("7e94e736-4b5c-416b-8a40-6a6130484f84"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ac90d13c-2cae-4a0c-a447-7ef333492ee0"));

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                schema: "auth",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                schema: "auth",
                table: "FelStages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("32965527-1fd5-4275-b567-e633da25c737"),
                columns: new[] { "Name", "SortOrder" },
                values: new object[] { "FEL 3", 4 });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("bfc7d1e9-f9be-4bb6-b8ff-9dc1e0429dae"),
                column: "SortOrder",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("e365b29a-18e2-4c42-a054-72ec17c7b286"),
                columns: new[] { "Name", "SortOrder" },
                values: new object[] { "FEL 1", 2 });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("ee616698-2eef-460f-bc02-72f25695a6fa"),
                columns: new[] { "Name", "SortOrder" },
                values: new object[] { "FEL 2", 3 });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("f0ff06e8-c884-4531-9e1a-64b7e14382de"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "COE", 1 },
                    { new Guid("1b1f4607-0ff9-4c6b-b8c0-a6bc17f848aa"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEE TM", 2 },
                    { new Guid("4d94bd99-37b2-42fb-9526-b88dd1968f11"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEE TP", 3 },
                    { new Guid("f4124b6a-07b3-4153-bb0d-4e229538bf1d"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEE", 4 },
                    { new Guid("8c5e083e-988e-4ba8-aac3-d6a2424dc68f"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "CE TP", 5 },
                    { new Guid("51799de1-62e4-4be7-9cae-3ce9151979b6"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "CE", 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1b1f4607-0ff9-4c6b-b8c0-a6bc17f848aa"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d94bd99-37b2-42fb-9526-b88dd1968f11"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("51799de1-62e4-4be7-9cae-3ce9151979b6"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8c5e083e-988e-4ba8-aac3-d6a2424dc68f"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f0ff06e8-c884-4531-9e1a-64b7e14382de"));

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f4124b6a-07b3-4153-bb0d-4e229538bf1d"));

            migrationBuilder.DropColumn(
                name: "SortOrder",
                schema: "auth",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                schema: "auth",
                table: "FelStages");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("32965527-1fd5-4275-b567-e633da25c737"),
                column: "Name",
                value: "FEL-3");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("e365b29a-18e2-4c42-a054-72ec17c7b286"),
                column: "Name",
                value: "FEL-1");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "FelStages",
                keyColumn: "Id",
                keyValue: new Guid("ee616698-2eef-460f-bc02-72f25695a6fa"),
                column: "Name",
                value: "FEL-2");

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("03afecc4-887a-43e7-bd1e-86971fd2ccad"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "CE TM" },
                    { new Guid("7e94e736-4b5c-416b-8a40-6a6130484f84"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEE TM" },
                    { new Guid("27f828b4-5f4f-4c02-8d70-b94a1456869a"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "COE" },
                    { new Guid("ac90d13c-2cae-4a0c-a447-7ef333492ee0"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEE" }
                });
        }
    }
}
