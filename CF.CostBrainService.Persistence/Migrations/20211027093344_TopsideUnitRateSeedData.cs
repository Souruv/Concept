using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class TopsideUnitRateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PMTInstallation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstallationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPMTCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_PMTInstallation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PMTInstallation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PMTInstallation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PMTInstallation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "PMTInstallation",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "InstallationName", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "TotalPMTCost" },
                values: new object[,]
                {
                    { new Guid("e490ca71-5dd0-418d-882f-eb357688fd26"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PMT Platform Installation (Jacket + Topside/Module)", false, null, null, 2m },
                    { new Guid("8e00ea37-a8ce-4097-a195-b0f5cebc5b99"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PMT Jacket Installation)", false, null, null, 1m },
                    { new Guid("98d6a1d7-759b-4595-886e-f158ab8a2ccb"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "PMT Topside/Module Installation)", false, null, null, 1m }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("64758bfc-aed0-4206-bae0-3d2a5ab98009"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Below 500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("b196c765-5b11-43bb-b647-50b763c3c5e7"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Below 500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("3c523f2c-9463-4999-a4f5-6fb4dbac5b1e"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Below 500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("184898d5-26a7-455b-9233-9d1b9213deaf"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Topside", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("8fa831f3-7011-4099-ad1c-8e843f1ca3ca"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Topside", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("d9d84970-84a4-4946-9838-35b952bc9496"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Topside", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("c88b9072-8a3b-46cf-ba17-69a40b55d5e7"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Demob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("ffdb2ae1-680f-4af5-9033-d6195f309a5c"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Demob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("17b6a704-1033-4f68-a9d8-5f52856f7c5f"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Demob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("e9bb4dfb-82c2-4616-95c6-cb1835e521f5"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Mob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("8329240c-1471-41f9-a916-632bb72c72a3"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Mob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("9eb9aade-c24d-47cc-89a2-092b46b440ad"), "Pre-Installation Survey", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Mob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("c7851b2d-9675-4987-9350-2af4406bedde"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Escort Tug", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("a38a664b-192d-4b7c-8405-107f916f156b"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Escort Tug", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("75c22f35-7687-4149-aa63-73de3dbd0688"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Escort Tug", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("984944ae-16e1-4485-a52f-9356128d9d17"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Barge Class 300", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 2m, 10.40m, 2m },
                    { new Guid("f504cbfa-b4c3-4a69-952b-ac11494b39d8"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "501-1000", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("e9e899a2-4f09-4465-831d-e25e5127ff3e"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "501-1000", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("c257637f-2fe7-4c73-9576-48d47abe2149"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1001-1500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("aca242a7-91dd-4ec4-a760-e67d4cd65285"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Barge Class 300", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 2m, 10.40m, 2m },
                    { new Guid("20dfacf8-c142-4a6c-bb8d-67ba2241cda5"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "MOBILISATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("d586cf45-7462-48c4-87b8-6143f2fe4960"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "TRANSPORTATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("679f78df-b43a-4c5f-8bfc-06782a6c55f0"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "INSTALLATION ENGINEERING", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("e9aa57fd-750d-40a4-ab66-e3738dffcc4f"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "PMT/MONTH", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("3794e661-1e29-4b7b-a571-6423ef78a02a"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "PMT/MONTH", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("ee4ad770-098d-45bc-bc13-bf319922ee44"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "PMT/MONTH", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("3374d817-ae96-475f-b01d-01171ed4f0e2"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2501 and above", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("dda4b595-a293-4bf6-8796-644adf879448"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2501 and above", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("29b5cfbb-66b3-4026-93e7-d3dcdb5b8772"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2501 and above", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("1bdb1d52-c5a8-457f-b65d-b129bb19e665"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "2001-2500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("600712f2-19d7-4cd3-8437-89f65d689324"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "2001-2500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("05cb67cb-ff13-40df-82e6-89725b2035db"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "2001-2500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("baa827c2-fce5-49b4-ae52-b9898e9ea843"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1501-2000", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("fb964c46-1f4d-4123-80b0-5d408941f373"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1501-2000", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("7ebdd1cd-765b-4030-9b26-23a46594b07f"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "1501-2000", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("b630e650-a671-4cda-9c89-48c47188b4fa"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "1001-1500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("5dd429f1-8e1a-41c8-80da-0fffae41c6a6"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "1001-1500", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("c8d61b0d-e017-44dc-8252-9b81da81a03f"), "HLR & Appurtenances Lifting", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "501-1000", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("359c7c6f-a35b-491f-bf8b-794275c89d25"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Barge Class 300", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 2m, 10.40m, 2m }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("159e2b4d-d599-4aa9-b363-a8ee765e0b75"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Seafastening", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("2368e5d4-4d61-4ac0-a1fe-bf6b1d39b821"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Seafastening", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("c18e7440-2809-4064-a9f2-edeca8956011"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Demob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("284a3f8a-a78a-4f1a-bb34-c75aa7452f71"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Mob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("26c9223c-2218-4138-8c9b-d737889212b0"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Mob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("ca39d985-cfc1-4026-a42d-3781ea166e24"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Mob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("479eccde-fcbb-4760-bc3c-81d0a8670911"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("0ff523fa-d7a6-47ae-8d2b-ddf1c5677b42"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("cca81841-228e-4676-9601-d40b2c7f0152"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("b94f2d97-e916-4018-b553-4c75ceaaf22e"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Demob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("19b01d7d-3545-46fa-8652-81274e04f8fa"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("df44445e-0cb5-4930-a2a2-2c7a9bd4a920"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("a7e7164b-1c64-46f7-8113-1d2c66c2cbf6"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Installation/Flushing", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("ca8e1673-94a3-4aa0-80de-47e91c35b882"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Installation/Flushing", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("70501c78-f1ee-46c0-97c3-1fd494d54de9"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Installation/Flushing", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("99bcc8e7-4640-44b3-b3a4-4d271019e7e3"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Transportation", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("b3d95601-452d-4f07-9c83-c2e3c49143cf"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Transportation", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("5fde7329-d83e-48a0-98c7-1aef790225d1"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Transportation", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("dd9219df-b7d7-4128-b638-5c4f19f46b38"), "Engineering", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("fc170ca9-c1ef-4999-ae81-d4f1f3523578"), "Mobilization", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Demob", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("bd2558f4-511f-4b5e-a5c7-0532dfc94b5a"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "MWB", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("25999a1e-9fbe-4f80-a5b2-090238c4220d"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "MWB", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("e0f5f728-df6f-4ed0-afa2-857e2b51e5c6"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Seafastening", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("d0cdca5d-5348-4861-a4f3-78cf5112fb40"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Catering (Additional)", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("140d06a3-b27b-4d3c-a16e-b9e8a45e47f2"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Catering (Additional)", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("1cb46965-adf8-4c8f-94f1-442dea037b8e"), null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Catering (Additional)", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("8f30dec2-b306-4685-a9df-758066c5cf46"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "ILT Spread Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("1717767c-7821-4944-99f1-44564a07964c"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "ILT Spread Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("83a111f5-8312-4086-9cfc-b11d64a7477c"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "ILT Spread Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("47fe998b-e8ea-4322-8198-58b6147e9c8a"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "ILT Spread Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("ee2f2227-1d34-4601-947b-b3ca4cee40b2"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "ILT Spread Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("5c5796b4-f2ab-4ace-8a3e-cd101f72bf31"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "ILT Spread Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("0da5a9ae-a0f9-443f-8e62-500a525002cb"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Hammer Spread Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("81c91084-cc0d-4564-b62a-2bbee6b2460b"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Hammer Spread Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("4f3615d2-cad7-485c-96e0-7da97e08fa97"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Hammer Spread Conductor", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("86945c01-65b5-4073-997e-235af124a460"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Hammer Spread Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("7cb34d3d-b229-4c53-a281-75a649a87f08"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Hammer Spread Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("2580dce2-1bbf-431f-9253-0739c6f03c45"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Hammer Spread Pile", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), null, null, null },
                    { new Guid("92c2d587-f94c-4e52-8dc6-81cb7fbb6b33"), "MWB/Spread", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "MWB", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("25b0a1f2-1236-4510-9c75-6f8ef12a80d9"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "INSTALLATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("a3d0b8c8-b9cc-4f8f-96e0-0c48dace23d6"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "DEMOB", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PMTInstallation_CreatedByUserId",
                schema: "cost",
                table: "PMTInstallation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PMTInstallation_DeletedByUserId",
                schema: "cost",
                table: "PMTInstallation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PMTInstallation_ModifiedByUserId",
                schema: "cost",
                table: "PMTInstallation",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PMTInstallation",
                schema: "cost");

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("05cb67cb-ff13-40df-82e6-89725b2035db"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0da5a9ae-a0f9-443f-8e62-500a525002cb"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("0ff523fa-d7a6-47ae-8d2b-ddf1c5677b42"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("140d06a3-b27b-4d3c-a16e-b9e8a45e47f2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("159e2b4d-d599-4aa9-b363-a8ee765e0b75"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1717767c-7821-4944-99f1-44564a07964c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("17b6a704-1033-4f68-a9d8-5f52856f7c5f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("184898d5-26a7-455b-9233-9d1b9213deaf"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("19b01d7d-3545-46fa-8652-81274e04f8fa"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1bdb1d52-c5a8-457f-b65d-b129bb19e665"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("1cb46965-adf8-4c8f-94f1-442dea037b8e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("20dfacf8-c142-4a6c-bb8d-67ba2241cda5"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("2368e5d4-4d61-4ac0-a1fe-bf6b1d39b821"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("2580dce2-1bbf-431f-9253-0739c6f03c45"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("25999a1e-9fbe-4f80-a5b2-090238c4220d"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("25b0a1f2-1236-4510-9c75-6f8ef12a80d9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("26c9223c-2218-4138-8c9b-d737889212b0"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("284a3f8a-a78a-4f1a-bb34-c75aa7452f71"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("29b5cfbb-66b3-4026-93e7-d3dcdb5b8772"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("3374d817-ae96-475f-b01d-01171ed4f0e2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("359c7c6f-a35b-491f-bf8b-794275c89d25"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("3794e661-1e29-4b7b-a571-6423ef78a02a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("3c523f2c-9463-4999-a4f5-6fb4dbac5b1e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("479eccde-fcbb-4760-bc3c-81d0a8670911"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("47fe998b-e8ea-4322-8198-58b6147e9c8a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("4f3615d2-cad7-485c-96e0-7da97e08fa97"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("5c5796b4-f2ab-4ace-8a3e-cd101f72bf31"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("5dd429f1-8e1a-41c8-80da-0fffae41c6a6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("5fde7329-d83e-48a0-98c7-1aef790225d1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("600712f2-19d7-4cd3-8437-89f65d689324"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("64758bfc-aed0-4206-bae0-3d2a5ab98009"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("679f78df-b43a-4c5f-8bfc-06782a6c55f0"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("70501c78-f1ee-46c0-97c3-1fd494d54de9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("75c22f35-7687-4149-aa63-73de3dbd0688"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7cb34d3d-b229-4c53-a281-75a649a87f08"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7ebdd1cd-765b-4030-9b26-23a46594b07f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("81c91084-cc0d-4564-b62a-2bbee6b2460b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("8329240c-1471-41f9-a916-632bb72c72a3"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("83a111f5-8312-4086-9cfc-b11d64a7477c"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("86945c01-65b5-4073-997e-235af124a460"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("8f30dec2-b306-4685-a9df-758066c5cf46"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("8fa831f3-7011-4099-ad1c-8e843f1ca3ca"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("92c2d587-f94c-4e52-8dc6-81cb7fbb6b33"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("984944ae-16e1-4485-a52f-9356128d9d17"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("99bcc8e7-4640-44b3-b3a4-4d271019e7e3"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9eb9aade-c24d-47cc-89a2-092b46b440ad"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a38a664b-192d-4b7c-8405-107f916f156b"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a3d0b8c8-b9cc-4f8f-96e0-0c48dace23d6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a7e7164b-1c64-46f7-8113-1d2c66c2cbf6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("aca242a7-91dd-4ec4-a760-e67d4cd65285"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b196c765-5b11-43bb-b647-50b763c3c5e7"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b3d95601-452d-4f07-9c83-c2e3c49143cf"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b630e650-a671-4cda-9c89-48c47188b4fa"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("b94f2d97-e916-4018-b553-4c75ceaaf22e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("baa827c2-fce5-49b4-ae52-b9898e9ea843"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bd2558f4-511f-4b5e-a5c7-0532dfc94b5a"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c18e7440-2809-4064-a9f2-edeca8956011"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c257637f-2fe7-4c73-9576-48d47abe2149"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c7851b2d-9675-4987-9350-2af4406bedde"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c88b9072-8a3b-46cf-ba17-69a40b55d5e7"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("c8d61b0d-e017-44dc-8252-9b81da81a03f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ca39d985-cfc1-4026-a42d-3781ea166e24"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ca8e1673-94a3-4aa0-80de-47e91c35b882"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("cca81841-228e-4676-9601-d40b2c7f0152"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d0cdca5d-5348-4861-a4f3-78cf5112fb40"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d586cf45-7462-48c4-87b8-6143f2fe4960"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("d9d84970-84a4-4946-9838-35b952bc9496"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("dd9219df-b7d7-4128-b638-5c4f19f46b38"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("dda4b595-a293-4bf6-8796-644adf879448"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("df44445e-0cb5-4930-a2a2-2c7a9bd4a920"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e0f5f728-df6f-4ed0-afa2-857e2b51e5c6"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e9aa57fd-750d-40a4-ab66-e3738dffcc4f"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e9bb4dfb-82c2-4616-95c6-cb1835e521f5"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("e9e899a2-4f09-4465-831d-e25e5127ff3e"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ee2f2227-1d34-4601-947b-b3ca4cee40b2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ee4ad770-098d-45bc-bc13-bf319922ee44"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("f504cbfa-b4c3-4a69-952b-ac11494b39d8"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("fb964c46-1f4d-4123-80b0-5d408941f373"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("fc170ca9-c1ef-4999-ae81-d4f1f3523578"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ffdb2ae1-680f-4af5-9033-d6195f309a5c"));
        }
    }
}
