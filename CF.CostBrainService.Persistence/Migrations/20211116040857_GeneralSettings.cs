using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class GeneralSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterGeneralSettings",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterGeneralSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterGeneralSettings_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterGeneralSettings_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterGeneralSettings_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSettingsDetails",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MasterGeneralSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCurrency = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMultipleValue = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_GeneralSettingsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralSettingsDetails_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralSettingsDetails_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralSettingsDetails_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralSettingsDetails_MasterGeneralSettings_MasterGeneralSettingsId",
                        column: x => x.MasterGeneralSettingsId,
                        principalSchema: "cost",
                        principalTable: "MasterGeneralSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSettingsValues",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneralSettingsDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_GeneralSettingsValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralSettingsValues_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralSettingsValues_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralSettingsValues_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneralSettingsValues_GeneralSettingsDetails_GeneralSettingsDetailsId",
                        column: x => x.GeneralSettingsDetailsId,
                        principalSchema: "cost",
                        principalTable: "GeneralSettingsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettingsDetails_CreatedByUserId",
                schema: "cost",
                table: "GeneralSettingsDetails",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettingsDetails_DeletedByUserId",
                schema: "cost",
                table: "GeneralSettingsDetails",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettingsDetails_MasterGeneralSettingsId",
                schema: "cost",
                table: "GeneralSettingsDetails",
                column: "MasterGeneralSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettingsDetails_ModifiedByUserId",
                schema: "cost",
                table: "GeneralSettingsDetails",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettingsValues_CreatedByUserId",
                schema: "cost",
                table: "GeneralSettingsValues",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettingsValues_DeletedByUserId",
                schema: "cost",
                table: "GeneralSettingsValues",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettingsValues_GeneralSettingsDetailsId",
                schema: "cost",
                table: "GeneralSettingsValues",
                column: "GeneralSettingsDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettingsValues_ModifiedByUserId",
                schema: "cost",
                table: "GeneralSettingsValues",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterGeneralSettings_CreatedByUserId",
                schema: "cost",
                table: "MasterGeneralSettings",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterGeneralSettings_DeletedByUserId",
                schema: "cost",
                table: "MasterGeneralSettings",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterGeneralSettings_ModifiedByUserId",
                schema: "cost",
                table: "MasterGeneralSettings",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralSettingsValues",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "GeneralSettingsDetails",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "MasterGeneralSettings",
                schema: "cost");
        }
    }
}
