using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class Installation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterInstallation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstallationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterInstallation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterInstallation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterInstallation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterInstallation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterWeight",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterWeight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterWeight_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterWeight_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterWeight_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstallationDetails",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstallationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_InstallationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallationDetails_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallationDetails_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallationDetails_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallationDetails_MasterInstallation_InstallationId",
                        column: x => x.InstallationId,
                        principalSchema: "cost",
                        principalTable: "MasterInstallation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopsideModuleInstallation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstallationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NumberOfLeg = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_TopsideModuleInstallation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopsideModuleInstallation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopsideModuleInstallation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopsideModuleInstallation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopsideModuleInstallation_MasterInstallation_InstallationId",
                        column: x => x.InstallationId,
                        principalSchema: "cost",
                        principalTable: "MasterInstallation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopsideModuleInstallation_MasterWeight_WeightId",
                        column: x => x.WeightId,
                        principalSchema: "cost",
                        principalTable: "MasterWeight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "DepartmentName", "Email", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name", "Role", "UserPrincipal" },
                values: new object[] { new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "admin", "Costadmin", false, null, null, "CostAdmin", 1, "admin" });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "Equipment",
                columns: new[] { "Id", "Category", "CostimatorCBS", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "Manifolding", "ModifiedByUserId", "ModifiedOn", "Unit", "WBSId" },
                values: new object[] { new Guid("f03a3513-efc7-4b85-8cc3-1b470ab3baad"), "dummy", null, new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "dummy", null, null, null, 1180 });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "MasterInstallation",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "InstallationName", "IsDeleted", "ModifiedByUserId", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("a6ff30eb-47be-4fa8-8f7f-d2215b24bd79"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "3 Legged Jacket Pile Installation", false, null, null },
                    { new Guid("ccbf5380-21e0-48f0-bf39-1db0df739420"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "4 Legged Jacket Pile Installation", false, null, null },
                    { new Guid("eb983470-e461-4bb5-a632-39f093ce464b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "8 Legged Jacket Pile Installation", false, null, null },
                    { new Guid("040eb60e-119e-4de0-883a-79ef56dfe69c"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Conductor Installation", false, null, null },
                    { new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Topside Installation", false, null, null },
                    { new Guid("3d04aa2b-2bf2-4ede-90b2-e255b7970cae"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Modules Installation", false, null, null },
                    { new Guid("8f8a26df-0885-486f-b3c6-23efee6b6c3b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Post Installation Survey", false, null, null }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "MasterWeight",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Weight" },
                values: new object[,]
                {
                    { new Guid("6213bcf9-a424-4d10-942a-266cd825dc02"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Below 500" },
                    { new Guid("5b8fa167-e802-4eee-9af8-47b0def1cf5c"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "501-1000" },
                    { new Guid("8d2b0e8c-beed-40ec-bf0d-7b40dd2781b3"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "1001-1500" },
                    { new Guid("f6c025ce-0927-4f2a-b8a5-9b8e10bf36a2"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "1501-2000" },
                    { new Guid("6f191103-e823-45a6-951a-3362dad331e5"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "2001-2500" },
                    { new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "2500 and above" }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "InstallationDetails",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "Duration", "InstallationId", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Type" },
                values: new object[,]
                {
                    { new Guid("c41cdc85-c587-47a7-a199-41ed7e7afd49"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("a6ff30eb-47be-4fa8-8f7f-d2215b24bd79"), false, null, null, "Pile through leg" },
                    { new Guid("49748d93-5d39-46a8-bf8a-8fd48345bfbf"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("a6ff30eb-47be-4fa8-8f7f-d2215b24bd79"), false, null, null, "Skirt Pile" },
                    { new Guid("e8108adc-7267-4494-88aa-11d760eb1f86"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("ccbf5380-21e0-48f0-bf39-1db0df739420"), false, null, null, "Pile through leg" },
                    { new Guid("87dfc484-a578-4a43-ac68-c73ae47bf74b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("ccbf5380-21e0-48f0-bf39-1db0df739420"), false, null, null, "Skirt Pile" },
                    { new Guid("1b3f2b69-2e35-4525-b620-bde0cde45184"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("eb983470-e461-4bb5-a632-39f093ce464b"), false, null, null, "Pile through leg" },
                    { new Guid("c68688f1-1216-4041-b514-ff2c342d2a6d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("eb983470-e461-4bb5-a632-39f093ce464b"), false, null, null, "Skirt Pile" },
                    { new Guid("13892e5d-c7b5-4c67-86c6-b4b71f9ec12b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("040eb60e-119e-4de0-883a-79ef56dfe69c"), false, null, null, "Conductor Installation" },
                    { new Guid("3381dd1b-e7e1-4cf0-9140-a493acecc7d6"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("8f8a26df-0885-486f-b3c6-23efee6b6c3b"), false, null, null, "General" }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "TopsideModuleInstallation",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "Duration", "InstallationId", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "NumberOfLeg", "WeightId" },
                values: new object[,]
                {
                    { new Guid("cd7432ff-5670-4da0-b66a-0e3cc9034900"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 61m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 3, new Guid("f6c025ce-0927-4f2a-b8a5-9b8e10bf36a2") },
                    { new Guid("d3c29d0f-2595-4803-b470-4106c2f9728d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 64m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 4, new Guid("f6c025ce-0927-4f2a-b8a5-9b8e10bf36a2") },
                    { new Guid("f92e3e65-fbaa-4002-a5dd-7629fa907e11"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 78m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 6, new Guid("f6c025ce-0927-4f2a-b8a5-9b8e10bf36a2") },
                    { new Guid("0d43883b-db32-4543-8fa2-fa34eb4267cc"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 87m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 8, new Guid("f6c025ce-0927-4f2a-b8a5-9b8e10bf36a2") },
                    { new Guid("88ab41ca-ce4d-4856-9791-e3540b1f1f4d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 61m, new Guid("3d04aa2b-2bf2-4ede-90b2-e255b7970cae"), false, null, null, null, new Guid("f6c025ce-0927-4f2a-b8a5-9b8e10bf36a2") },
                    { new Guid("6550afd6-bb4d-46e9-adca-73aa9234433a"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 57m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 1, new Guid("6f191103-e823-45a6-951a-3362dad331e5") },
                    { new Guid("80de0922-3fd9-4400-a861-3d95a96524a0"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 63m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 3, new Guid("6f191103-e823-45a6-951a-3362dad331e5") },
                    { new Guid("9bfdffc5-9f81-46b8-acdb-7968c3a4edb3"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 63m, new Guid("3d04aa2b-2bf2-4ede-90b2-e255b7970cae"), false, null, null, null, new Guid("6f191103-e823-45a6-951a-3362dad331e5") },
                    { new Guid("ed3651ef-f079-48ec-96bf-ae8a74f6e99c"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 80m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 6, new Guid("6f191103-e823-45a6-951a-3362dad331e5") },
                    { new Guid("a05b7fad-4528-4608-93b6-72778dd2426f"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 90m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 8, new Guid("6f191103-e823-45a6-951a-3362dad331e5") },
                    { new Guid("34482443-0898-4e3b-940a-c25484f60013"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 55m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 1, new Guid("f6c025ce-0927-4f2a-b8a5-9b8e10bf36a2") },
                    { new Guid("37c0d56c-0c76-400d-9a06-cca2436bd0ab"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 57m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 1, new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f") },
                    { new Guid("10b315e6-8ad0-46cd-9a7c-850bc6a169f5"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 63m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 3, new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f") },
                    { new Guid("eb0c5a90-ca2c-4c6e-ae0c-3d677799de00"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 66m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 4, new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f") },
                    { new Guid("d24aca33-4544-4afb-b560-e9177689a2c7"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 80m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 6, new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f") },
                    { new Guid("a05a9dd6-0647-4c6b-b63b-a93a7ed88fc6"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 66m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 4, new Guid("6f191103-e823-45a6-951a-3362dad331e5") },
                    { new Guid("68feb7bb-a716-49f4-965e-6c0972970def"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 59m, new Guid("3d04aa2b-2bf2-4ede-90b2-e255b7970cae"), false, null, null, null, new Guid("8d2b0e8c-beed-40ec-bf0d-7b40dd2781b3") },
                    { new Guid("56d0f16a-aa1c-456c-baac-40ec672862b1"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 59m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 3, new Guid("8d2b0e8c-beed-40ec-bf0d-7b40dd2781b3") },
                    { new Guid("74101fa9-a816-4146-b08b-ce6d9abc9ebe"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 75m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 6, new Guid("8d2b0e8c-beed-40ec-bf0d-7b40dd2781b3") },
                    { new Guid("bd204585-9cce-4242-a2db-5fa845f3ac5e"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 49m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 1, new Guid("6213bcf9-a424-4d10-942a-266cd825dc02") },
                    { new Guid("c61a13c1-64c3-42c2-8ac3-1e556097dab4"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 55m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 3, new Guid("6213bcf9-a424-4d10-942a-266cd825dc02") },
                    { new Guid("b5589ee4-c7ba-49ef-8a61-204a3e389606"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 58m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 4, new Guid("6213bcf9-a424-4d10-942a-266cd825dc02") },
                    { new Guid("61938ecd-a3da-4bdc-9cd5-052442c1c09b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 66m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 6, new Guid("6213bcf9-a424-4d10-942a-266cd825dc02") },
                    { new Guid("ff6dc079-452c-489e-8907-bf794d217757"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 78m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 8, new Guid("6213bcf9-a424-4d10-942a-266cd825dc02") },
                    { new Guid("dc8a9ff3-0551-45b1-afe8-b24bfa708133"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 55m, new Guid("3d04aa2b-2bf2-4ede-90b2-e255b7970cae"), false, null, null, null, new Guid("6213bcf9-a424-4d10-942a-266cd825dc02") },
                    { new Guid("2cec7062-0de9-4cae-94d8-1816a2bf1803"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 51m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 1, new Guid("5b8fa167-e802-4eee-9af8-47b0def1cf5c") },
                    { new Guid("7bf8db79-6c4e-4881-9d4a-2d8fdddaec86"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 57m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 3, new Guid("5b8fa167-e802-4eee-9af8-47b0def1cf5c") },
                    { new Guid("592769c3-30d8-461f-92e9-8b9b237c6fa8"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 60m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 4, new Guid("5b8fa167-e802-4eee-9af8-47b0def1cf5c") },
                    { new Guid("20a02a76-9d4b-4e18-9a22-19f85f24bf60"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 72m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 6, new Guid("5b8fa167-e802-4eee-9af8-47b0def1cf5c") },
                    { new Guid("77ac302e-225d-4b6d-8d70-bfb58a3f6bf2"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 81m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 8, new Guid("5b8fa167-e802-4eee-9af8-47b0def1cf5c") },
                    { new Guid("7725b37e-af06-4c84-89ec-120e34020919"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 57m, new Guid("3d04aa2b-2bf2-4ede-90b2-e255b7970cae"), false, null, null, null, new Guid("5b8fa167-e802-4eee-9af8-47b0def1cf5c") },
                    { new Guid("a22775e4-ecb3-403d-9003-e57db835de62"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 53m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 1, new Guid("8d2b0e8c-beed-40ec-bf0d-7b40dd2781b3") },
                    { new Guid("8dc49be2-06e7-424f-af33-fe8a2b65fcc2"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 90m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 8, new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f") },
                    { new Guid("a1d61eaf-6d46-4272-8a02-133affb5ef98"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 62m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 4, new Guid("8d2b0e8c-beed-40ec-bf0d-7b40dd2781b3") }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "TopsideModuleInstallation",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "Duration", "InstallationId", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "NumberOfLeg", "WeightId" },
                values: new object[] { new Guid("18e04660-bd34-4458-b832-17f753782844"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 84m, new Guid("177cb4f7-0dc8-45aa-a4af-720206f9f7be"), false, null, null, 8, new Guid("8d2b0e8c-beed-40ec-bf0d-7b40dd2781b3") });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "TopsideModuleInstallation",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "Duration", "InstallationId", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "NumberOfLeg", "WeightId" },
                values: new object[] { new Guid("124110a2-9cf4-4353-85b3-f86ecfa2d2fe"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 63m, new Guid("3d04aa2b-2bf2-4ede-90b2-e255b7970cae"), false, null, null, null, new Guid("b2a8b83c-7550-4f8b-b49b-5363db9e439f") });

            migrationBuilder.CreateIndex(
                name: "IX_InstallationDetails_CreatedByUserId",
                schema: "cost",
                table: "InstallationDetails",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallationDetails_DeletedByUserId",
                schema: "cost",
                table: "InstallationDetails",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallationDetails_InstallationId",
                schema: "cost",
                table: "InstallationDetails",
                column: "InstallationId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallationDetails_ModifiedByUserId",
                schema: "cost",
                table: "InstallationDetails",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterInstallation_CreatedByUserId",
                schema: "cost",
                table: "MasterInstallation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterInstallation_DeletedByUserId",
                schema: "cost",
                table: "MasterInstallation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterInstallation_ModifiedByUserId",
                schema: "cost",
                table: "MasterInstallation",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterWeight_CreatedByUserId",
                schema: "cost",
                table: "MasterWeight",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterWeight_DeletedByUserId",
                schema: "cost",
                table: "MasterWeight",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterWeight_ModifiedByUserId",
                schema: "cost",
                table: "MasterWeight",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopsideModuleInstallation_CreatedByUserId",
                schema: "cost",
                table: "TopsideModuleInstallation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopsideModuleInstallation_DeletedByUserId",
                schema: "cost",
                table: "TopsideModuleInstallation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopsideModuleInstallation_InstallationId",
                schema: "cost",
                table: "TopsideModuleInstallation",
                column: "InstallationId");

            migrationBuilder.CreateIndex(
                name: "IX_TopsideModuleInstallation_ModifiedByUserId",
                schema: "cost",
                table: "TopsideModuleInstallation",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopsideModuleInstallation_WeightId",
                schema: "cost",
                table: "TopsideModuleInstallation",
                column: "WeightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallationDetails",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "TopsideModuleInstallation",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterInstallation",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterWeight",
                schema: "cost");

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "Equipment",
                keyColumn: "Id",
                keyValue: new Guid("f03a3513-efc7-4b85-8cc3-1b470ab3baad"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"));
        }
    }
}
