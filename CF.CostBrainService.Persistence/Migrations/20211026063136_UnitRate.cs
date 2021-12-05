using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class UnitRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectLocation",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ProjectLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLocation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectLocation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectLocation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectType",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ProjectType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectType_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectType_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectType_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitRate",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    USD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RM_EQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_UnitRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitRate_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitRate_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitRate_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitRate_ProjectLocation_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "cost",
                        principalTable: "ProjectLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitRate_ProjectType_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "cost",
                        principalTable: "ProjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLocation_CreatedByUserId",
                schema: "cost",
                table: "ProjectLocation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLocation_DeletedByUserId",
                schema: "cost",
                table: "ProjectLocation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLocation_ModifiedByUserId",
                schema: "cost",
                table: "ProjectLocation",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectType_CreatedByUserId",
                schema: "cost",
                table: "ProjectType",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectType_DeletedByUserId",
                schema: "cost",
                table: "ProjectType",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectType_ModifiedByUserId",
                schema: "cost",
                table: "ProjectType",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitRate_CreatedByUserId",
                schema: "cost",
                table: "UnitRate",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitRate_DeletedByUserId",
                schema: "cost",
                table: "UnitRate",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitRate_LocationId",
                schema: "cost",
                table: "UnitRate",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitRate_ModifiedByUserId",
                schema: "cost",
                table: "UnitRate",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitRate_ProjectId",
                schema: "cost",
                table: "UnitRate",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitRate",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "ProjectLocation",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "ProjectType",
                schema: "cost");
        }
    }
}
