using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class GeneralData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "cost",
                table: "MasterGeneralSettings",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LabelName", "ModifiedByUserId", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("cbf70812-024d-4a46-b017-3f1cfdf0d146"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "USD TO MYR RATE", null, null },
                    { new Guid("e79a7576-8e5c-48c9-a7a2-4540f002ffd9"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "PHASING YEARS", null, null },
                    { new Guid("53adb35d-87a1-4fa7-971f-61e686e0c842"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "OWNER'S COST", null, null },
                    { new Guid("48c68cb5-9b9f-48a5-905e-ab7490a48a29"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "DEFAULT CURRENCY", null, null },
                    { new Guid("2dd78847-b42c-43b6-803e-d2926d80917e"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "PRE-DEV+FEED", null, null }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "GeneralSettingsDetails",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "CurrencyLabel", "DeletedByUserId", "DeletedOn", "IsCurrency", "IsDeleted", "IsMultipleValue", "MasterGeneralSettingsId", "ModifiedByUserId", "ModifiedOn", "Type", "Unit", "Value" },
                values: new object[,]
                {
                    { new Guid("ac2fdb6d-4c59-4600-a406-1e8a3c33dc0e"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "MYR", null, null, true, false, false, new Guid("cbf70812-024d-4a46-b017-3f1cfdf0d146"), null, null, "Rate", null, null },
                    { new Guid("d0f1dc1d-6668-424f-9837-149ef2ed836a"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, false, false, new Guid("e79a7576-8e5c-48c9-a7a2-4540f002ffd9"), null, null, "PhasingYears", "years", null },
                    { new Guid("911a6887-9727-475f-ae68-6971fd2f2c4d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, false, false, new Guid("53adb35d-87a1-4fa7-971f-61e686e0c842"), null, null, "OwnerCost", "%", null },
                    { new Guid("227a1d98-58b4-48a2-9325-c0ad2eb04d71"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, false, true, new Guid("48c68cb5-9b9f-48a5-905e-ab7490a48a29"), null, null, "DefaultCurrency", null, null },
                    { new Guid("b376b7b2-9196-4d30-95fa-e687367552be"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, false, false, new Guid("2dd78847-b42c-43b6-803e-d2926d80917e"), null, null, "PreDevFeed", "%", null }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "GeneralSettingsValues",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "GeneralSettingsDetailsId", "IsActive", "IsDeleted", "Label", "ModifiedByUserId", "ModifiedOn", "Value" },
                values: new object[] { new Guid("8b732941-ab2e-4608-885e-4496f2834854"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("227a1d98-58b4-48a2-9325-c0ad2eb04d71"), false, false, "USD", null, null, "USD" });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "GeneralSettingsValues",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "GeneralSettingsDetailsId", "IsActive", "IsDeleted", "Label", "ModifiedByUserId", "ModifiedOn", "Value" },
                values: new object[] { new Guid("f3d44dae-82eb-472a-aa5c-67c765ee567a"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("227a1d98-58b4-48a2-9325-c0ad2eb04d71"), true, false, "MYR", null, null, "MYR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cost",
                table: "GeneralSettingsDetails",
                keyColumn: "Id",
                keyValue: new Guid("911a6887-9727-475f-ae68-6971fd2f2c4d"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "GeneralSettingsDetails",
                keyColumn: "Id",
                keyValue: new Guid("ac2fdb6d-4c59-4600-a406-1e8a3c33dc0e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "GeneralSettingsDetails",
                keyColumn: "Id",
                keyValue: new Guid("b376b7b2-9196-4d30-95fa-e687367552be"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "GeneralSettingsDetails",
                keyColumn: "Id",
                keyValue: new Guid("d0f1dc1d-6668-424f-9837-149ef2ed836a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "GeneralSettingsValues",
                keyColumn: "Id",
                keyValue: new Guid("8b732941-ab2e-4608-885e-4496f2834854"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "GeneralSettingsValues",
                keyColumn: "Id",
                keyValue: new Guid("f3d44dae-82eb-472a-aa5c-67c765ee567a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "GeneralSettingsDetails",
                keyColumn: "Id",
                keyValue: new Guid("227a1d98-58b4-48a2-9325-c0ad2eb04d71"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "MasterGeneralSettings",
                keyColumn: "Id",
                keyValue: new Guid("2dd78847-b42c-43b6-803e-d2926d80917e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "MasterGeneralSettings",
                keyColumn: "Id",
                keyValue: new Guid("53adb35d-87a1-4fa7-971f-61e686e0c842"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "MasterGeneralSettings",
                keyColumn: "Id",
                keyValue: new Guid("cbf70812-024d-4a46-b017-3f1cfdf0d146"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "MasterGeneralSettings",
                keyColumn: "Id",
                keyValue: new Guid("e79a7576-8e5c-48c9-a7a2-4540f002ffd9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "MasterGeneralSettings",
                keyColumn: "Id",
                keyValue: new Guid("48c68cb5-9b9f-48a5-905e-ab7490a48a29"));
        }
    }
}
