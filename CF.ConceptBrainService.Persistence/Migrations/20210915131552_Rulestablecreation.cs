using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class Rulestablecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrainFieldTableMapping",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FieldType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OutputColumnName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FieldDisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OutputColumnDisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExecSequence = table.Column<int>(type: "int", nullable: false),
                    ExecLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_BrainFieldTableMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainFieldTableMapping_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainFieldTableMapping_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainFieldTableMapping_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrainTableColumnConfiguration",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrainFieldTableMappingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ColumnDataType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CheckOperator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsInput = table.Column<bool>(type: "bit", nullable: true),
                    ConceptInputDetailColumnName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_BrainTableColumnConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrainTableColumnConfiguration_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainTableColumnConfiguration_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainTableColumnConfiguration_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrainTableColumnConfiguration_BrainFieldTableMapping_BrainFieldTableMappingId",
                        column: x => x.BrainFieldTableMappingId,
                        principalSchema: "concept",
                        principalTable: "BrainFieldTableMapping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrainFieldTableMapping_CreatedByUserId",
                schema: "concept",
                table: "BrainFieldTableMapping",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainFieldTableMapping_DeletedByUserId",
                schema: "concept",
                table: "BrainFieldTableMapping",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainFieldTableMapping_ModifiedByUserId",
                schema: "concept",
                table: "BrainFieldTableMapping",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainTableColumnConfiguration_BrainFieldTableMappingId",
                schema: "concept",
                table: "BrainTableColumnConfiguration",
                column: "BrainFieldTableMappingId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainTableColumnConfiguration_CreatedByUserId",
                schema: "concept",
                table: "BrainTableColumnConfiguration",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainTableColumnConfiguration_DeletedByUserId",
                schema: "concept",
                table: "BrainTableColumnConfiguration",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrainTableColumnConfiguration_ModifiedByUserId",
                schema: "concept",
                table: "BrainTableColumnConfiguration",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrainTableColumnConfiguration",
                schema: "concept");

            migrationBuilder.DropTable(
                name: "BrainFieldTableMapping",
                schema: "concept");
        }
    }
}
