using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class addpipelinesize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LiquidPipelineSizeBoundary",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newId()"),
                    LengthMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LengthMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FlowRateMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FlowRateMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PressureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false,defaultValue:false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false,defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidPipelineSizeBoundary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiquidPipelineSizeBoundary_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LiquidPipelineSizeBoundary_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LiquidPipelineSizeBoundary_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PipelineSizeCalc",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false,defaultValueSql:"newId()"),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PipelineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false,defaultValue:false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineSizeCalc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipelineSizeCalc_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PipelineSizeCalc_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PipelineSizeCalc_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiquidPipelineSizeBoundary_CreatedByUserId",
                schema: "concept",
                table: "LiquidPipelineSizeBoundary",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidPipelineSizeBoundary_DeletedByUserId",
                schema: "concept",
                table: "LiquidPipelineSizeBoundary",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidPipelineSizeBoundary_ModifiedByUserId",
                schema: "concept",
                table: "LiquidPipelineSizeBoundary",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineSizeCalc_CreatedByUserId",
                schema: "concept",
                table: "PipelineSizeCalc",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineSizeCalc_DeletedByUserId",
                schema: "concept",
                table: "PipelineSizeCalc",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PipelineSizeCalc_ModifiedByUserId",
                schema: "concept",
                table: "PipelineSizeCalc",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiquidPipelineSizeBoundary",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "PipelineSizeCalc",
                schema: "concept");
        }
    }
}
