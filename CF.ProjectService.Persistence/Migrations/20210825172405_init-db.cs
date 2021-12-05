using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "prj");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserPrincipal = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
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
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCraAccuracyExpression",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Curve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimateClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LookUpCraAccuracyExpression", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpCraAccuracyExpression_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookUpCraAccuracyExpression_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookUpCraAccuracyExpression_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCraContingencyExpression",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Curve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimateClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LookUpCraContingencyExpression", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpCraContingencyExpression_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookUpCraContingencyExpression_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookUpCraContingencyExpression_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCraPdfXValue",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositiveAccurary = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LookUpCraPdfXValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpCraPdfXValue_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookUpCraPdfXValue_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookUpCraPdfXValue_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCraPdfYValue",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositiveAccurary = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LookUpCraPdfYValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpCraPdfYValue_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookUpCraPdfYValue_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookUpCraPdfYValue_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCraSCurveValue",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositiveAccurary = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LookUpCraSCurveValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpCraSCurveValue_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookUpCraSCurveValue_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookUpCraSCurveValue_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectNatures",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ProjectNatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectNatures_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectNatures_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectNatures_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Pid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastRevisionNo = table.Column<int>(type: "int", nullable: true),
                    LastRevisionStatus = table.Column<int>(type: "int", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestDeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastSubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastSubmittedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AppUsers_LastSubmittedBy",
                        column: x => x.LastSubmittedBy,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStages",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ProjectStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectStages_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectStages_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectStages_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpstreamMetricColumn",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CFColumnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SPColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SPSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_UpstreamMetricColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpstreamMetricColumn_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpstreamMetricColumn_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpstreamMetricColumn_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UTCCosts",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaterDepthGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterDepthMin = table.Column<int>(type: "int", nullable: true),
                    WaterDepthMax = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Utc = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_UTCCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UTCCosts_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UTCCosts_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UTCCosts_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UTCCosts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "prj",
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectNatureDetails",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectNatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ProjectNatureDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectNatureDetails_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectNatureDetails_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectNatureDetails_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectNatureDetails_ProjectNatures_ProjectNatureId",
                        column: x => x.ProjectNatureId,
                        principalSchema: "prj",
                        principalTable: "ProjectNatures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectNatureDetails_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "prj",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectUsers",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ProjectUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "prj",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectRevisions",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionNo = table.Column<int>(type: "int", nullable: false),
                    ProjectStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionStatus = table.Column<int>(type: "int", nullable: false),
                    ExpecedFirstResponseBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiecRequestNUmber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespondedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RespondedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespondedRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAcknowledged = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ProjectRevisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectRevisions_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRevisions_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRevisions_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRevisions_AppUsers_RespondedByUserId",
                        column: x => x.RespondedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRevisions_AppUsers_SubmittedByUserId",
                        column: x => x.SubmittedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectRevisions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "prj",
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectRevisions_ProjectStages_ProjectStageId",
                        column: x => x.ProjectStageId,
                        principalSchema: "prj",
                        principalTable: "ProjectStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrillingCenters",
                schema: "prj",
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
                    table.PrimaryKey("PK_DrillingCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillingCenters_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrillingCenters_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrillingCenters_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrillingCenters_ProjectRevisions_ProjectRevisionId",
                        column: x => x.ProjectRevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enviromentals",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coordinate = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Enviromentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enviromentals_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enviromentals_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enviromentals_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enviromentals_ProjectRevisions_ProjectRevisionId",
                        column: x => x.ProjectRevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FieldsDatas",
                schema: "prj",
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
                    table.PrimaryKey("PK_FieldsDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldsDatas_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldsDatas_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldsDatas_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldsDatas_ProjectRevisions_ProjectRevisionId",
                        column: x => x.ProjectRevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureDatas",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_InfrastructureDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureDatas_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfrastructureDatas_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfrastructureDatas_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfrastructureDatas_ProjectRevisions_ProjectRevisionId",
                        column: x => x.ProjectRevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RevisionTeamMember",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_RevisionTeamMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevisionTeamMember_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RevisionTeamMember_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RevisionTeamMember_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RevisionTeamMember_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RevisionTeamMember_ProjectRevisions_ProjectRevisionId",
                        column: x => x.ProjectRevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RevisionTeamMember_ProjectRevisions_RevisionId",
                        column: x => x.RevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoeInputP10",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OilRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateAGMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateAGMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateOilMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateOilMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHPMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHPMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHTMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHTMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateNAGMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateNAGMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CondensateRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CondensateRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateGasMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateGasMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHPMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHPMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHTMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHTMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DrillingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoeInputP10", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoeInputP10_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP10_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP10_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP10_DrillingCenters_DrillingCenterId",
                        column: x => x.DrillingCenterId,
                        principalSchema: "prj",
                        principalTable: "DrillingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoeInputP50",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OilRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateAGMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateAGMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateOilMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateOilMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHPMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHPMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHTMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHTMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateNAGMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateNAGMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CondensateRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CondensateRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateGasMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateGasMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHPMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHPMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHTMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHTMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DrillingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoeInputP50", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoeInputP50_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP50_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP50_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP50_DrillingCenters_DrillingCenterId",
                        column: x => x.DrillingCenterId,
                        principalSchema: "prj",
                        principalTable: "DrillingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoeInputP90",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OilRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateAGMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateAGMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateOilMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateOilMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHPMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHPMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHTMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilFTHTMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateNAGMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasRateNAGMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CondensateRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CondensateRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateGasMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterRateGasMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHPMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHPMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHTMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasFTHTMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaterInjectionPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasInjectionPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftPressureMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GasLiftPressureMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DrillingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoeInputP90", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoeInputP90_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP90_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP90_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoeInputP90_DrillingCenters_DrillingCenterId",
                        column: x => x.DrillingCenterId,
                        principalSchema: "prj",
                        principalTable: "DrillingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EvacuationOption",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InfrastructureDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterContent = table.Column<int>(type: "int", nullable: true),
                    MaxCo2 = table.Column<int>(type: "int", nullable: true),
                    MaxH2S = table.Column<int>(type: "int", nullable: true),
                    Salt = table.Column<int>(type: "int", nullable: true),
                    VapourPressure = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_EvacuationOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvacuationOption_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvacuationOption_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationOption_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationOption_InfrastructureDatas_InfrastructureDataId",
                        column: x => x.InfrastructureDataId,
                        principalSchema: "prj",
                        principalTable: "InfrastructureDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "prj",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "DepartmentName", "Email", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name", "Role", "UserPrincipal" },
                values: new object[] { new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "admin", "admin", false, null, null, "ConceptorAdmin", 1, "admin" });

            migrationBuilder.InsertData(
                schema: "prj",
                table: "ProjectNatures",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Nature" },
                values: new object[,]
                {
                    { new Guid("fa5bb7f8-868b-4c91-a7b9-c6d343c30450"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Greenfield" },
                    { new Guid("fb5ab810-17fa-4511-be99-5b7bcfdf4d03"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Infill" },
                    { new Guid("e523a4d3-4c16-4310-8060-21b54bcdd173"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Brownfield" }
                });

            migrationBuilder.InsertData(
                schema: "prj",
                table: "ProjectStages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Stage" },
                values: new object[,]
                {
                    { new Guid("eaa4148f-034c-486c-b8be-c93bacf7307f"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Pre-FEL" },
                    { new Guid("270a7711-e19e-4a13-9f77-352d14e57850"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL1" },
                    { new Guid("dc46e5db-82bf-4064-897b-17fc4099b8cb"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL2" },
                    { new Guid("99e346e9-13fb-488b-a5ad-7569e443e03e"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEL3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CreatedByUserId",
                schema: "prj",
                table: "AppUsers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DeletedByUserId",
                schema: "prj",
                table: "AppUsers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_ModifiedByUserId",
                schema: "prj",
                table: "AppUsers",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP10_CreatedByUserId",
                schema: "prj",
                table: "CoeInputP10",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP10_DeletedByUserId",
                schema: "prj",
                table: "CoeInputP10",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP10_DrillingCenterId",
                schema: "prj",
                table: "CoeInputP10",
                column: "DrillingCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP10_ModifiedByUserId",
                schema: "prj",
                table: "CoeInputP10",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP50_CreatedByUserId",
                schema: "prj",
                table: "CoeInputP50",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP50_DeletedByUserId",
                schema: "prj",
                table: "CoeInputP50",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP50_DrillingCenterId",
                schema: "prj",
                table: "CoeInputP50",
                column: "DrillingCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP50_ModifiedByUserId",
                schema: "prj",
                table: "CoeInputP50",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP90_CreatedByUserId",
                schema: "prj",
                table: "CoeInputP90",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP90_DeletedByUserId",
                schema: "prj",
                table: "CoeInputP90",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP90_DrillingCenterId",
                schema: "prj",
                table: "CoeInputP90",
                column: "DrillingCenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoeInputP90_ModifiedByUserId",
                schema: "prj",
                table: "CoeInputP90",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedByUserId",
                schema: "prj",
                table: "Countries",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_DeletedByUserId",
                schema: "prj",
                table: "Countries",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ModifiedByUserId",
                schema: "prj",
                table: "Countries",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillingCenters_CreatedByUserId",
                schema: "prj",
                table: "DrillingCenters",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillingCenters_DeletedByUserId",
                schema: "prj",
                table: "DrillingCenters",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillingCenters_ModifiedByUserId",
                schema: "prj",
                table: "DrillingCenters",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillingCenters_ProjectRevisionId",
                schema: "prj",
                table: "DrillingCenters",
                column: "ProjectRevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Enviromentals_CreatedByUserId",
                schema: "prj",
                table: "Enviromentals",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enviromentals_DeletedByUserId",
                schema: "prj",
                table: "Enviromentals",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enviromentals_ModifiedByUserId",
                schema: "prj",
                table: "Enviromentals",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enviromentals_ProjectRevisionId",
                schema: "prj",
                table: "Enviromentals",
                column: "ProjectRevisionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOption_CreatedByUserId",
                schema: "prj",
                table: "EvacuationOption",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOption_DeletedByUserId",
                schema: "prj",
                table: "EvacuationOption",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOption_InfrastructureDataId",
                schema: "prj",
                table: "EvacuationOption",
                column: "InfrastructureDataId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationOption_ModifiedByUserId",
                schema: "prj",
                table: "EvacuationOption",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsDatas_CreatedByUserId",
                schema: "prj",
                table: "FieldsDatas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsDatas_DeletedByUserId",
                schema: "prj",
                table: "FieldsDatas",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsDatas_ModifiedByUserId",
                schema: "prj",
                table: "FieldsDatas",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldsDatas_ProjectRevisionId",
                schema: "prj",
                table: "FieldsDatas",
                column: "ProjectRevisionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureDatas_CreatedByUserId",
                schema: "prj",
                table: "InfrastructureDatas",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureDatas_DeletedByUserId",
                schema: "prj",
                table: "InfrastructureDatas",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureDatas_ModifiedByUserId",
                schema: "prj",
                table: "InfrastructureDatas",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureDatas_ProjectRevisionId",
                schema: "prj",
                table: "InfrastructureDatas",
                column: "ProjectRevisionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraAccuracyExpression_CreatedByUserId",
                schema: "prj",
                table: "LookUpCraAccuracyExpression",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraAccuracyExpression_DeletedByUserId",
                schema: "prj",
                table: "LookUpCraAccuracyExpression",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraAccuracyExpression_ModifiedByUserId",
                schema: "prj",
                table: "LookUpCraAccuracyExpression",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraContingencyExpression_CreatedByUserId",
                schema: "prj",
                table: "LookUpCraContingencyExpression",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraContingencyExpression_DeletedByUserId",
                schema: "prj",
                table: "LookUpCraContingencyExpression",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraContingencyExpression_ModifiedByUserId",
                schema: "prj",
                table: "LookUpCraContingencyExpression",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraPdfXValue_CreatedByUserId",
                schema: "prj",
                table: "LookUpCraPdfXValue",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraPdfXValue_DeletedByUserId",
                schema: "prj",
                table: "LookUpCraPdfXValue",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraPdfXValue_ModifiedByUserId",
                schema: "prj",
                table: "LookUpCraPdfXValue",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraPdfYValue_CreatedByUserId",
                schema: "prj",
                table: "LookUpCraPdfYValue",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraPdfYValue_DeletedByUserId",
                schema: "prj",
                table: "LookUpCraPdfYValue",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraPdfYValue_ModifiedByUserId",
                schema: "prj",
                table: "LookUpCraPdfYValue",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraSCurveValue_CreatedByUserId",
                schema: "prj",
                table: "LookUpCraSCurveValue",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraSCurveValue_DeletedByUserId",
                schema: "prj",
                table: "LookUpCraSCurveValue",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCraSCurveValue_ModifiedByUserId",
                schema: "prj",
                table: "LookUpCraSCurveValue",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNatureDetails_CreatedByUserId",
                schema: "prj",
                table: "ProjectNatureDetails",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNatureDetails_DeletedByUserId",
                schema: "prj",
                table: "ProjectNatureDetails",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNatureDetails_ModifiedByUserId",
                schema: "prj",
                table: "ProjectNatureDetails",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNatureDetails_ProjectId",
                schema: "prj",
                table: "ProjectNatureDetails",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNatureDetails_ProjectNatureId",
                schema: "prj",
                table: "ProjectNatureDetails",
                column: "ProjectNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNatures_CreatedByUserId",
                schema: "prj",
                table: "ProjectNatures",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNatures_DeletedByUserId",
                schema: "prj",
                table: "ProjectNatures",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNatures_ModifiedByUserId",
                schema: "prj",
                table: "ProjectNatures",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRevisions_CreatedByUserId",
                schema: "prj",
                table: "ProjectRevisions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRevisions_DeletedByUserId",
                schema: "prj",
                table: "ProjectRevisions",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRevisions_ModifiedByUserId",
                schema: "prj",
                table: "ProjectRevisions",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRevisions_ProjectId",
                schema: "prj",
                table: "ProjectRevisions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRevisions_ProjectStageId",
                schema: "prj",
                table: "ProjectRevisions",
                column: "ProjectStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRevisions_RespondedByUserId",
                schema: "prj",
                table: "ProjectRevisions",
                column: "RespondedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRevisions_SubmittedByUserId",
                schema: "prj",
                table: "ProjectRevisions",
                column: "SubmittedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedByUserId",
                schema: "prj",
                table: "Projects",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeletedByUserId",
                schema: "prj",
                table: "Projects",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LastSubmittedBy",
                schema: "prj",
                table: "Projects",
                column: "LastSubmittedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ModifiedByUserId",
                schema: "prj",
                table: "Projects",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStages_CreatedByUserId",
                schema: "prj",
                table: "ProjectStages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStages_DeletedByUserId",
                schema: "prj",
                table: "ProjectStages",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStages_ModifiedByUserId",
                schema: "prj",
                table: "ProjectStages",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_CreatedByUserId",
                schema: "prj",
                table: "ProjectUsers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_DeletedByUserId",
                schema: "prj",
                table: "ProjectUsers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ModifiedByUserId",
                schema: "prj",
                table: "ProjectUsers",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ProjectId",
                schema: "prj",
                table: "ProjectUsers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_UserId",
                schema: "prj",
                table: "ProjectUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionTeamMember_CreatedByUserId",
                schema: "prj",
                table: "RevisionTeamMember",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionTeamMember_DeletedByUserId",
                schema: "prj",
                table: "RevisionTeamMember",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionTeamMember_ModifiedByUserId",
                schema: "prj",
                table: "RevisionTeamMember",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionTeamMember_ProjectRevisionId",
                schema: "prj",
                table: "RevisionTeamMember",
                column: "ProjectRevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionTeamMember_RevisionId",
                schema: "prj",
                table: "RevisionTeamMember",
                column: "RevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_RevisionTeamMember_UserId",
                schema: "prj",
                table: "RevisionTeamMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UpstreamMetricColumn_CreatedByUserId",
                schema: "prj",
                table: "UpstreamMetricColumn",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UpstreamMetricColumn_DeletedByUserId",
                schema: "prj",
                table: "UpstreamMetricColumn",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UpstreamMetricColumn_ModifiedByUserId",
                schema: "prj",
                table: "UpstreamMetricColumn",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UTCCosts_CountryId",
                schema: "prj",
                table: "UTCCosts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UTCCosts_CreatedByUserId",
                schema: "prj",
                table: "UTCCosts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UTCCosts_DeletedByUserId",
                schema: "prj",
                table: "UTCCosts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UTCCosts_ModifiedByUserId",
                schema: "prj",
                table: "UTCCosts",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoeInputP10",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "CoeInputP50",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "CoeInputP90",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "Enviromentals",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "EvacuationOption",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "FieldsDatas",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "LookUpCraAccuracyExpression",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "LookUpCraContingencyExpression",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "LookUpCraPdfXValue",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "LookUpCraPdfYValue",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "LookUpCraSCurveValue",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "ProjectNatureDetails",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "ProjectUsers",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "RevisionTeamMember",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "UpstreamMetricColumn",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "UTCCosts",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "DrillingCenters",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "InfrastructureDatas",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "ProjectNatures",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "ProjectRevisions",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "ProjectStages",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "prj");
        }
    }
}
