using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class ConceptGenerationtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concepts",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    ConceptName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Plevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Accomodation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_Concepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concepts_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Concepts_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Concepts_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConceptsDCDetails",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaterDisposalText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    WaterDisposalIds = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    WaterDisposalPipeLine = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PWTInjectionProcessText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PWTInjectionProcessIds = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PWTInjectionPipeline = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ExternalWaterInjectionProcessText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ExternalWaterInjectionProcessIds = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ExternalWaterInjectionPipeline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OilProcessingProcessText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    OilProcessingProcessIds = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    OilProcessingPipeline = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasExport = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasExportProcessText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasExportProcessIds = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasExportProcessPipeline = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasInjection = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasInjectionProcessText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasInjectionProcessIds = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasInjectionPipeline = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasDisposal = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasDisposalProcess = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasDisposalPipeline = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasCondensateProcessing = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasCondensateProcessingProcess = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GasCondensateProcessingPipeline = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CondensateProcessing = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CondensateProcessingProcess = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CondensateProcessingPipeline = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    TreeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubStructureType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PressureProtection = table.Column<bool>(type: "bit", nullable: false),
                    DWStrategy = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
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
                    table.PrimaryKey("PK_ConceptsDCDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConceptsDCDetails_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConceptsDCDetails_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConceptsDCDetails_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConceptsDCDetails_Concepts_Id",
                        column: x => x.Id,
                        principalSchema: "concept",
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_CreatedByUserId",
                schema: "concept",
                table: "Concepts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_DeletedByUserId",
                schema: "concept",
                table: "Concepts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_ModifiedByUserId",
                schema: "concept",
                table: "Concepts",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptsDCDetails_CreatedByUserId",
                schema: "concept",
                table: "ConceptsDCDetails",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptsDCDetails_DeletedByUserId",
                schema: "concept",
                table: "ConceptsDCDetails",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptsDCDetails_ModifiedByUserId",
                schema: "concept",
                table: "ConceptsDCDetails",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConceptsDCDetails",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "Concepts",
                schema: "concept");
        }
    }
}
