using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class Tablesforexpressions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrainAccommodation",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessingScheme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Accommodation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_BrainAccommodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainAccommodation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainAccommodation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainAccommodation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainCondensateHandling",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessingScheme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EvacuationScheme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CondensateExport = table.Column<bool>(type: "bit", nullable: true),
                    HcDewpoint = table.Column<bool>(type: "bit", nullable: true),
                    CondensateProcessing = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProcessText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessIds = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PipeLine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_BrainCondensateHandling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainCondensateHandling_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainCondensateHandling_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainCondensateHandling_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainDrillingAndWorkoverStrategy",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WaterDepthMin = table.Column<int>(type: "int", nullable: false),
                    WaterDepthMax = table.Column<int>(type: "int", nullable: false),
                    Strategy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_BrainDrillingAndWorkoverStrategy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainDrillingAndWorkoverStrategy_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainDrillingAndWorkoverStrategy_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainDrillingAndWorkoverStrategy_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainExternalWaterInjection",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PwtLessThanInjection = table.Column<bool>(type: "bit", nullable: false),
                    ExternalWaterInjection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProcessIds = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Pipeline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_BrainExternalWaterInjection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainExternalWaterInjection_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainExternalWaterInjection_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainExternalWaterInjection_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainGasContaminantMgmt",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FeedCo2Max = table.Column<int>(type: "int", nullable: true),
                    FeedCo2Min = table.Column<int>(type: "int", nullable: true),
                    ExportCo2Max = table.Column<int>(type: "int", nullable: true),
                    ExportCo2Min = table.Column<int>(type: "int", nullable: true),
                    CondensateProcessing = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Process = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PipeLine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_BrainGasContaminantMgmt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainGasContaminantMgmt_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainGasContaminantMgmt_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainGasContaminantMgmt_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainGasDisposal",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HydrocarbonType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlowrateGreaterThanGasInjectionPlusLift = table.Column<bool>(type: "bit", nullable: true),
                    GasDisposalReinjection = table.Column<bool>(type: "bit", nullable: true),
                    GasDisposal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Process = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Pipeline = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_BrainGasDisposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainGasDisposal_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainGasDisposal_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainGasDisposal_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainGasExport",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HydrocarbonType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FlowrateGreaterThanGasInjectionPlusLift = table.Column<bool>(type: "bit", nullable: true),
                    HCDewpoint = table.Column<bool>(type: "bit", nullable: true),
                    WaterContentDewpoint = table.Column<bool>(type: "bit", nullable: true),
                    GasExport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProcessIds = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Pipeline = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_BrainGasExport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainGasExport_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainGasExport_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainGasExport_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainGasInjection",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HydrocarbonType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InjectionLiftGreaterThanZero = table.Column<bool>(type: "bit", nullable: true),
                    FlowrateGreaterThanGasInjectionPlusLift = table.Column<bool>(type: "bit", nullable: true),
                    NAGReservoir = table.Column<bool>(type: "bit", nullable: true),
                    NAGSeparateTrain = table.Column<bool>(type: "bit", nullable: true),
                    NAGPressureGreaterThanInjectionAndLiftPressure = table.Column<bool>(type: "bit", nullable: true),
                    NearByGasField = table.Column<bool>(type: "bit", nullable: true),
                    NearByGasFieldProcessed = table.Column<bool>(type: "bit", nullable: true),
                    NearByPressureGreaterThanInectionAndLiftPressure = table.Column<bool>(type: "bit", nullable: true),
                    GasInjection = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProcessIds = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Pipeline = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_BrainGasInjection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainGasInjection_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainGasInjection_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainGasInjection_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainOilHandling",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessingScheme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EvacuationScheme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Desalting = table.Column<bool>(type: "bit", nullable: true),
                    H2SRemoval = table.Column<bool>(type: "bit", nullable: true),
                    OilProcessing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProcessText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProcessIds = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Pipeline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_BrainOilHandling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainOilHandling_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainOilHandling_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainOilHandling_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainPressureProtection",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CithpMin = table.Column<float>(type: "real", nullable: true),
                    Pressureprotection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_BrainPressureProtection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainPressureProtection_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainPressureProtection_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainPressureProtection_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainPWTInjection",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PWTGreaterThanZero = table.Column<bool>(type: "bit", nullable: false),
                    InjectionRequiredGreaterThanZero = table.Column<bool>(type: "bit", nullable: false),
                    PwtInjection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProcessIds = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Pipeline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_BrainPWTInjection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainPWTInjection_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainPWTInjection_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainPWTInjection_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainSubstructure",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TreeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoOfConductorsMax = table.Column<int>(type: "int", nullable: true),
                    NoOfConductorsMin = table.Column<int>(type: "int", nullable: true),
                    WaterDepthMax = table.Column<int>(type: "int", nullable: true),
                    WaterDepthMin = table.Column<int>(type: "int", nullable: true),
                    TopsideWeightMax = table.Column<int>(type: "int", nullable: true),
                    TopsideWeightMin = table.Column<int>(type: "int", nullable: true),
                    ProcessingScheme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubStructureType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_BrainSubstructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainSubstructure_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainSubstructure_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainSubstructure_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainWaterDisposal",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailabilityOfDisposalReservoir = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PwtGreaterThanWif = table.Column<bool>(type: "bit", nullable: true),
                    WaterDisposal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProcessIds = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pipeline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_BrainWaterDisposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainWaterDisposal_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainWaterDisposal_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainWaterDisposal_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrainAccommodation_CreatedByUserId",
                schema: "concept",
                table: "BrainAccommodation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainAccommodation_DeletedByUserId",
                schema: "concept",
                table: "BrainAccommodation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainAccommodation_ModifiedByUserId",
                schema: "concept",
                table: "BrainAccommodation",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainCondensateHandling_CreatedByUserId",
                schema: "concept",
                table: "BrainCondensateHandling",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainCondensateHandling_DeletedByUserId",
                schema: "concept",
                table: "BrainCondensateHandling",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainCondensateHandling_ModifiedByUserId",
                schema: "concept",
                table: "BrainCondensateHandling",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainDrillingAndWorkoverStrategy_CreatedByUserId",
                schema: "concept",
                table: "BrainDrillingAndWorkoverStrategy",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainDrillingAndWorkoverStrategy_DeletedByUserId",
                schema: "concept",
                table: "BrainDrillingAndWorkoverStrategy",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainDrillingAndWorkoverStrategy_ModifiedByUserId",
                schema: "concept",
                table: "BrainDrillingAndWorkoverStrategy",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainExternalWaterInjection_CreatedByUserId",
                schema: "concept",
                table: "BrainExternalWaterInjection",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainExternalWaterInjection_DeletedByUserId",
                schema: "concept",
                table: "BrainExternalWaterInjection",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainExternalWaterInjection_ModifiedByUserId",
                schema: "concept",
                table: "BrainExternalWaterInjection",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasContaminantMgmt_CreatedByUserId",
                schema: "concept",
                table: "BrainGasContaminantMgmt",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasContaminantMgmt_DeletedByUserId",
                schema: "concept",
                table: "BrainGasContaminantMgmt",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasContaminantMgmt_ModifiedByUserId",
                schema: "concept",
                table: "BrainGasContaminantMgmt",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasDisposal_CreatedByUserId",
                schema: "concept",
                table: "BrainGasDisposal",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasDisposal_DeletedByUserId",
                schema: "concept",
                table: "BrainGasDisposal",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasDisposal_ModifiedByUserId",
                schema: "concept",
                table: "BrainGasDisposal",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasExport_CreatedByUserId",
                schema: "concept",
                table: "BrainGasExport",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasExport_DeletedByUserId",
                schema: "concept",
                table: "BrainGasExport",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasExport_ModifiedByUserId",
                schema: "concept",
                table: "BrainGasExport",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasInjection_CreatedByUserId",
                schema: "concept",
                table: "BrainGasInjection",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasInjection_DeletedByUserId",
                schema: "concept",
                table: "BrainGasInjection",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainGasInjection_ModifiedByUserId",
                schema: "concept",
                table: "BrainGasInjection",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainOilHandling_CreatedByUserId",
                schema: "concept",
                table: "BrainOilHandling",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainOilHandling_DeletedByUserId",
                schema: "concept",
                table: "BrainOilHandling",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainOilHandling_ModifiedByUserId",
                schema: "concept",
                table: "BrainOilHandling",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainPressureProtection_CreatedByUserId",
                schema: "concept",
                table: "BrainPressureProtection",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainPressureProtection_DeletedByUserId",
                schema: "concept",
                table: "BrainPressureProtection",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainPressureProtection_ModifiedByUserId",
                schema: "concept",
                table: "BrainPressureProtection",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainPWTInjection_CreatedByUserId",
                schema: "concept",
                table: "BrainPWTInjection",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainPWTInjection_DeletedByUserId",
                schema: "concept",
                table: "BrainPWTInjection",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainPWTInjection_ModifiedByUserId",
                schema: "concept",
                table: "BrainPWTInjection",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainSubstructure_CreatedByUserId",
                schema: "concept",
                table: "BrainSubstructure",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainSubstructure_DeletedByUserId",
                schema: "concept",
                table: "BrainSubstructure",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainSubstructure_ModifiedByUserId",
                schema: "concept",
                table: "BrainSubstructure",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainWaterDisposal_CreatedByUserId",
                schema: "concept",
                table: "BrainWaterDisposal",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainWaterDisposal_DeletedByUserId",
                schema: "concept",
                table: "BrainWaterDisposal",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainWaterDisposal_ModifiedByUserId",
                schema: "concept",
                table: "BrainWaterDisposal",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrainAccommodation",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainCondensateHandling",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainDrillingAndWorkoverStrategy",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainExternalWaterInjection",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainGasContaminantMgmt",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainGasDisposal",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainGasExport",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainGasInjection",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainOilHandling",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainPressureProtection",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainPWTInjection",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainSubstructure",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainWaterDisposal",
                schema: "concept");
        }
    }
}
