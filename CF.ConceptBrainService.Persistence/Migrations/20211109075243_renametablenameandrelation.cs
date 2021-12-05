using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class renametablenameandrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptsDCDetails_Concepts_Id",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropTable(
                name: "BrainDrillingCenterData",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainEnviromental",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainFieldsData",
                schema: "concept");

            migrationBuilder.CreateTable(
                name: "DrillingCenterData",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydroCarbonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydroCarbonTypeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterDepth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaterDepthUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITHP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CITHPUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieInLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieInLocationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DistanceUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtificialLiftType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtificialLiftTypeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerRequirementPerWell = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PowerRequirementPerWellUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P10_OilProducerWell = table.Column<int>(type: "int", nullable: false),
                    P10_GasProducerWell = table.Column<int>(type: "int", nullable: false),
                    P10_WaterInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P10_GasInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P10_GasLiftWell = table.Column<int>(type: "int", nullable: false),
                    P10_PumpedWell = table.Column<int>(type: "int", nullable: false),
                    P50_OilProducerWell = table.Column<int>(type: "int", nullable: false),
                    P50_GasProducerWell = table.Column<int>(type: "int", nullable: false),
                    P50_WaterInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P50_GasInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P50_GasLiftWell = table.Column<int>(type: "int", nullable: false),
                    P50_PumpedWell = table.Column<int>(type: "int", nullable: false),
                    P90_OilProducerWell = table.Column<int>(type: "int", nullable: false),
                    P90_GasProducerWell = table.Column<int>(type: "int", nullable: false),
                    P90_WaterInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P90_GasInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P90_GasLiftWell = table.Column<int>(type: "int", nullable: false),
                    P90_PumpedWell = table.Column<int>(type: "int", nullable: false),
                    MinOil_CarbonDioxide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_CarbonDioxideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_HydrogenSulphide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_HydrogenSulphideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_Salt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_SaltUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_Mercaptan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_MercaptanUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_MercuryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_WAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_WATUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_Sand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_SandUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_ApiGravity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_ApiGravityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_CarbonDioxide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_CarbonDioxideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_HydrogenSulphide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_HydrogenSulphideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_Salt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_SaltUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_Mercaptan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_MercaptanUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_MercuryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_WAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_WATUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_Sand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_SandUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_ApiGravity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_ApiGravityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_CarbonDioxide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_CarbonDioxideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_HydrogenSulphide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinGas_HydrogenSulphideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_Mercaptan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinGas_MercaptanUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinGas_MercuryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_Sand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_SandUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_CarbonDioxide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_CarbonDioxideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_HydrogenSulphide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxGas_HydrogenSulphideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_Mercaptan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxGas_MercaptanUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxGas_MercuryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_Sand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_SandUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GORUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGRUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CGR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CGRUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WellTestRequirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WellTestRequirementUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DrillingCenterData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillingCenterData_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrillingCenterData_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrillingCenterData_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enviromental",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordinateLat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordinateLon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmbientTemperatureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmbientTemperatureMinUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmbientTemperatureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmbientTemperatureMaxUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeabedTemperatureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SeabedTemperatureMinUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeabedTemperatureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SeabedTemperatureMaxUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Enviromental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enviromental_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enviromental_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enviromental_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldsData",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HydrocacbornType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydrocacbornTypeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDriliingCenter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductStartYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionLife = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionLifeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbandonmentPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AbandonmentPressureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityWater = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterDisposalLocation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailabilityNAG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityNearbyField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableAmountOfGas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableAmountOfGasUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OperatingPressureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GasDisposalByReinjection = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_FieldsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldsData_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldsData_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldsData_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptsDCDetails_ConceptId",
                schema: "concept",
                table: "ConceptsDCDetails",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillingCenterData_CreatedByUserId",
                schema: "concept",
                table: "DrillingCenterData",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillingCenterData_DeletedByUserId",
                schema: "concept",
                table: "DrillingCenterData",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillingCenterData_ModifiedByUserId",
                schema: "concept",
                table: "DrillingCenterData",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enviromental_CreatedByUserId",
                schema: "concept",
                table: "Enviromental",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enviromental_DeletedByUserId",
                schema: "concept",
                table: "Enviromental",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enviromental_ModifiedByUserId",
                schema: "concept",
                table: "Enviromental",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsData_CreatedByUserId",
                schema: "concept",
                table: "FieldsData",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsData_DeletedByUserId",
                schema: "concept",
                table: "FieldsData",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsData_ModifiedByUserId",
                schema: "concept",
                table: "FieldsData",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptsDCDetails_Concepts_ConceptId",
                schema: "concept",
                table: "ConceptsDCDetails",
                column: "ConceptId",
                principalSchema: "concept",
                principalTable: "Concepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptsDCDetails_Concepts_ConceptId",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.DropTable(
                name: "DrillingCenterData",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "Enviromental",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "FieldsData",
                schema: "concept");

            migrationBuilder.DropIndex(
                name: "IX_ConceptsDCDetails_ConceptId",
                schema: "concept",
                table: "ConceptsDCDetails");

            migrationBuilder.CreateTable(
                name: "BrainDrillingCenterData",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtificialLiftType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtificialLiftTypeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CGR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CGRUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CITHP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CITHPUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DistanceUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GORUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydroCarbonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydroCarbonTypeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LGR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGRUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_CarbonDioxide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_CarbonDioxideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_HydrogenSulphide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxGas_HydrogenSulphideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_Mercaptan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxGas_MercaptanUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxGas_MercuryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_Sand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGas_SandUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_ApiGravity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_ApiGravityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_CarbonDioxide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_CarbonDioxideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_HydrogenSulphide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_HydrogenSulphideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_Mercaptan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_MercaptanUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_MercuryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_Salt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_SaltUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_Sand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_SandUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxOil_WAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxOil_WATUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_CarbonDioxide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_CarbonDioxideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_HydrogenSulphide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinGas_HydrogenSulphideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_Mercaptan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinGas_MercaptanUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinGas_MercuryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_Sand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinGas_SandUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_ApiGravity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_ApiGravityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_CarbonDioxide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_CarbonDioxideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_HydrogenSulphide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_HydrogenSulphideUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_Mercaptan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_MercaptanUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_MercuryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_Salt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_SaltUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_Sand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_SandUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOil_WAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOil_WATUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P10_GasInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P10_GasLiftWell = table.Column<int>(type: "int", nullable: false),
                    P10_GasProducerWell = table.Column<int>(type: "int", nullable: false),
                    P10_OilProducerWell = table.Column<int>(type: "int", nullable: false),
                    P10_PumpedWell = table.Column<int>(type: "int", nullable: false),
                    P10_WaterInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P50_GasInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P50_GasLiftWell = table.Column<int>(type: "int", nullable: false),
                    P50_GasProducerWell = table.Column<int>(type: "int", nullable: false),
                    P50_OilProducerWell = table.Column<int>(type: "int", nullable: false),
                    P50_PumpedWell = table.Column<int>(type: "int", nullable: false),
                    P50_WaterInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P90_GasInjectorWell = table.Column<int>(type: "int", nullable: false),
                    P90_GasLiftWell = table.Column<int>(type: "int", nullable: false),
                    P90_GasProducerWell = table.Column<int>(type: "int", nullable: false),
                    P90_OilProducerWell = table.Column<int>(type: "int", nullable: false),
                    P90_PumpedWell = table.Column<int>(type: "int", nullable: false),
                    P90_WaterInjectorWell = table.Column<int>(type: "int", nullable: false),
                    PowerRequirementPerWell = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PowerRequirementPerWellUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TieInLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieInLocationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterDepth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaterDepthUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WellTestRequirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WellTestRequirementUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainDrillingCenterData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainDrillingCenterData_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrainDrillingCenterData_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainDrillingCenterData_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainEnviromental",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmbientTemperatureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmbientTemperatureMaxUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmbientTemperatureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmbientTemperatureMinUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordinateLat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordinateLon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeabedTemperatureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SeabedTemperatureMaxUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeabedTemperatureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SeabedTemperatureMinUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainEnviromental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainEnviromental_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrainEnviromental_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainEnviromental_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainFieldsData",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbandonmentPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AbandonmentPressureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityNAG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityNearbyField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityWater = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableAmountOfGas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableAmountOfGasUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GasDisposalByReinjection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydrocacbornType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HydrocacbornTypeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfDriliingCenter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OperatingPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OperatingPressureUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductStartYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionLife = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionLifeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaterDisposalLocation = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainFieldsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainFieldsData_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrainFieldsData_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainFieldsData_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrainDrillingCenterData_CreatedByUserId",
                schema: "concept",
                table: "BrainDrillingCenterData",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainDrillingCenterData_DeletedByUserId",
                schema: "concept",
                table: "BrainDrillingCenterData",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainDrillingCenterData_ModifiedByUserId",
                schema: "concept",
                table: "BrainDrillingCenterData",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainEnviromental_CreatedByUserId",
                schema: "concept",
                table: "BrainEnviromental",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainEnviromental_DeletedByUserId",
                schema: "concept",
                table: "BrainEnviromental",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainEnviromental_ModifiedByUserId",
                schema: "concept",
                table: "BrainEnviromental",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainFieldsData_CreatedByUserId",
                schema: "concept",
                table: "BrainFieldsData",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainFieldsData_DeletedByUserId",
                schema: "concept",
                table: "BrainFieldsData",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainFieldsData_ModifiedByUserId",
                schema: "concept",
                table: "BrainFieldsData",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptsDCDetails_Concepts_Id",
                schema: "concept",
                table: "ConceptsDCDetails",
                column: "Id",
                principalSchema: "concept",
                principalTable: "Concepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
