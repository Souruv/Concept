using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ProjectService.Persistence.Migrations
{
    public partial class addlatlogreinjection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDeterministicValues_AppUsers_CreatedByUserId",
                schema: "prj",
                table: "ProjectDeterministicValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDeterministicValues_ProjectRevisions_ProjectRevisionId",
                schema: "prj",
                table: "ProjectDeterministicValues");

            migrationBuilder.RenameColumn(
                name: "Coordinate",
                schema: "prj",
                table: "Enviromentals",
                newName: "CoordinateLon");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectRevisionId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeterministicValueId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GasDisposalByReinjection",
                schema: "prj",
                table: "FieldsDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoordinateLat",
                schema: "prj",
                table: "Enviromentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDeterministicValues_AppUsers_CreatedByUserId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "CreatedByUserId",
                principalSchema: "prj",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDeterministicValues_ProjectRevisions_ProjectRevisionId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "ProjectRevisionId",
                principalSchema: "prj",
                principalTable: "ProjectRevisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDeterministicValues_AppUsers_CreatedByUserId",
                schema: "prj",
                table: "ProjectDeterministicValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDeterministicValues_ProjectRevisions_ProjectRevisionId",
                schema: "prj",
                table: "ProjectDeterministicValues");

            migrationBuilder.DropColumn(
                name: "GasDisposalByReinjection",
                schema: "prj",
                table: "FieldsDatas");

            migrationBuilder.DropColumn(
                name: "CoordinateLat",
                schema: "prj",
                table: "Enviromentals");

            migrationBuilder.RenameColumn(
                name: "CoordinateLon",
                schema: "prj",
                table: "Enviromentals",
                newName: "Coordinate");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectRevisionId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeterministicValueId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDeterministicValues_AppUsers_CreatedByUserId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "CreatedByUserId",
                principalSchema: "prj",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDeterministicValues_ProjectRevisions_ProjectRevisionId",
                schema: "prj",
                table: "ProjectDeterministicValues",
                column: "ProjectRevisionId",
                principalSchema: "prj",
                principalTable: "ProjectRevisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
