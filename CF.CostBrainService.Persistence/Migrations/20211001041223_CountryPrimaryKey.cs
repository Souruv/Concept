using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class CountryPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_Country_CountryCode",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                schema: "cost",
                table: "Country");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryCode",
                schema: "cost",
                table: "EquipmentCost",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "cost",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "cost",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "cost",
                table: "Country",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                schema: "cost",
                table: "Country",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "cost",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                schema: "cost",
                table: "Country",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                schema: "cost",
                table: "Country",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "cost",
                table: "Country",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserId",
                schema: "cost",
                table: "Country",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "cost",
                table: "Country",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                schema: "cost",
                table: "Country",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CreatedByUserId",
                schema: "cost",
                table: "Country",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_DeletedByUserId",
                schema: "cost",
                table: "Country",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ModifiedByUserId",
                schema: "cost",
                table: "Country",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "Country",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Country_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "Country",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Country_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "Country",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_Country_CountryCode",
                schema: "cost",
                table: "EquipmentCost",
                column: "CountryCode",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_Country_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCost_Country_CountryCode",
                schema: "cost",
                table: "EquipmentCost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_CreatedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_DeletedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_ModifiedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "cost",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "cost",
                table: "Country");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                schema: "cost",
                table: "EquipmentCost",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "cost",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "cost",
                table: "Country",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                schema: "cost",
                table: "Country",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCost_Country_CountryCode",
                schema: "cost",
                table: "EquipmentCost",
                column: "CountryCode",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
