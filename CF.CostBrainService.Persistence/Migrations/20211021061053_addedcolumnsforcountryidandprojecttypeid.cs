using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class addedcolumnsforcountryidandprojecttypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MANHOURS",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                newName: "MANHOURs");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterProjectTypeId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MasterProjectTypeId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "cost",
                table: "DefaultManpower",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DefaultEquipmentManPowerPercentage",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManPowerPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_DefaultEquipmentManPowerPercentage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultEquipmentManPowerPercentage_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultEquipmentManPowerPercentage_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DefaultEquipmentManPowerPercentage_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterOffShoreAccomodation_CountryId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterOffShoreAccomodation_MasterProjectTypeId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDaysFactorperMonth_CountryId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDaysFactorperMonth_MasterProjectTypeId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                column: "MasterProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultThirdPartyServicesSectionOne_CountryId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultOthersFuelAndPW_CountryId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMarineSpreadAndOthers_CountryId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpowerFixedValues_CountryId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultManpower_CountryId",
                schema: "cost",
                table: "DefaultManpower",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultEquipmentManPowerPercentage_CreatedByUserId",
                schema: "cost",
                table: "DefaultEquipmentManPowerPercentage",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultEquipmentManPowerPercentage_DeletedByUserId",
                schema: "cost",
                table: "DefaultEquipmentManPowerPercentage",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultEquipmentManPowerPercentage_ModifiedByUserId",
                schema: "cost",
                table: "DefaultEquipmentManPowerPercentage",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpower_Country_CountryId",
                schema: "cost",
                table: "DefaultManpower",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerFixedValues_Country_CountryId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultMarineSpreadAndOthers_Country_CountryId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultOthersFuelAndPW_Country_CountryId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultThirdPartyServicesSectionOne_Country_CountryId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterDaysFactorperMonth_Country_CountryId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterDaysFactorperMonth_MasterProjectType_MasterProjectTypeId",
                schema: "cost",
                table: "MasterDaysFactorperMonth",
                column: "MasterProjectTypeId",
                principalSchema: "cost",
                principalTable: "MasterProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterOffShoreAccomodation_Country_CountryId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterOffShoreAccomodation_MasterProjectType_MasterProjectTypeId",
                schema: "cost",
                table: "MasterOffShoreAccomodation",
                column: "MasterProjectTypeId",
                principalSchema: "cost",
                principalTable: "MasterProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpower_Country_CountryId",
                schema: "cost",
                table: "DefaultManpower");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerFixedValues_Country_CountryId",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultMarineSpreadAndOthers_Country_CountryId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultOthersFuelAndPW_Country_CountryId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultThirdPartyServicesSectionOne_Country_CountryId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterDaysFactorperMonth_Country_CountryId",
                schema: "cost",
                table: "MasterDaysFactorperMonth");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterDaysFactorperMonth_MasterProjectType_MasterProjectTypeId",
                schema: "cost",
                table: "MasterDaysFactorperMonth");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterOffShoreAccomodation_Country_CountryId",
                schema: "cost",
                table: "MasterOffShoreAccomodation");

            migrationBuilder.DropForeignKey(
                name: "FK_MasterOffShoreAccomodation_MasterProjectType_MasterProjectTypeId",
                schema: "cost",
                table: "MasterOffShoreAccomodation");

            migrationBuilder.DropTable(
                name: "DefaultEquipmentManPowerPercentage",
                schema: "cost");

            migrationBuilder.DropIndex(
                name: "IX_MasterOffShoreAccomodation_CountryId",
                schema: "cost",
                table: "MasterOffShoreAccomodation");

            migrationBuilder.DropIndex(
                name: "IX_MasterOffShoreAccomodation_MasterProjectTypeId",
                schema: "cost",
                table: "MasterOffShoreAccomodation");

            migrationBuilder.DropIndex(
                name: "IX_MasterDaysFactorperMonth_CountryId",
                schema: "cost",
                table: "MasterDaysFactorperMonth");

            migrationBuilder.DropIndex(
                name: "IX_MasterDaysFactorperMonth_MasterProjectTypeId",
                schema: "cost",
                table: "MasterDaysFactorperMonth");

            migrationBuilder.DropIndex(
                name: "IX_DefaultThirdPartyServicesSectionOne_CountryId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne");

            migrationBuilder.DropIndex(
                name: "IX_DefaultOthersFuelAndPW_CountryId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW");

            migrationBuilder.DropIndex(
                name: "IX_DefaultMarineSpreadAndOthers_CountryId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers");

            migrationBuilder.DropIndex(
                name: "IX_DefaultManpowerFixedValues_CountryId",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.DropIndex(
                name: "IX_DefaultManpower_CountryId",
                schema: "cost",
                table: "DefaultManpower");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "MasterOffShoreAccomodation");

            migrationBuilder.DropColumn(
                name: "MasterProjectTypeId",
                schema: "cost",
                table: "MasterOffShoreAccomodation");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "MasterDaysFactorperMonth");

            migrationBuilder.DropColumn(
                name: "MasterProjectTypeId",
                schema: "cost",
                table: "MasterDaysFactorperMonth");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "DefaultThirdPartyServicesSectionOne");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "DefaultOthersFuelAndPW");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "DefaultMarineSpreadAndOthers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "cost",
                table: "DefaultManpower");

            migrationBuilder.RenameColumn(
                name: "MANHOURs",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                newName: "MANHOURS");
        }
    }
}
