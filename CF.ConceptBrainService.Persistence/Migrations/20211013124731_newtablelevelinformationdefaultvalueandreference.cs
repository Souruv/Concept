using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class newtablelevelinformationdefaultvalueandreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LevelInformationId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelType",
                schema: "concept",
                table: "EquipmentMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LevelInformation",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecMinCriteriaValue = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    SecMaxCriteriaValue = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_LevelInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelInformation_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevelInformation_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevelInformation_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "concept",
                table: "EquipmentMaster",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "CriteriaType", "DeletedByUserId", "DeletedOn", "EquipmentName", "IsDeleted", "LevelType", "ModifiedByUserId", "ModifiedOn", "WBSId" },
                values: new object[] { new Guid("05b435fd-c0f1-4168-94ce-c4f99821cfe8"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Range", null, null, "", false, "1", null, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_LookupGenericWeightEstimate_LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "LevelInformationId1");

            migrationBuilder.CreateIndex(
                name: "IX_LevelInformation_CreatedByUserId",
                schema: "concept",
                table: "LevelInformation",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelInformation_DeletedByUserId",
                schema: "concept",
                table: "LevelInformation",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelInformation_ModifiedByUserId",
                schema: "concept",
                table: "LevelInformation",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookupGenericWeightEstimate_LevelInformation_LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "LevelInformationId1",
                principalSchema: "concept",
                principalTable: "LevelInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookupGenericWeightEstimate_LevelInformation_LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropTable(
                name: "LevelInformation",
                schema: "concept");

            migrationBuilder.DropIndex(
                name: "IX_LookupGenericWeightEstimate_LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DeleteData(
                schema: "concept",
                table: "EquipmentMaster",
                keyColumn: "Id",
                keyValue: new Guid("05b435fd-c0f1-4168-94ce-c4f99821cfe8"));

            migrationBuilder.DropColumn(
                name: "LevelInformationId",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropColumn(
                name: "LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropColumn(
                name: "LevelType",
                schema: "concept",
                table: "EquipmentMaster");
        }
    }
}
