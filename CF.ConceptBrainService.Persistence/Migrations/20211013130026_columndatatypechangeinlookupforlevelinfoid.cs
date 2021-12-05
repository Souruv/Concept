using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class columndatatypechangeinlookupforlevelinfoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookupGenericWeightEstimate_LevelInformation_LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropIndex(
                name: "IX_LookupGenericWeightEstimate_LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropColumn(
                name: "LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.AlterColumn<Guid>(
                name: "LevelInformationId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookupGenericWeightEstimate_LevelInformationId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "LevelInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookupGenericWeightEstimate_LevelInformation_LevelInformationId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "LevelInformationId",
                principalSchema: "concept",
                principalTable: "LevelInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookupGenericWeightEstimate_LevelInformation_LevelInformationId",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropIndex(
                name: "IX_LookupGenericWeightEstimate_LevelInformationId",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.AlterColumn<string>(
                name: "LevelInformationId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookupGenericWeightEstimate_LevelInformationId1",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "LevelInformationId1");

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
    }
}
