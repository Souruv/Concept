using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class JacketUnitRateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "cost",
                table: "ProjectLocation",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "Location", "ModifiedByUserId", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Pan Mal 2020", null, null },
                    { new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Pan Mal 2019 SOSB", null, null },
                    { new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "Pan Mal 2019 BMD", null, null }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "ProjectType",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "ProjectTypeName" },
                values: new object[,]
                {
                    { new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Jacket" },
                    { new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Topside" },
                    { new Guid("64fefefe-ca4b-4aa2-94b6-7176440da94d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Module" },
                    { new Guid("91b1c2df-ac8e-4e8e-aa87-8bf2562b9d23"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Jacket & Topside" },
                    { new Guid("30a2f099-d265-4626-81e2-47c6d6d6e077"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Jacket & Module" }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("60b03ad5-92f9-45a2-805b-e466bbede03d"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Transportation", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("69a592da-ad3c-4b0a-8c55-0c965a40da63"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("1ec8e878-877e-44e9-8005-19a8d08b7433"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("53ab82e9-67e6-4421-9c18-59b147250755"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("90245c9d-36c9-478b-b155-7b5f72b21abe"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("8177fe03-2719-4f25-8afc-bea1e7221a69"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("c7ed080f-cf20-4c58-8c8a-83b650acd018"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Baseline Inspection", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("2ee5a6ef-3f5d-4cd5-aa55-64f0e76b7f59"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Interfield Tow", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("026526fe-d1cf-4499-8ff9-4e258e6a14a2"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Transportation", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("183ba771-568f-4ec2-a858-887891a39fff"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Installation/Flushing", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("7cff08ea-1ff4-441a-968f-f5c6f07811a1"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("bed1e1d3-3e2f-428d-a714-20e940960da4"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("33d7319e-c6fa-421d-8da5-29c0d6d88bac"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Mob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("986c9ec2-e92f-4790-bd32-430b2360bbe0"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Demob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("ced467e9-2460-400a-a5e2-d5eebe74a7d7"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "MWB", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("d331b16e-6eaf-4bbe-814a-42ecd9bc0c4b"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Hammer Spread Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("d2d3fb56-15f7-4477-ac8e-c111d6e3a7a5"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Hammer Spread Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("b002b778-5d85-4e67-b56c-502f530b1d8b"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "ILT Spread Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("08da2340-4093-4a9f-8184-f7d42a8b522c"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "ILT Spread Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("bdc1683c-07f3-4219-a933-1de2cf1c6afa"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Catering (Additional)", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("f7d64b10-4f59-4aab-90c9-3ca6c5bc6e00"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Seafastening", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("bf51541a-d482-4dc9-a540-3d44fb51a010"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Barge Class 280", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.00m, 2.00m },
                    { new Guid("ce681138-6128-42c3-ad38-91ebe1acf6e0"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Barge Class 330", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.00m, 2.00m },
                    { new Guid("c783f128-65b7-498b-b73d-a74f4eac4716"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Escort Tug", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("a21718aa-4b02-4820-a2f4-5a62cb781b34"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("9cb996df-bed8-4862-91d0-a334626f1bf9"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Mob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("cb013eac-acd8-41a8-bd85-550e4a422e87"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("6ac1f83a-3df3-43d9-b55e-70607fda727f"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("6ae9daed-4e96-4abd-844e-d20cbcca62f9"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("1ac3f6f2-034f-40ff-af47-abb69fd49da4"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e68bdbf5-9ff1-4b9a-8c90-a996c969350e"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("6861dc29-819f-41b5-9654-66da67d7e521"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("cf48a7f4-5a4e-40e2-a421-4dd309899b4a"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("3f87060c-e8ad-43ef-8c20-27ff9665127f"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("4afc175a-e3f0-4c69-a979-36bbc60c9638"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("aff78867-6d4b-4a73-b4e5-3f83e8dd8c7e"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("6bded7ac-0d38-4716-a939-e9276e1188c1"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("652532f3-6d32-46a8-95f9-618bb4a8cdc6"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("ec2d4c71-3ad5-4447-8618-30ac853fb4e4"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("a962eff4-84a2-44bd-a193-e48c0b885e6f"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("155fc0a7-af52-43c5-94ac-f698bceb8f79"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("5ca269e4-43fc-42a4-9c60-823ddbe3156c"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("d018602d-c99e-4ce5-9479-22d27b0e25b8"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("2a3493f0-3c6f-4ac6-a1e9-bca7b4023dd9"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("0f828ade-2788-4e8d-a46a-462ab12bdb73"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("96016cab-e9eb-452f-bd06-02c113a5c05c"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7d822514-510b-4079-b7e4-8100587b95b3"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("cd10b0ed-93cb-4c42-9b94-66fb6e018dbd"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("8f4f647f-846c-4c69-b7fe-52cc7da28778"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("ac7274b7-0488-4191-9950-d3d3b290dec9"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("070ddbca-dc1d-42b0-a43a-0d9b68bea85f"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("51b735f4-4ffe-4e1e-b80c-79c71ca14ceb"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("660c7628-e56a-47ae-8a26-38f34453ee78"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("88dc393e-2476-46ce-8849-f74b7cb2e051"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Demob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("a7aac483-e392-4b47-872c-02ccebbe92ac"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Below 500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("bd1bd31c-d587-42d7-a071-9b8f4ab72838"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("4a5a70d2-61c7-4018-84bb-dd14099cae6a"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("c821f5d7-59ba-49a8-a898-a7449e578bdb"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("27e2876b-9e88-477d-8268-8826d0383d53"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("4726fa4a-4480-4639-a158-35a521c63321"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e905344b-766e-4d4c-ba00-dadcf0a7bba6"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e17fa8f0-cab1-4e87-8b72-6cb38931456e"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("0879bd6d-7b03-4ff6-8e1d-854669873c8b"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("11841bef-9a90-4d91-a6a8-8df0e5865942"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("555fab28-01c5-4457-ba6a-d068e74fd0e3"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("30f9d957-642b-4dde-ad08-b8fab293408d"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("d43cbcd3-8d0c-4e49-9bc4-08b92f51462e"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("b0cdfc59-edb7-4a19-8511-3dfd1379d56c"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("40b06e76-da3c-40ac-87df-01adf85a6975"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("756d1606-5c18-42b8-83d2-fd28dbf7bd02"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("fb6b1b04-65a4-4406-87b7-551eb149b7b3"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7061c729-61b5-462f-8521-4dd2838f763c"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("3c4ced9b-0bf0-4722-ae97-05ac1f17f3a1"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("b31b0ce5-3f5f-476f-a508-2be62a8b0479"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("1d2a5160-fbf9-4918-8f5a-d18868a0b562"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("d4d37e5c-3d54-45eb-b802-1c2e513ff822"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("b1791e13-b508-411c-ba4f-519d53e6083b"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7b3f8860-5099-456b-9ae4-2b3fb83ecc47"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("8437c51a-85d5-4f47-b46f-a06b7649fba1"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7f7f1fa9-7536-44d3-b214-7e314e721ef6"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Jacket * Topside", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("faa47823-cffe-4e07-8018-52f78962a795"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("411d8190-b030-4e01-a8e1-4d4d3a35577c"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("926e16a5-25ad-4677-a7ea-b56c72ad49c1"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "501-1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("b713b693-0b45-410f-ba4f-144e348f0648"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("6b7bae65-918d-4f0a-93d6-502565d998a2"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("19c2c84e-dcdc-4011-beca-a7c72436dcd1"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("d341656e-cf6b-4cc7-8a4c-2cfc7230a35f"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2501 and above", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7cda7e56-9734-44b1-a5aa-228e527646cd"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("471f9bdf-172f-4c81-9cfc-e096570d1f74"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("9d9448e5-884c-4961-a387-19e871b9278f"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("970c781a-37a5-4bf6-81c4-311383b6d7c7"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("304e12e5-12e1-46e4-8c52-b06b3791e521"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("091d2c75-6319-4d22-96be-ac72f7c3a786"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("293ad03d-3068-42f0-8e7a-2c35b4ea679f"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("45b44307-d9dc-4cb1-a231-52d61eb2c0d1"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("74512556-f50f-4335-a8a3-fb3517da4ba9"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("3e1ca3ea-da2d-4a51-a2ef-58208495fa54"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("74ae4515-5af3-4f8b-a80b-d71fdcb2e052"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e41fd4da-9f3b-481d-9e0e-ee142f22a8af"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "PMT/MONTH", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("abf05321-e579-43bc-adbb-f6ce8de951c8"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("04310672-839d-4db4-a4bf-4a1a7b7d3957"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("b640d695-93f0-4dbd-af56-a67728b4501f"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("93be6f04-0187-4214-bd28-fdd2de4f4784"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("0d6c20bd-8234-4c60-bdb0-46aca5f63cf2"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("a32ced26-e101-4b60-80d9-6c2bdb24bb01"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e088968c-ac05-488f-9754-05a1c058f0c2"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("14c77aad-8b16-4b25-b0dc-1bbc6aad09aa"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "PMT/MONTH", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("6e8b9564-8eb5-4cb8-a90f-28c6abbc3c0f"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7800c846-5d00-41f5-8992-1f72db0e8477"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("94d2f2ae-894d-4fb1-8ebf-551ffa1d7af7"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("fd06552c-ee06-49ae-984f-d5c7a5d19348"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("0d2382ed-e23d-4e9b-9bd1-1fb825e36e56"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("bf4379a3-293a-44a2-a850-003069d48844"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("16a72dac-6af4-4453-85de-4b920940d931"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("1319c862-9212-4cde-b40e-842996542c97"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("d042733c-e413-4a04-85dc-829109635ef0"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("ba18d99a-06d0-484e-ac63-278a5bf4118c"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("dcafe705-3377-4e2c-b761-70492be4ad8c"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "PMT/MONTH", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("beaf6470-e5f9-4cec-8a22-60682602ffaf"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("a48304d1-5315-4db4-a442-e26691bf0711"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("6355c8a7-a240-4209-80b5-a679a71e482e"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("9ffd0170-e260-475c-b0ae-f38eb79deb4d"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("1fa8696a-659b-4e04-bcca-2ebb5c42b0bd"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("192d9c32-f117-4257-809a-e7b42e1e8121"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("824aaba8-ad6e-4d9c-9ef6-8f638b6cf3bc"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("c7d6af54-3ec6-4b28-a24d-6bdfa2f6cb5b"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("c5c9136e-a56d-4638-8ad2-2c6e45c142cc"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("9f51e64d-ebf4-4106-aaa9-daaa8f4e00c0"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("f6c9339f-bcf9-4ecb-aa06-4f95d796c588"), "PMO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("bc186d20-a141-435f-8e5c-6e7d409a8637"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("82d89d3f-a6a0-420d-8b78-338dfb6b525e"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("770c50cf-b059-4dd6-8b6c-f9d6f5c2c0ae"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("651a6053-d0d8-4faa-a27b-1423aba85c65"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("1d6a23af-32a9-4c7a-8234-451dc8f0ea73"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("81188aaf-8e1a-4959-9748-6f6df5d923a6"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("00ca6ebd-5881-4ddc-a220-64639d6bf673"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2501 and above", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("0ab90337-06f8-4a52-b0fb-0c2b6497104a"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Installation/Flushing", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("a386ccf6-bfb0-40e7-b11a-8596fd07e446"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("4d116759-ed59-4ea4-a298-c22756295171"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("102c651b-7856-43b2-ac43-c4727e96b9b4"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Mob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("100cdd91-9530-4318-9b9e-c10831d3daf1"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Demob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("cf855891-685b-4aec-a134-0218c5e367d4"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "MWB", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("419140a0-7a69-4998-aa49-939bad6cc937"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Hammer Spread Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("c72917cf-22e6-47e6-a22c-9fc4bd8ac2b2"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Hammer Spread Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("895a62ac-2496-472d-9930-c77610ad4062"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "ILT Spread Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("9b6205ed-5966-425f-8026-593d49fbe185"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "ILT Spread Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("81c719d1-c311-46a8-949c-497ed2a060fe"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Catering (Additional)", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("0e566a5a-9a21-4b94-ad44-98b9c81480d7"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Seafastening", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7d26c0c0-86f3-487f-80de-0b914e6381c5"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Barge Class 280", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.00m, 2.00m },
                    { new Guid("9dc04b2f-069e-44ce-9bf0-9589a3affb97"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Barge Class 330", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.00m, 2.00m },
                    { new Guid("7ba26412-e8fa-4d4f-97b4-f20154418639"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Escort Tug", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e63310ce-162c-4724-8e0a-4d45dd4476a3"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Mob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("16edb21d-4769-4ff3-b283-3f7e7b6be64c"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Demob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7a6d877a-5b01-4a32-af76-b58a8d0ddf2a"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Jacket * Topside", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("fd99262f-c0d6-4c9a-9743-b3918b00eaaa"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Below 500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("a77c376e-573b-4216-8837-d3918ab24452"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "501-1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("4029e217-e8dc-4439-a8f1-3330b5e10922"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e427ab02-1180-4e24-8fc6-94da16e8e251"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e82a4a48-780b-4d52-b01d-7024c37192b0"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("915b83aa-5ee5-4ac3-91b4-bf3d1460e28b"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("2e5d71fa-7a53-4294-89d7-6bdec89b492c"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("fb5a9971-aacc-4607-a16e-5f26cf40fb31"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("ef0b7b3d-201b-4ff8-bd61-531e65edb4d8"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("172ae729-300d-4610-83fc-87591f6a4ef3"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Catering (Additional)", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("a0f44ea6-c877-4338-a445-3f11bd346a88"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Seafastening", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("7470e32c-232b-47c7-9b7f-0250389c2593"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Barge Class 280", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.00m, 2.00m },
                    { new Guid("d89d62fe-e2b0-472f-9e4d-9e58f80c2708"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Barge Class 330", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.00m, 2.00m },
                    { new Guid("2e019394-71d0-45c8-92b4-abcc28783a47"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Escort Tug", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("1da10baf-6d08-4165-8b46-1d880244c9fa"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Mob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("9520ba70-3152-4117-b638-b094b068da17"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Demob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("cbe39dee-43ab-49bc-89e7-96d48ec9f0f2"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Jacket * Topside", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("8a73ec87-fbd0-4c74-b420-0e072a6f2c41"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Below 500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("f011901e-ec23-4174-b68d-f2a10bc7872c"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "501-1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("078eefa3-f5bb-4023-a2f4-4540011556e0"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("49d151bb-f501-47f1-9569-d29ffb2e9b92"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e8bf83d1-a91a-46a7-b065-04f0ff439678"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("5b17a89a-cdaf-4a71-9ff0-a1cac33dcfa9"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2501 and above", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("ef4f2ce4-b885-4f07-84a4-fa485ec20789"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("4793b41d-88ea-438d-9cb2-9bca5f623622"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("4a53c980-ce72-41ed-810c-d5587052deef"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("d5e1eb9d-b248-42e6-9313-83755db63aad"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("805d8063-85c8-4239-a21d-ce02b9898699"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("70484dcd-e964-49ff-afe7-a15e8b8ea569"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("75c190f5-c7f2-4197-b74f-5ddbeffaa0cd"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("7a145aa4-4e30-4442-b609-8c9731f59e65"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("d7b7359e-adcc-45c1-b057-8daff4884980"), "HLR & Appurtenances Launching", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("bfd9e459-c753-4e15-8f6c-938ac2479c4c"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "ILT Spread Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("9edcc1c5-55eb-4a2f-9406-1a071366a231"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "ILT Spread Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("90ad51a7-5794-4d7b-977b-efed54c90544"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Hammer Spread Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("3985aa74-8352-47a2-9626-88cc57c07766"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Hammer Spread Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("dc40a560-8ba4-47b3-96ec-afadafbaea9c"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("2cc9f1fc-44e6-43d1-ad63-3e5d810e774d"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("e4a0cbd1-8ec3-45fa-812d-d7be91304d8e"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("f954de2c-d9eb-4358-850e-5e27832a1a4b"), "SBO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("711f81c4-ba87-49f0-91e4-635aa8d471d2"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Below 1000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("175ad42f-ef77-4d75-b7b3-52b57e638f88"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1001-1500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("769a02e3-c83b-4c38-be7f-a59779002d16"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1501-2000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("80d893fe-ee4c-44f4-80c3-fdfb9498d0b1"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2001-2500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("859313cf-3f70-4a2f-89f3-c36d6facc14f"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2501-3000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("01c6cdff-8e82-4410-9b36-77759fdaa156"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "3001-3500", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("97e9a0eb-08e4-4568-a1a7-d9ecba6111c8"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "3501-4000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("1734d784-2809-4829-bf5e-5bfbdbe04c7a"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Baseline Inspection", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("ce810bcb-1bcb-4409-a55d-a234629a0610"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "4001-5000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("a6703058-d3be-4481-87d2-ac3d6b3e1657"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "6001-7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("46316100-f997-4653-bb49-57775a56fe78"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, ">7000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("6262feed-486b-460f-b769-9c3fc497b190"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Baseline Inspection", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("a0f6c3ea-52a5-4a9a-a5be-2589b4709d43"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Interfield Tow", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("906cccae-aba9-4fff-af78-475ef484ed12"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Transportation", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("4fa53f72-fe8e-49bd-bba2-92abe303982c"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Installation/Flushing", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("607b5652-d717-4084-9f11-f8aafdd2e805"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Pile", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("d16c8aa5-cae3-4920-820b-b37a7f7929cb"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Conductor", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.25m, 1.00m },
                    { new Guid("fc8553e0-07b9-48fe-afed-0518e281b8ba"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Mob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("d2f6596e-b28a-4cb6-b114-5a7a8a020357"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Demob", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("19be80dc-b1b1-448e-ba31-7aa63ceb89b6"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "MWB", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.20m, 1.00m },
                    { new Guid("04dfc650-bf8f-4049-92c9-cec6592bb3bc"), "SKO", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "5001-6000", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m },
                    { new Guid("0928b33f-2da3-40ab-9706-7ac105a1180c"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Interfield Tow", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 1.00m, 5.00m, 1.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cost",
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("30a2f099-d265-4626-81e2-47c6d6d6e077"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("41190744-14be-4d22-90e7-6ccee5b45331"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("64fefefe-ca4b-4aa2-94b6-7176440da94d"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("91b1c2df-ac8e-4e8e-aa87-8bf2562b9d23"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("00ca6ebd-5881-4ddc-a220-64639d6bf673"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("01c6cdff-8e82-4410-9b36-77759fdaa156"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("026526fe-d1cf-4499-8ff9-4e258e6a14a2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("04310672-839d-4db4-a4bf-4a1a7b7d3957"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("04dfc650-bf8f-4049-92c9-cec6592bb3bc"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("070ddbca-dc1d-42b0-a43a-0d9b68bea85f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("078eefa3-f5bb-4023-a2f4-4540011556e0"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0879bd6d-7b03-4ff6-8e1d-854669873c8b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("08da2340-4093-4a9f-8184-f7d42a8b522c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("091d2c75-6319-4d22-96be-ac72f7c3a786"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0928b33f-2da3-40ab-9706-7ac105a1180c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0ab90337-06f8-4a52-b0fb-0c2b6497104a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0d2382ed-e23d-4e9b-9bd1-1fb825e36e56"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0d6c20bd-8234-4c60-bdb0-46aca5f63cf2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0e566a5a-9a21-4b94-ad44-98b9c81480d7"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0f828ade-2788-4e8d-a46a-462ab12bdb73"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("100cdd91-9530-4318-9b9e-c10831d3daf1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("102c651b-7856-43b2-ac43-c4727e96b9b4"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("11841bef-9a90-4d91-a6a8-8df0e5865942"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1319c862-9212-4cde-b40e-842996542c97"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("14c77aad-8b16-4b25-b0dc-1bbc6aad09aa"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("155fc0a7-af52-43c5-94ac-f698bceb8f79"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("16a72dac-6af4-4453-85de-4b920940d931"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("16edb21d-4769-4ff3-b283-3f7e7b6be64c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("172ae729-300d-4610-83fc-87591f6a4ef3"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1734d784-2809-4829-bf5e-5bfbdbe04c7a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("175ad42f-ef77-4d75-b7b3-52b57e638f88"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("183ba771-568f-4ec2-a858-887891a39fff"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("192d9c32-f117-4257-809a-e7b42e1e8121"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("19be80dc-b1b1-448e-ba31-7aa63ceb89b6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("19c2c84e-dcdc-4011-beca-a7c72436dcd1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1ac3f6f2-034f-40ff-af47-abb69fd49da4"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1d2a5160-fbf9-4918-8f5a-d18868a0b562"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1d6a23af-32a9-4c7a-8234-451dc8f0ea73"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1da10baf-6d08-4165-8b46-1d880244c9fa"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1ec8e878-877e-44e9-8005-19a8d08b7433"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1fa8696a-659b-4e04-bcca-2ebb5c42b0bd"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("27e2876b-9e88-477d-8268-8826d0383d53"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("293ad03d-3068-42f0-8e7a-2c35b4ea679f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("2a3493f0-3c6f-4ac6-a1e9-bca7b4023dd9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("2cc9f1fc-44e6-43d1-ad63-3e5d810e774d"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("2e019394-71d0-45c8-92b4-abcc28783a47"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("2e5d71fa-7a53-4294-89d7-6bdec89b492c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("2ee5a6ef-3f5d-4cd5-aa55-64f0e76b7f59"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("304e12e5-12e1-46e4-8c52-b06b3791e521"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("30f9d957-642b-4dde-ad08-b8fab293408d"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("33d7319e-c6fa-421d-8da5-29c0d6d88bac"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("3985aa74-8352-47a2-9626-88cc57c07766"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("3c4ced9b-0bf0-4722-ae97-05ac1f17f3a1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("3e1ca3ea-da2d-4a51-a2ef-58208495fa54"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("3f87060c-e8ad-43ef-8c20-27ff9665127f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4029e217-e8dc-4439-a8f1-3330b5e10922"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("40b06e76-da3c-40ac-87df-01adf85a6975"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("411d8190-b030-4e01-a8e1-4d4d3a35577c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("419140a0-7a69-4998-aa49-939bad6cc937"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("45b44307-d9dc-4cb1-a231-52d61eb2c0d1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("46316100-f997-4653-bb49-57775a56fe78"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("471f9bdf-172f-4c81-9cfc-e096570d1f74"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4726fa4a-4480-4639-a158-35a521c63321"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4793b41d-88ea-438d-9cb2-9bca5f623622"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("49d151bb-f501-47f1-9569-d29ffb2e9b92"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4a53c980-ce72-41ed-810c-d5587052deef"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4a5a70d2-61c7-4018-84bb-dd14099cae6a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4afc175a-e3f0-4c69-a979-36bbc60c9638"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4d116759-ed59-4ea4-a298-c22756295171"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4fa53f72-fe8e-49bd-bba2-92abe303982c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("51b735f4-4ffe-4e1e-b80c-79c71ca14ceb"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("53ab82e9-67e6-4421-9c18-59b147250755"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("555fab28-01c5-4457-ba6a-d068e74fd0e3"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("5b17a89a-cdaf-4a71-9ff0-a1cac33dcfa9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("5ca269e4-43fc-42a4-9c60-823ddbe3156c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("607b5652-d717-4084-9f11-f8aafdd2e805"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("60b03ad5-92f9-45a2-805b-e466bbede03d"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("6262feed-486b-460f-b769-9c3fc497b190"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("6355c8a7-a240-4209-80b5-a679a71e482e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("651a6053-d0d8-4faa-a27b-1423aba85c65"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("652532f3-6d32-46a8-95f9-618bb4a8cdc6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("660c7628-e56a-47ae-8a26-38f34453ee78"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("6861dc29-819f-41b5-9654-66da67d7e521"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("69a592da-ad3c-4b0a-8c55-0c965a40da63"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("6ac1f83a-3df3-43d9-b55e-70607fda727f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("6ae9daed-4e96-4abd-844e-d20cbcca62f9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("6b7bae65-918d-4f0a-93d6-502565d998a2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("6bded7ac-0d38-4716-a939-e9276e1188c1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("6e8b9564-8eb5-4cb8-a90f-28c6abbc3c0f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("70484dcd-e964-49ff-afe7-a15e8b8ea569"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7061c729-61b5-462f-8521-4dd2838f763c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("711f81c4-ba87-49f0-91e4-635aa8d471d2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("74512556-f50f-4335-a8a3-fb3517da4ba9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7470e32c-232b-47c7-9b7f-0250389c2593"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("74ae4515-5af3-4f8b-a80b-d71fdcb2e052"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("756d1606-5c18-42b8-83d2-fd28dbf7bd02"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("75c190f5-c7f2-4197-b74f-5ddbeffaa0cd"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("769a02e3-c83b-4c38-be7f-a59779002d16"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("770c50cf-b059-4dd6-8b6c-f9d6f5c2c0ae"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7800c846-5d00-41f5-8992-1f72db0e8477"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7a145aa4-4e30-4442-b609-8c9731f59e65"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7a6d877a-5b01-4a32-af76-b58a8d0ddf2a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7b3f8860-5099-456b-9ae4-2b3fb83ecc47"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7ba26412-e8fa-4d4f-97b4-f20154418639"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7cda7e56-9734-44b1-a5aa-228e527646cd"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7cff08ea-1ff4-441a-968f-f5c6f07811a1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7d26c0c0-86f3-487f-80de-0b914e6381c5"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7d822514-510b-4079-b7e4-8100587b95b3"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7f7f1fa9-7536-44d3-b214-7e314e721ef6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("805d8063-85c8-4239-a21d-ce02b9898699"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("80d893fe-ee4c-44f4-80c3-fdfb9498d0b1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("81188aaf-8e1a-4959-9748-6f6df5d923a6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("8177fe03-2719-4f25-8afc-bea1e7221a69"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("81c719d1-c311-46a8-949c-497ed2a060fe"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("824aaba8-ad6e-4d9c-9ef6-8f638b6cf3bc"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("82d89d3f-a6a0-420d-8b78-338dfb6b525e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("8437c51a-85d5-4f47-b46f-a06b7649fba1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("859313cf-3f70-4a2f-89f3-c36d6facc14f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("88dc393e-2476-46ce-8849-f74b7cb2e051"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("895a62ac-2496-472d-9930-c77610ad4062"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("8a73ec87-fbd0-4c74-b420-0e072a6f2c41"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("8f4f647f-846c-4c69-b7fe-52cc7da28778"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("90245c9d-36c9-478b-b155-7b5f72b21abe"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("906cccae-aba9-4fff-af78-475ef484ed12"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("90ad51a7-5794-4d7b-977b-efed54c90544"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("915b83aa-5ee5-4ac3-91b4-bf3d1460e28b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("926e16a5-25ad-4677-a7ea-b56c72ad49c1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("93be6f04-0187-4214-bd28-fdd2de4f4784"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("94d2f2ae-894d-4fb1-8ebf-551ffa1d7af7"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9520ba70-3152-4117-b638-b094b068da17"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("96016cab-e9eb-452f-bd06-02c113a5c05c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("970c781a-37a5-4bf6-81c4-311383b6d7c7"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("97e9a0eb-08e4-4568-a1a7-d9ecba6111c8"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("986c9ec2-e92f-4790-bd32-430b2360bbe0"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9b6205ed-5966-425f-8026-593d49fbe185"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9cb996df-bed8-4862-91d0-a334626f1bf9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9d9448e5-884c-4961-a387-19e871b9278f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9dc04b2f-069e-44ce-9bf0-9589a3affb97"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9edcc1c5-55eb-4a2f-9406-1a071366a231"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9f51e64d-ebf4-4106-aaa9-daaa8f4e00c0"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9ffd0170-e260-475c-b0ae-f38eb79deb4d"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a0f44ea6-c877-4338-a445-3f11bd346a88"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a0f6c3ea-52a5-4a9a-a5be-2589b4709d43"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a21718aa-4b02-4820-a2f4-5a62cb781b34"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a32ced26-e101-4b60-80d9-6c2bdb24bb01"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a386ccf6-bfb0-40e7-b11a-8596fd07e446"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a48304d1-5315-4db4-a442-e26691bf0711"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a6703058-d3be-4481-87d2-ac3d6b3e1657"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a77c376e-573b-4216-8837-d3918ab24452"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a7aac483-e392-4b47-872c-02ccebbe92ac"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a962eff4-84a2-44bd-a193-e48c0b885e6f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("abf05321-e579-43bc-adbb-f6ce8de951c8"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ac7274b7-0488-4191-9950-d3d3b290dec9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("aff78867-6d4b-4a73-b4e5-3f83e8dd8c7e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b002b778-5d85-4e67-b56c-502f530b1d8b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b0cdfc59-edb7-4a19-8511-3dfd1379d56c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b1791e13-b508-411c-ba4f-519d53e6083b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b31b0ce5-3f5f-476f-a508-2be62a8b0479"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b640d695-93f0-4dbd-af56-a67728b4501f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b713b693-0b45-410f-ba4f-144e348f0648"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ba18d99a-06d0-484e-ac63-278a5bf4118c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bc186d20-a141-435f-8e5c-6e7d409a8637"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bd1bd31c-d587-42d7-a071-9b8f4ab72838"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bdc1683c-07f3-4219-a933-1de2cf1c6afa"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("beaf6470-e5f9-4cec-8a22-60682602ffaf"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bed1e1d3-3e2f-428d-a714-20e940960da4"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bf4379a3-293a-44a2-a850-003069d48844"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bf51541a-d482-4dc9-a540-3d44fb51a010"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bfd9e459-c753-4e15-8f6c-938ac2479c4c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c5c9136e-a56d-4638-8ad2-2c6e45c142cc"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c72917cf-22e6-47e6-a22c-9fc4bd8ac2b2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c783f128-65b7-498b-b73d-a74f4eac4716"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c7d6af54-3ec6-4b28-a24d-6bdfa2f6cb5b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c7ed080f-cf20-4c58-8c8a-83b650acd018"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c821f5d7-59ba-49a8-a898-a7449e578bdb"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("cb013eac-acd8-41a8-bd85-550e4a422e87"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("cbe39dee-43ab-49bc-89e7-96d48ec9f0f2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("cd10b0ed-93cb-4c42-9b94-66fb6e018dbd"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ce681138-6128-42c3-ad38-91ebe1acf6e0"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ce810bcb-1bcb-4409-a55d-a234629a0610"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ced467e9-2460-400a-a5e2-d5eebe74a7d7"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("cf48a7f4-5a4e-40e2-a421-4dd309899b4a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("cf855891-685b-4aec-a134-0218c5e367d4"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d018602d-c99e-4ce5-9479-22d27b0e25b8"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d042733c-e413-4a04-85dc-829109635ef0"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d16c8aa5-cae3-4920-820b-b37a7f7929cb"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d2d3fb56-15f7-4477-ac8e-c111d6e3a7a5"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d2f6596e-b28a-4cb6-b114-5a7a8a020357"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d331b16e-6eaf-4bbe-814a-42ecd9bc0c4b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d341656e-cf6b-4cc7-8a4c-2cfc7230a35f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d43cbcd3-8d0c-4e49-9bc4-08b92f51462e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d4d37e5c-3d54-45eb-b802-1c2e513ff822"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d5e1eb9d-b248-42e6-9313-83755db63aad"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d7b7359e-adcc-45c1-b057-8daff4884980"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d89d62fe-e2b0-472f-9e4d-9e58f80c2708"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("dc40a560-8ba4-47b3-96ec-afadafbaea9c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("dcafe705-3377-4e2c-b761-70492be4ad8c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e088968c-ac05-488f-9754-05a1c058f0c2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e17fa8f0-cab1-4e87-8b72-6cb38931456e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e41fd4da-9f3b-481d-9e0e-ee142f22a8af"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e427ab02-1180-4e24-8fc6-94da16e8e251"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e4a0cbd1-8ec3-45fa-812d-d7be91304d8e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e63310ce-162c-4724-8e0a-4d45dd4476a3"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e68bdbf5-9ff1-4b9a-8c90-a996c969350e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e82a4a48-780b-4d52-b01d-7024c37192b0"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e8bf83d1-a91a-46a7-b065-04f0ff439678"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e905344b-766e-4d4c-ba00-dadcf0a7bba6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ec2d4c71-3ad5-4447-8618-30ac853fb4e4"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ef0b7b3d-201b-4ff8-bd61-531e65edb4d8"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ef4f2ce4-b885-4f07-84a4-fa485ec20789"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("f011901e-ec23-4174-b68d-f2a10bc7872c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("f6c9339f-bcf9-4ecb-aa06-4f95d796c588"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("f7d64b10-4f59-4aab-90c9-3ca6c5bc6e00"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("f954de2c-d9eb-4358-850e-5e27832a1a4b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("faa47823-cffe-4e07-8018-52f78962a795"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("fb5a9971-aacc-4607-a16e-5f26cf40fb31"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("fb6b1b04-65a4-4406-87b7-551eb149b7b3"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("fc8553e0-07b9-48fe-afed-0518e281b8ba"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("fd06552c-ee06-49ae-984f-d5c7a5d19348"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("fd99262f-c0d6-4c9a-9743-b3918b00eaaa"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"));
        }
    }
}
