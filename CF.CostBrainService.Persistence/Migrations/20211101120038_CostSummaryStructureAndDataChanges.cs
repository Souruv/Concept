using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class CostSummaryStructureAndDataChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7470e32c-232b-47c7-9b7f-0250389c2593"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("7d26c0c0-86f3-487f-80de-0b914e6381c5"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("bf51541a-d482-4dc9-a540-3d44fb51a010"));

            migrationBuilder.DropColumn(
                name: "InstallationName",
                schema: "cost",
                table: "PMTInstallation");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                schema: "cost",
                table: "ProjectLocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                schema: "cost",
                table: "PMTInstallation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                schema: "cost",
                table: "LeggedDuration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinLength",
                schema: "cost",
                table: "LeggedDuration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CostSummaryStructure",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LumpSum_RM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total_RM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDuration_Days = table.Column<int>(type: "int", nullable: true),
                    DCR_RM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_CostSummaryStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostSummaryStructure_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostSummaryStructure_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostSummaryStructure_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampaignDuration",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration_hrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_CampaignDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignDuration_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignDuration_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignDuration_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignDuration_CostSummaryStructure_CostSummaryId",
                        column: x => x.CostSummaryId,
                        principalSchema: "cost",
                        principalTable: "CostSummaryStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostSummarySubTotal",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostSummaryCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_CostSummarySubTotal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostSummarySubTotal_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostSummarySubTotal_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostSummarySubTotal_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostSummarySubTotal_CostSummaryStructure_CostSummaryId",
                        column: x => x.CostSummaryId,
                        principalSchema: "cost",
                        principalTable: "CostSummaryStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TICostCalculation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociatedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssociatedCost_Reduction = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalOptimization_OptionalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_TICostCalculation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TICostCalculation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TICostCalculation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TICostCalculation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TICostCalculation_CostSummaryStructure_CostSummaryId",
                        column: x => x.CostSummaryId,
                        principalSchema: "cost",
                        principalTable: "CostSummaryStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("0162a559-0170-459e-a362-269e4f08f4a4"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 90, 81 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("0ccaa728-564c-4937-a783-b46fd6846068"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 90, 81 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("0d0558fa-22e5-49c1-ae49-bf69f38b7582"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 100, 91 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("0ea0177e-11da-4442-9167-df56cde62c4f"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 60, 51 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("121c53d3-f26d-4948-b807-993c8b4b877c"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("12607e57-b0e3-4a6a-a274-294868d00810"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 90, 81 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("18c2df3a-40cd-4260-8b19-bceada13cc0d"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 60, 51 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("1c235c46-fb3f-4f82-bb85-b1444c93466e"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 80, 71 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("26571181-aeaf-4d35-b571-f1e7513e02fb"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 80, 71 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("2709422c-2582-4739-b36e-0e6b1148e7c3"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 60, 51 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("2f32dc5a-0061-4dd6-aabc-688ccdd60c45"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 70, 61 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("327aa579-81bb-4d47-bef5-25f80585633b"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 80, 71 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("3a375ad6-5fbf-4d49-b063-9fd227804431"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 60, 51 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("48a5be0a-0a4d-4329-9f86-a6e65a198014"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 60, 51 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("4a9384ad-061f-4ec8-90f0-8ced300f15a2"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("4d80081a-39c1-4ec7-b8bb-ddace631fd89"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 50, 41 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("4faf7414-9c36-4979-99c7-f98a2b987565"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 50, 41 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("50217f19-73cd-40dc-bd10-f162614107c4"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 50, 41 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("596ca429-3c52-406b-8fe2-fefd4aef69cd"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 50, 41 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("61214a27-db62-4ca7-bf28-798721b49543"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 70, 61 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("660c1436-3c72-4eac-af71-bf2ffecad409"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 80, 71 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("69307403-1599-4dc7-ab79-9d1bc0d20c7b"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("6c4d4e3b-8b09-4b97-a22a-10a052989aca"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 100, 91 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("6eb45751-4f8f-4dad-ae7a-93ff381d3ea3"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 50, 41 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("6fadc465-fb90-440c-b488-e9bc70ded8a2"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("7133f938-535e-4c1f-bb99-7c9a2ed43e92"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 70, 61 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("7336acbf-1f5b-4b95-aabb-5cd0001619a6"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 100, 91 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("743842d3-02c9-49a3-8d6a-4a9ac096dcb2"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 100, 91 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("86f57fa1-642e-49b4-ab2a-bebe24797c2d"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 80, 71 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("88b4829a-fcfe-45a4-beb9-29526bc5dfad"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 60, 51 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("94492c30-191a-43f2-9c37-ac021313160b"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("97c16712-0385-476b-a5d2-870f40e782eb"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 100, 91 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("a76d1fc4-0109-4ee8-b1db-03a8ed9455cd"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 90, 81 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("aadd8597-3cd5-43bc-967f-0b15233f116d"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 60, 51 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("ad61c2a2-6726-4908-8a9d-f15965c21a34"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 50, 41 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("b20be170-3b4d-4a3c-940b-e236dfd507bb"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 100, 91 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("b66bb972-b32d-4348-92ec-88c739030fb0"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 70, 61 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("bec9f857-53fa-4c48-8383-9d1183f0c48b"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 70, 61 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("c0c1bab8-18ce-4dbd-99c3-405dcb896f1d"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 100, 91 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("cc690dab-285c-4c13-9fcf-9fdd23239985"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 50, 41 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("cf46eb6a-d9b5-4db3-84bb-616ddadbc949"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 60, 51 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("d2b8c847-1135-4300-9405-34abba390157"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 70, 61 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("da5e9e9b-2124-45cc-abd8-9f24964948aa"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("dcc4de6e-26b4-4ceb-9fdd-49e18214e6c1"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 70, 61 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("e12dfbe2-5fda-45a7-a21d-d1568ae0ef6a"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 80, 71 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("e346fdd6-5065-4018-8990-0607b4474a2e"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 90, 81 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("ead1e7d1-6342-40db-aa53-9036f6444d09"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("ec208fec-2d7c-408d-9336-15c2dccd1be1"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 90, 81 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("eda70a3c-0a7c-46bc-b30e-e5f5f74c691b"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 100, 91 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("f4f66f16-6292-4344-a38b-ce163696d026"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("f4f66f16-6292-4344-a38b-ce163696d027"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 50, 41 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("f6540094-9cd3-4d68-9de8-0ac304a54856"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 80, 71 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("f75a9683-324d-4a53-a2c8-522a61b5a812"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 90, 81 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("f9b04108-e15c-4f8a-a46d-32897a66327e"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 90, 81 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("fbb7a6e1-de44-4b0d-8a60-89f2f3c5f590"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 80, 71 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "LeggedDuration",
                keyColumn: "Id",
                keyValue: new Guid("fe44fc2f-ca5f-4868-a83e-f70c02194294"),
                columns: new[] { "MaxLength", "MinLength" },
                values: new object[] { 70, 61 });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "PMTInstallation",
                keyColumn: "Id",
                keyValue: new Guid("8e00ea37-a8ce-4097-a195-b0f5cebc5b99"),
                column: "ProjectId",
                value: new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"));

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "PMTInstallation",
                keyColumn: "Id",
                keyValue: new Guid("98d6a1d7-759b-4595-886e-f158ab8a2ccb"),
                column: "ProjectId",
                value: new Guid("41190744-14be-4d22-90e7-6ccee5b45331"));

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "PMTInstallation",
                keyColumn: "Id",
                keyValue: new Guid("e490ca71-5dd0-418d-882f-eb357688fd26"),
                column: "ProjectId",
                value: new Guid("30a2f099-d265-4626-81e2-47c6d6d6e077"));

            migrationBuilder.InsertData(
                schema: "cost",
                table: "PMTInstallation",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "ProjectId", "TotalPMTCost" },
                values: new object[,]
                {
                    { new Guid("7c94af82-54fd-4668-8784-e1c26d65f175"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("91b1c2df-ac8e-4e8e-aa87-8bf2562b9d23"), 2m },
                    { new Guid("7a92c387-f071-4d21-b4fe-6f70d243b7ff"), new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("64fefefe-ca4b-4aa2-94b6-7176440da94d"), 1m }
                });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"),
                column: "Value",
                value: "SB");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"),
                column: "Value",
                value: "SK");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"),
                column: "Value",
                value: "PM");

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("eac5701f-18c9-4b1a-b7c1-b0da4774fd65"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "DEMOB", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("030aff6f-36b1-44c7-b015-10e2a815d8d9"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "INSTALLATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("5e7e6731-4268-4744-90bd-ee13cc2cec93"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "MOBILISATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("87a8a69d-89aa-49e1-9e0c-215d7b1041bd"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "TRANSPORTATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("da8db8e2-c461-4486-b6e8-ca2d8d5c28e9"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "INSTALLATION ENGINEERING", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("a1d2154e-746c-4198-bf64-9433c81b2ac1"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "DEMOB", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("9e73b755-f7da-4faa-96b5-8bc526b5deca"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "INSTALLATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("11fc6d5b-1809-4326-8d12-36f99325f3b2"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "MOBILISATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("898756ab-6bd2-4c2d-99b8-258ba7ef1e22"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "TRANSPORTATION", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m },
                    { new Guid("ff412b1c-25fc-4665-b3d5-1b8465bc46a1"), "FLOATOVER", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "INSTALLATION ENGINEERING", new Guid("41190744-14be-4d22-90e7-6ccee5b45331"), 1m, 5.20m, 1m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PMTInstallation_ProjectId",
                schema: "cost",
                table: "PMTInstallation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDuration_CostSummaryId",
                schema: "cost",
                table: "CampaignDuration",
                column: "CostSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDuration_CreatedByUserId",
                schema: "cost",
                table: "CampaignDuration",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDuration_DeletedByUserId",
                schema: "cost",
                table: "CampaignDuration",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDuration_ModifiedByUserId",
                schema: "cost",
                table: "CampaignDuration",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSummaryStructure_CreatedByUserId",
                schema: "cost",
                table: "CostSummaryStructure",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSummaryStructure_DeletedByUserId",
                schema: "cost",
                table: "CostSummaryStructure",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSummaryStructure_ModifiedByUserId",
                schema: "cost",
                table: "CostSummaryStructure",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSummarySubTotal_CostSummaryId",
                schema: "cost",
                table: "CostSummarySubTotal",
                column: "CostSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSummarySubTotal_CreatedByUserId",
                schema: "cost",
                table: "CostSummarySubTotal",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSummarySubTotal_DeletedByUserId",
                schema: "cost",
                table: "CostSummarySubTotal",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSummarySubTotal_ModifiedByUserId",
                schema: "cost",
                table: "CostSummarySubTotal",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculation_CostSummaryId",
                schema: "cost",
                table: "TICostCalculation",
                column: "CostSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculation_CreatedByUserId",
                schema: "cost",
                table: "TICostCalculation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculation_DeletedByUserId",
                schema: "cost",
                table: "TICostCalculation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculation_ModifiedByUserId",
                schema: "cost",
                table: "TICostCalculation",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PMTInstallation_ProjectType_ProjectId",
                schema: "cost",
                table: "PMTInstallation",
                column: "ProjectId",
                principalSchema: "cost",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PMTInstallation_ProjectType_ProjectId",
                schema: "cost",
                table: "PMTInstallation");

            migrationBuilder.DropTable(
                name: "CampaignDuration",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "CostSummarySubTotal",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "TICostCalculation",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "CostSummaryStructure",
                schema: "cost");

            migrationBuilder.DropIndex(
                name: "IX_PMTInstallation_ProjectId",
                schema: "cost",
                table: "PMTInstallation");

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "PMTInstallation",
                keyColumn: "Id",
                keyValue: new Guid("7a92c387-f071-4d21-b4fe-6f70d243b7ff"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "PMTInstallation",
                keyColumn: "Id",
                keyValue: new Guid("7c94af82-54fd-4668-8784-e1c26d65f175"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("030aff6f-36b1-44c7-b015-10e2a815d8d9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("11fc6d5b-1809-4326-8d12-36f99325f3b2"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("5e7e6731-4268-4744-90bd-ee13cc2cec93"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("87a8a69d-89aa-49e1-9e0c-215d7b1041bd"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("898756ab-6bd2-4c2d-99b8-258ba7ef1e22"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("9e73b755-f7da-4faa-96b5-8bc526b5deca"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("a1d2154e-746c-4198-bf64-9433c81b2ac1"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("da8db8e2-c461-4486-b6e8-ca2d8d5c28e9"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("eac5701f-18c9-4b1a-b7c1-b0da4774fd65"));

            migrationBuilder.DeleteData(
                schema: "cost",
                table: "UnitRate",
                keyColumn: "Id",
                keyValue: new Guid("ff412b1c-25fc-4665-b3d5-1b8465bc46a1"));

            migrationBuilder.DropColumn(
                name: "Value",
                schema: "cost",
                table: "ProjectLocation");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "cost",
                table: "PMTInstallation");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                schema: "cost",
                table: "LeggedDuration");

            migrationBuilder.DropColumn(
                name: "MinLength",
                schema: "cost",
                table: "LeggedDuration");

            migrationBuilder.AddColumn<string>(
                name: "InstallationName",
                schema: "cost",
                table: "PMTInstallation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "PMTInstallation",
                keyColumn: "Id",
                keyValue: new Guid("8e00ea37-a8ce-4097-a195-b0f5cebc5b99"),
                column: "InstallationName",
                value: "PMT Jacket Installation");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "PMTInstallation",
                keyColumn: "Id",
                keyValue: new Guid("98d6a1d7-759b-4595-886e-f158ab8a2ccb"),
                column: "InstallationName",
                value: "PMT Topside/Module Installation");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "PMTInstallation",
                keyColumn: "Id",
                keyValue: new Guid("e490ca71-5dd0-418d-882f-eb357688fd26"),
                column: "InstallationName",
                value: "PMT Platform Installation (Jacket + Topside/Module)");

            migrationBuilder.InsertData(
                schema: "cost",
                table: "UnitRate",
                columns: new[] { "Id", "Category", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "LocationId", "ModifiedByUserId", "ModifiedOn", "Name", "ProjectId", "RM", "RM_EQ", "USD" },
                values: new object[,]
                {
                    { new Guid("7d26c0c0-86f3-487f-80de-0b914e6381c5"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"), null, null, "Barge Class 280", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.40m, 2.00m },
                    { new Guid("7470e32c-232b-47c7-9b7f-0250389c2593"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"), null, null, "Barge Class 280", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.40m, 2.00m },
                    { new Guid("bf51541a-d482-4dc9-a540-3d44fb51a010"), "Transportation Mob+Demob", new Guid("69263077-35ff-4d1d-a74d-af9ec8792485"), new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"), null, null, "Barge Class 280", new Guid("d61ddb5e-4d06-489b-87e9-dc59847640e6"), 2.00m, 10.40m, 2.00m }
                });
        }
    }
}
