using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class ScheduleNorm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BargeDuration",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barge = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_BargeDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BargeDuration_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BargeDuration_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BargeDuration_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstallationMethod",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_InstallationMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallationMethod_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallationMethod_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstallationMethod_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterLegged",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfLeg = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterLegged", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterLegged_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterLegged_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterLegged_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeggedDuration",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeggedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LeggedDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeggedDuration_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeggedDuration_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeggedDuration_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeggedDuration_MasterLegged_LeggedId",
                        column: x => x.LeggedId,
                        principalSchema: "cost",
                        principalTable: "MasterLegged",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "BargeDuration",
                columns: new[] { "Id", "Barge", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "Duration", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Type" },
                values: new object[,]
                {
                    { new Guid("a1eea657-854c-4a7e-8576-7cb894c2163d"), "DP", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6m, false, null, null, "Barge Setup" },
                    { new Guid("20ceba3b-1601-4153-b54f-4ae92cae05d0"), "Achored ", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 24m, false, null, null, "Barge Setup" },
                    { new Guid("62f0bdb0-0b2e-4149-b2a5-0c0de76e0b76"), "DP ", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1m, false, null, null, "Barge Pull-Out" },
                    { new Guid("d673c6df-bbef-4da2-a93d-646a90548605"), "Achored ", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 24m, false, null, null, "Barge Pull-Out" }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "InstallationMethod",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "MethodName", "ModifiedByUserId", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("f0d68188-5edc-4e82-97e5-b7e220603905"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "LAUNCHING", null, null },
                    { new Guid("4fd94b76-7720-4650-b78d-87007a48c987"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, "LIFTING", null, null }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "MasterLegged",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "NumberOfLeg" },
                values: new object[,]
                {
                    { new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "3 Legged Jacket/Tripod" },
                    { new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "4 Legged Jacket" },
                    { new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "8 Legged Jacket" }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "LeggedDuration",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "Duration", "IsDeleted", "LeggedId", "Length", "Method", "ModifiedByUserId", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("f4f66f16-6292-4344-a38b-ce163696d026"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 14m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "30-40", "Pre-lift Preparation", null, null },
                    { new Guid("cf46eb6a-d9b5-4db3-84bb-616ddadbc949"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "51-60", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("7133f938-535e-4c1f-bb99-7c9a2ed43e92"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "61-70", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("f6540094-9cd3-4d68-9de8-0ac304a54856"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "71-80", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("f75a9683-324d-4a53-a2c8-522a61b5a812"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "81-90", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("b20be170-3b4d-4a3c-940b-e236dfd507bb"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 22m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "91-100", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("69307403-1599-4dc7-ab79-9d1bc0d20c7b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 32m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "30-40", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("50217f19-73cd-40dc-bd10-f162614107c4"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 32m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "41-50", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("88b4829a-fcfe-45a4-beb9-29526bc5dfad"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 32m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "51-60", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("bec9f857-53fa-4c48-8383-9d1183f0c48b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 33m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "61-70", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("660c1436-3c72-4eac-af71-bf2ffecad409"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 34m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "71-80", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("0162a559-0170-459e-a362-269e4f08f4a4"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 34m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "81-90", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("cc690dab-285c-4c13-9fcf-9fdd23239985"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "41-50", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("c0c1bab8-18ce-4dbd-99c3-405dcb896f1d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 34m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "91-100", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("ad61c2a2-6726-4908-8a9d-f15965c21a34"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "41-50", "Pre-launch Preparation", null, null },
                    { new Guid("3a375ad6-5fbf-4d49-b063-9fd227804431"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "51-60", "Pre-launch Preparation", null, null },
                    { new Guid("dcc4de6e-26b4-4ceb-9fdd-49e18214e6c1"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "61-70", "Pre-launch Preparation", null, null },
                    { new Guid("86f57fa1-642e-49b4-ab2a-bebe24797c2d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "71-80", "Pre-launch Preparation", null, null },
                    { new Guid("a76d1fc4-0109-4ee8-b1db-03a8ed9455cd"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "81-90", "Pre-launch Preparation", null, null },
                    { new Guid("6c4d4e3b-8b09-4b97-a22a-10a052989aca"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "91-100", "Pre-launch Preparation", null, null },
                    { new Guid("121c53d3-f26d-4948-b807-993c8b4b877c"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 32m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "30-40", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("4faf7414-9c36-4979-99c7-f98a2b987565"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 32m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "41-50", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("2709422c-2582-4739-b36e-0e6b1148e7c3"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 32m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "51-60", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("d2b8c847-1135-4300-9405-34abba390157"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 33m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "61-70", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("fbb7a6e1-de44-4b0d-8a60-89f2f3c5f590"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 34m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "71-80", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("94492c30-191a-43f2-9c37-ac021313160b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "30-40", "Pre-launch Preparation", null, null },
                    { new Guid("da5e9e9b-2124-45cc-abd8-9f24964948aa"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "30-40", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("eda70a3c-0a7c-46bc-b30e-e5f5f74c691b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "91-100", "Pre-launch Preparation", null, null },
                    { new Guid("ec208fec-2d7c-408d-9336-15c2dccd1be1"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "81-90", "Pre-launch Preparation", null, null },
                    { new Guid("f4f66f16-6292-4344-a38b-ce163696d027"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 14m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "41-50", "Pre-lift Preparation", null, null },
                    { new Guid("0ea0177e-11da-4442-9167-df56cde62c4f"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 16m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "51-60", "Pre-lift Preparation", null, null },
                    { new Guid("2f32dc5a-0061-4dd6-aabc-688ccdd60c45"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 16m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "61-70", "Pre-lift Preparation", null, null },
                    { new Guid("e12dfbe2-5fda-45a7-a21d-d1568ae0ef6a"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 22m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "71-80", "Pre-lift Preparation", null, null },
                    { new Guid("12607e57-b0e3-4a6a-a274-294868d00810"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 22m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "81-90", "Pre-lift Preparation", null, null },
                    { new Guid("743842d3-02c9-49a3-8d6a-4a9ac096dcb2"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 25m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "91-100", "Pre-lift Preparation", null, null },
                    { new Guid("6fadc465-fb90-440c-b488-e9bc70ded8a2"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "30-40", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("596ca429-3c52-406b-8fe2-fefd4aef69cd"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "41-50", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("18c2df3a-40cd-4260-8b19-bceada13cc0d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "51-60", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("61214a27-db62-4ca7-bf28-798721b49543"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "61-70", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("327aa579-81bb-4d47-bef5-25f80585633b"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "71-80", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("e346fdd6-5065-4018-8990-0607b4474a2e"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "81-90", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("0d0558fa-22e5-49c1-ae49-bf69f38b7582"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 22m, false, new Guid("34594ee4-0ab5-4efa-8f7d-50398b952e12"), "91-100", "Jacket Lift, Flooding, Upending, Setting and Levelling", null, null }
                });

            migrationBuilder.InsertData(
                schema: "cost",
                table: "LeggedDuration",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "Duration", "IsDeleted", "LeggedId", "Length", "Method", "ModifiedByUserId", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("4a9384ad-061f-4ec8-90f0-8ced300f15a2"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 14m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "30-40", "Pre-lift Preparation", null, null },
                    { new Guid("6eb45751-4f8f-4dad-ae7a-93ff381d3ea3"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 14m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "41-50", "Pre-lift Preparation", null, null },
                    { new Guid("aadd8597-3cd5-43bc-967f-0b15233f116d"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 16m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "51-60", "Pre-lift Preparation", null, null },
                    { new Guid("b66bb972-b32d-4348-92ec-88c739030fb0"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 16m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "61-70", "Pre-lift Preparation", null, null },
                    { new Guid("1c235c46-fb3f-4f82-bb85-b1444c93466e"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 22m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "71-80", "Pre-lift Preparation", null, null },
                    { new Guid("f9b04108-e15c-4f8a-a46d-32897a66327e"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 22m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "81-90", "Pre-lift Preparation", null, null },
                    { new Guid("7336acbf-1f5b-4b95-aabb-5cd0001619a6"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 25m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "91-100", "Pre-lift Preparation", null, null },
                    { new Guid("ead1e7d1-6342-40db-aa53-9036f6444d09"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "30-40", "Pre-launch Preparation", null, null },
                    { new Guid("4d80081a-39c1-4ec7-b8bb-ddace631fd89"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "41-50", "Pre-launch Preparation", null, null },
                    { new Guid("48a5be0a-0a4d-4329-9f86-a6e65a198014"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "51-60", "Pre-launch Preparation", null, null },
                    { new Guid("fe44fc2f-ca5f-4868-a83e-f70c02194294"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "61-70", "Pre-launch Preparation", null, null },
                    { new Guid("26571181-aeaf-4d35-b571-f1e7513e02fb"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18m, false, new Guid("8039dee7-4180-41f2-8d07-63b3c6aeaf74"), "71-80", "Pre-launch Preparation", null, null },
                    { new Guid("0ccaa728-564c-4937-a783-b46fd6846068"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 34m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "81-90", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null },
                    { new Guid("97c16712-0385-476b-a5d2-870f40e782eb"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 34m, false, new Guid("3bcf4a61-9e65-495c-8dc5-7303eb284296"), "91-100", "Jacket Launch, Flooding, Upending, Setting and Levelling", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BargeDuration_CreatedByUserId",
                schema: "cost",
                table: "BargeDuration",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BargeDuration_DeletedByUserId",
                schema: "cost",
                table: "BargeDuration",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BargeDuration_ModifiedByUserId",
                schema: "cost",
                table: "BargeDuration",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallationMethod_CreatedByUserId",
                schema: "cost",
                table: "InstallationMethod",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallationMethod_DeletedByUserId",
                schema: "cost",
                table: "InstallationMethod",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallationMethod_ModifiedByUserId",
                schema: "cost",
                table: "InstallationMethod",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeggedDuration_CreatedByUserId",
                schema: "cost",
                table: "LeggedDuration",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeggedDuration_DeletedByUserId",
                schema: "cost",
                table: "LeggedDuration",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeggedDuration_LeggedId",
                schema: "cost",
                table: "LeggedDuration",
                column: "LeggedId");

            migrationBuilder.CreateIndex(
                name: "IX_LeggedDuration_ModifiedByUserId",
                schema: "cost",
                table: "LeggedDuration",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLegged_CreatedByUserId",
                schema: "cost",
                table: "MasterLegged",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLegged_DeletedByUserId",
                schema: "cost",
                table: "MasterLegged",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterLegged_ModifiedByUserId",
                schema: "cost",
                table: "MasterLegged",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BargeDuration",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "InstallationMethod",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "LeggedDuration",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterLegged",
                schema: "cost");
        }
    }
}
