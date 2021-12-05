using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class createdeterministictables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeterministicValues",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GuideLines = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DeterministicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeterministicValues_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeterministicValues_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeterministicValues_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDeterministicValues",
                schema: "prj",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeterministicValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ProjectDeterministicValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDeterministicValues_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectDeterministicValues_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectDeterministicValues_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "prj",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectDeterministicValues_DeterministicValues_DeterministicValueId",
                        column: x => x.DeterministicValueId,
                        principalSchema: "prj",
                        principalTable: "DeterministicValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectDeterministicValues_ProjectRevisions_ProjectRevisionId",
                        column: x => x.ProjectRevisionId,
                        principalSchema: "prj",
                        principalTable: "ProjectRevisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeterministicValues_CreatedByUserId",
                schema: "prj",
                table: "DeterministicValues",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeterministicValues_DeletedByUserId",
                schema: "prj",
                table: "DeterministicValues",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeterministicValues_ModifiedByUserId",
                schema: "prj",
                table: "DeterministicValues",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDeterministicValues_CreatedByUserId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDeterministicValues_DeletedByUserId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDeterministicValues_DeterministicValueId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "DeterministicValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDeterministicValues_ModifiedByUserId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDeterministicValues_ProjectRevisionId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "ProjectRevisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDeterministicValues",
                schema: "prj");

            migrationBuilder.DropTable(
                name: "DeterministicValues",
                schema: "prj");
        }
    }
}
