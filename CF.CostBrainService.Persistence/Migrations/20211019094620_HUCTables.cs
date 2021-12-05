using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class HUCTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefaultEquipmentToolsCons",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToolsAndEquip = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Consumables = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_DefaultEquipmentToolsCons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultEquipmentToolsCons_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultEquipmentToolsCons_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultEquipmentToolsCons_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultMarineSpreadAndOthers",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VesselType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QTYMOBDEMOB_Mob_Demob = table.Column<int>(type: "int", nullable: true),
                    MOBDEMOB_Per_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DailyCharacterRate_DCR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperationalCost_PerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDuration_Days = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_DefaultMarineSpreadAndOthers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultMarineSpreadAndOthers_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultMarineSpreadAndOthers_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultMarineSpreadAndOthers_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultMaterials",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfFlowLine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MYRFlowLine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Others = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_DefaultMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultMaterials_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultMaterials_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultMaterials_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultOthersFuelAndPW",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VesselType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortableWater_MT_Day = table.Column<int>(type: "int", nullable: true),
                    Fuel_LTR_DAY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_DefaultOthersFuelAndPW", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultOthersFuelAndPW_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultOthersFuelAndPW_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultOthersFuelAndPW_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultThirdPartyServicesSectionOne",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MOBANDDEMOB_RATE_RM_MOB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Equipment_Per_Set = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Technician_Per_Set = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_DefaultThirdPartyServicesSectionOne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionOne_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionOne_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionOne_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultThirdPartyServicesSectionThree",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No_Of_MOB_DEMOB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Duration_Days = table.Column<int>(type: "int", nullable: true),
                    No_Of_Set = table.Column<int>(type: "int", nullable: true),
                    No_Of_Pax = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_DefaultThirdPartyServicesSectionThree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionThree_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionThree_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionThree_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultThirdPartyServicesSectionTwo",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_DefaultThirdPartyServicesSectionTwo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionTwo_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionTwo_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultThirdPartyServicesSectionTwo_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterDaysFactorperMonth",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DaysFactorPerMonth = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_MasterDaysFactorperMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterDaysFactorperMonth_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterDaysFactorperMonth_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterDaysFactorperMonth_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterHUCFormula",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MasterHUCFormula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterHUCFormula_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterHUCFormula_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterHUCFormula_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterMarineSpreadOption",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MasterMarineSpreadOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterMarineSpreadOption_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterMarineSpreadOption_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterMarineSpreadOption_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterOffShoreAccomodation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MasterOffShoreAccomodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterOffShoreAccomodation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterOffShoreAccomodation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterOffShoreAccomodation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterPercentManPower",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_MasterPercentManPower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterPercentManPower_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterPercentManPower_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterPercentManPower_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterProjectType",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MasterProjectType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterProjectType_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterProjectType_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterProjectType_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterSchedule",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MasterSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterSchedule_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterSchedule_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterSchedule_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterSubSchedule",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_MasterSubSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterSubSchedule_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterSubSchedule_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterSubSchedule_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterTypicalManpower",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManPowerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MasterTypicalManpower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterTypicalManpower_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterTypicalManpower_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterTypicalManpower_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentToolsConsCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToolsAndEquip = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Consumables = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ManPowerPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MasterHUCFormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_EquipmentToolsConsCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentToolsConsCost_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentToolsConsCost_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentToolsConsCost_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentToolsConsCost_MasterHUCFormula_MasterHUCFormulaId",
                        column: x => x.MasterHUCFormulaId,
                        principalSchema: "cost",
                        principalTable: "MasterHUCFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentToolsConsCost_MasterProjectType_MasterProjectTypeId",
                        column: x => x.MasterProjectTypeId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentToolsConsCost_MasterSchedule_MasterScheduleId",
                        column: x => x.MasterScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HUCSummaryCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterHUCFormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_HUCSummaryCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HUCSummaryCost_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUCSummaryCost_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUCSummaryCost_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUCSummaryCost_MasterHUCFormula_MasterHUCFormulaId",
                        column: x => x.MasterHUCFormulaId,
                        principalSchema: "cost",
                        principalTable: "MasterHUCFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUCSummaryCost_MasterProjectType_MasterProjectTypeId",
                        column: x => x.MasterProjectTypeId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUCSummaryCost_MasterSchedule_MasterScheduleId",
                        column: x => x.MasterScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialsCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfFlowLine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MYRFlowLine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Others = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MasterScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterHUCFormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_MaterialsCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialsCost_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialsCost_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialsCost_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialsCost_MasterHUCFormula_MasterHUCFormulaId",
                        column: x => x.MasterHUCFormulaId,
                        principalSchema: "cost",
                        principalTable: "MasterHUCFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialsCost_MasterProjectType_MasterProjectTypeId",
                        column: x => x.MasterProjectTypeId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialsCost_MasterSchedule_MasterScheduleId",
                        column: x => x.MasterScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThirdPartyServicesSectionThreeCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No_Of_MOB_DEMOB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Duration_Days = table.Column<int>(type: "int", nullable: true),
                    No_Of_Set = table.Column<int>(type: "int", nullable: true),
                    No_Of_Pax = table.Column<int>(type: "int", nullable: true),
                    MasterScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterHUCFormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ThirdPartyServicesSectionThreeCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionThreeCost_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionThreeCost_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionThreeCost_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionThreeCost_MasterHUCFormula_MasterHUCFormulaId",
                        column: x => x.MasterHUCFormulaId,
                        principalSchema: "cost",
                        principalTable: "MasterHUCFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionThreeCost_MasterProjectType_MasterProjectTypeId",
                        column: x => x.MasterProjectTypeId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionThreeCost_MasterSchedule_MasterScheduleId",
                        column: x => x.MasterScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThirdPartyServicesSectionTwoCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MasterScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterHUCFormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ThirdPartyServicesSectionTwoCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionTwoCost_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionTwoCost_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionTwoCost_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionTwoCost_MasterHUCFormula_MasterHUCFormulaId",
                        column: x => x.MasterHUCFormulaId,
                        principalSchema: "cost",
                        principalTable: "MasterHUCFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionTwoCost_MasterProjectType_MasterProjectTypeId",
                        column: x => x.MasterProjectTypeId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyServicesSectionTwoCost_MasterSchedule_MasterScheduleId",
                        column: x => x.MasterScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypicalManpowerCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DaysFactorperMonthId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterOffShoreAccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DurationDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QTY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MANHOURS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RATE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MasterHUCFormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterDaysFactorperMonthId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_TypicalManpowerCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypicalManpowerCost_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypicalManpowerCost_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypicalManpowerCost_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypicalManpowerCost_MasterDaysFactorperMonth_MasterDaysFactorperMonthId",
                        column: x => x.MasterDaysFactorperMonthId,
                        principalSchema: "cost",
                        principalTable: "MasterDaysFactorperMonth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypicalManpowerCost_MasterHUCFormula_MasterHUCFormulaId",
                        column: x => x.MasterHUCFormulaId,
                        principalSchema: "cost",
                        principalTable: "MasterHUCFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypicalManpowerCost_MasterOffShoreAccomodation_MasterOffShoreAccomodationId",
                        column: x => x.MasterOffShoreAccomodationId,
                        principalSchema: "cost",
                        principalTable: "MasterOffShoreAccomodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypicalManpowerCost_MasterProjectType_MasterProjectTypeId",
                        column: x => x.MasterProjectTypeId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypicalManpowerCost_MasterSchedule_MasterScheduleId",
                        column: x => x.MasterScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuelAndPWCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VesselType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortableWater_MT_Day = table.Column<int>(type: "int", nullable: true),
                    Fuel_LTR_DAY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MasterHUCFormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterSubScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_FuelAndPWCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelAndPWCost_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuelAndPWCost_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuelAndPWCost_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuelAndPWCost_MasterHUCFormula_MasterHUCFormulaId",
                        column: x => x.MasterHUCFormulaId,
                        principalSchema: "cost",
                        principalTable: "MasterHUCFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuelAndPWCost_MasterProjectType_MasterProjectTypeId",
                        column: x => x.MasterProjectTypeId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuelAndPWCost_MasterSchedule_MasterScheduleId",
                        column: x => x.MasterScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuelAndPWCost_MasterSubSchedule_MasterSubScheduleId",
                        column: x => x.MasterSubScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSubSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarineSpreadCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VesselType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QTYMOBDEMOB_Mob_Demob = table.Column<int>(type: "int", nullable: true),
                    MOBDEMOB_Per_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DailyCharacterRate_DCR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperationalCost_PerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDuration_Days = table.Column<int>(type: "int", nullable: true),
                    MasterScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterSubScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MasterHUCFormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AssumptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_MarineSpreadCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarineSpreadCost_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarineSpreadCost_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarineSpreadCost_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarineSpreadCost_MasterHUCFormula_MasterHUCFormulaId",
                        column: x => x.MasterHUCFormulaId,
                        principalSchema: "cost",
                        principalTable: "MasterHUCFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarineSpreadCost_MasterProjectType_MasterProjectTypeId",
                        column: x => x.MasterProjectTypeId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarineSpreadCost_MasterSchedule_MasterScheduleId",
                        column: x => x.MasterScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarineSpreadCost_MasterSubSchedule_MasterSubScheduleId",
                        column: x => x.MasterSubScheduleId,
                        principalSchema: "cost",
                        principalTable: "MasterSubSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultManpower",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterTypicalManpowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectTypeMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Duration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OFFSHOREACCOMODATION = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DefaultManpower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultManpower_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultManpower_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultManpower_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultManpower_MasterProjectType_ProjectTypeMasterId",
                        column: x => x.ProjectTypeMasterId,
                        principalSchema: "cost",
                        principalTable: "MasterProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultManpower_MasterTypicalManpower_MasterTypicalManpowerId",
                        column: x => x.MasterTypicalManpowerId,
                        principalSchema: "cost",
                        principalTable: "MasterTypicalManpower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultManpowerFixedValues",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterTypicalManpowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MANHOURS = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_DefaultManpowerFixedValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultManpowerFixedValues_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultManpowerFixedValues_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultManpowerFixedValues_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultManpowerFixedValues_MasterTypicalManpower_MasterTypicalManpowerId",
                        column: x => x.MasterTypicalManpowerId,
                        principalSchema: "cost",
                        principalTable: "MasterTypicalManpower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultEquipmentToolsCons_CreatedByUserId",
                schema: "cost",
                table: "DefaultEquipmentToolsCons",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultEquipmentToolsCons_DeletedByUserId",
                schema: "cost",
                table: "DefaultEquipmentToolsCons",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultEquipmentToolsCons_ModifiedByUserId",
                schema: "cost",
                table: "DefaultEquipmentToolsCons",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpower_CreatedByUserId",
                schema: "cost",
                table: "DefaultManpower",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpower_DeletedByUserId",
                schema: "cost",
                table: "DefaultManpower",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpower_MasterTypicalManpowerId",
                schema: "cost",
                table: "DefaultManpower",
                column: "MasterTypicalManpowerId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpower_ModifiedByUserId",
                schema: "cost",
                table: "DefaultManpower",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpower_ProjectTypeMasterId",
                schema: "cost",
                table: "DefaultManpower",
                column: "ProjectTypeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpowerFixedValues_CreatedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpowerFixedValues_DeletedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpowerFixedValues_MasterTypicalManpowerId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "MasterTypicalManpowerId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpowerFixedValues_ModifiedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMarineSpreadAndOthers_CreatedByUserId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMarineSpreadAndOthers_DeletedByUserId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMarineSpreadAndOthers_ModifiedByUserId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMaterials_CreatedByUserId",
                schema: "cost",
                table: "DefaultMaterials",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMaterials_DeletedByUserId",
                schema: "cost",
                table: "DefaultMaterials",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMaterials_ModifiedByUserId",
                schema: "cost",
                table: "DefaultMaterials",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultOthersFuelAndPW_CreatedByUserId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultOthersFuelAndPW_DeletedByUserId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultOthersFuelAndPW_ModifiedByUserId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionOne_CreatedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionOne_DeletedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionOne_ModifiedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionThree_CreatedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionThree",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionThree_DeletedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionThree",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionThree_ModifiedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionThree",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionTwo_CreatedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionTwo",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionTwo_DeletedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionTwo",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionTwo_ModifiedByUserId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionTwo",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToolsConsCost_CreatedByUserId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToolsConsCost_DeletedByUserId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToolsConsCost_MasterHUCFormulaId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToolsConsCost_MasterProjectTypeId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToolsConsCost_MasterScheduleId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToolsConsCost_ModifiedByUserId",
                schema: "cost",
                table: "EquipmentToolsConsCost",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_CreatedByUserId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_DeletedByUserId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_MasterHUCFormulaId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_MasterProjectTypeId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_MasterScheduleId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_MasterSubScheduleId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "MasterSubScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAndPWCost_ModifiedByUserId",
                schema: "cost",
                table: "FuelAndPWCost",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HUCSummaryCost_CreatedByUserId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HUCSummaryCost_DeletedByUserId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HUCSummaryCost_MasterHUCFormulaId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_HUCSummaryCost_MasterProjectTypeId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HUCSummaryCost_MasterScheduleId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_HUCSummaryCost_ModifiedByUserId",
                schema: "cost",
                table: "HUCSummaryCost",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_CreatedByUserId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_DeletedByUserId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_MasterHUCFormulaId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_MasterProjectTypeId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_MasterScheduleId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_MasterSubScheduleId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "MasterSubScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MarineSpreadCost_ModifiedByUserId",
                schema: "cost",
                table: "MarineSpreadCost",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDaysFactorperMonth_CreatedByUserId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDaysFactorperMonth_DeletedByUserId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDaysFactorperMonth_ModifiedByUserId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterHUCFormula_CreatedByUserId",
                schema: "cost",
                table: "MasterHUCFormula",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterHUCFormula_DeletedByUserId",
                schema: "cost",
                table: "MasterHUCFormula",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterHUCFormula_ModifiedByUserId",
                schema: "cost",
                table: "MasterHUCFormula",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterMarineSpreadOption_CreatedByUserId",
                schema: "cost",
                table: "MasterMarineSpreadOption",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterMarineSpreadOption_DeletedByUserId",
                schema: "cost",
                table: "MasterMarineSpreadOption",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterMarineSpreadOption_ModifiedByUserId",
                schema: "cost",
                table: "MasterMarineSpreadOption",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterOffShoreAccomodation_CreatedByUserId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterOffShoreAccomodation_DeletedByUserId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterOffShoreAccomodation_ModifiedByUserId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPercentManPower_CreatedByUserId",
                schema: "cost",
                table: "MasterPercentManPower",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPercentManPower_DeletedByUserId",
                schema: "cost",
                table: "MasterPercentManPower",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterPercentManPower_ModifiedByUserId",
                schema: "cost",
                table: "MasterPercentManPower",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterProjectType_CreatedByUserId",
                schema: "cost",
                table: "MasterProjectType",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterProjectType_DeletedByUserId",
                schema: "cost",
                table: "MasterProjectType",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterProjectType_ModifiedByUserId",
                schema: "cost",
                table: "MasterProjectType",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSchedule_CreatedByUserId",
                schema: "cost",
                table: "MasterSchedule",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSchedule_DeletedByUserId",
                schema: "cost",
                table: "MasterSchedule",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSchedule_ModifiedByUserId",
                schema: "cost",
                table: "MasterSchedule",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSubSchedule_CreatedByUserId",
                schema: "cost",
                table: "MasterSubSchedule",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSubSchedule_DeletedByUserId",
                schema: "cost",
                table: "MasterSubSchedule",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSubSchedule_ModifiedByUserId",
                schema: "cost",
                table: "MasterSubSchedule",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTypicalManpower_CreatedByUserId",
                schema: "cost",
                table: "MasterTypicalManpower",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTypicalManpower_DeletedByUserId",
                schema: "cost",
                table: "MasterTypicalManpower",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTypicalManpower_ModifiedByUserId",
                schema: "cost",
                table: "MasterTypicalManpower",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsCost_CreatedByUserId",
                schema: "cost",
                table: "MaterialsCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsCost_DeletedByUserId",
                schema: "cost",
                table: "MaterialsCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsCost_MasterHUCFormulaId",
                schema: "cost",
                table: "MaterialsCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsCost_MasterProjectTypeId",
                schema: "cost",
                table: "MaterialsCost",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsCost_MasterScheduleId",
                schema: "cost",
                table: "MaterialsCost",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsCost_ModifiedByUserId",
                schema: "cost",
                table: "MaterialsCost",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_CreatedByUserId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_DeletedByUserId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_MasterProjectTypeId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_MasterScheduleId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionThreeCost_ModifiedByUserId",
                schema: "cost",
                table: "ThirdPartyServicesSectionThreeCost",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_CreatedByUserId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_DeletedByUserId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_MasterHUCFormulaId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_MasterProjectTypeId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_MasterScheduleId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyServicesSectionTwoCost_ModifiedByUserId",
                schema: "cost",
                table: "ThirdPartyServicesSectionTwoCost",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_CreatedByUserId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_DeletedByUserId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_MasterDaysFactorperMonthId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterDaysFactorperMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_MasterHUCFormulaId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterHUCFormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_MasterOffShoreAccomodationId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterOffShoreAccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_MasterProjectTypeId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_MasterScheduleId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TypicalManpowerCost_ModifiedByUserId",
                schema: "cost",
                table: "TypicalManpowerCost",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultEquipmentToolsCons",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "DefaultManpower",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "DefaultManpowerFixedValues",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "DefaultMarineSpreadAndOthers",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "DefaultMaterials",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "DefaultOthersFuelAndPW",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "DefaultThirdPartyServicesSectionOne",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "DefaultThirdPartyServicesSectionThree",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "DefaultThirdPartyServicesSectionTwo",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "EquipmentToolsConsCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "FuelAndPWCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "HUCSummaryCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MarineSpreadCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterMarineSpreadOption",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterPercentManPower",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MaterialsCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "ThirdPartyServicesSectionThreeCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "ThirdPartyServicesSectionTwoCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "TypicalManpowerCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterTypicalManpower",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterSubSchedule",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterDaysFactorperMonth",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterHUCFormula",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterOffShoreAccomodation",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterProjectType",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterSchedule",
                schema: "cost");
        }
    }
}
