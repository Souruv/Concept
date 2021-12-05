using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class GenerateProjectConceptQueueTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrillingCenterData_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "DrillingCenterData");

            migrationBuilder.DropForeignKey(
                name: "FK_Enviromental_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "Enviromental");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldsData_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "FieldsData");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectConceptQueueId",
                schema: "concept",
                table: "FieldsData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectConceptQueueId",
                schema: "concept",
                table: "Enviromental",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectConceptQueueId",
                schema: "concept",
                table: "DrillingCenterData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectConceptQueueId",
                schema: "concept",
                table: "Concepts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProjectConceptQueue",
                schema: "concept",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectRevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessingStatus = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_ProjectConceptQueue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectConceptQueue_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectConceptQueue_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectConceptQueue_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "concept",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldsData_ProjectConceptQueueId",
                schema: "concept",
                table: "FieldsData",
                column: "ProjectConceptQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_Enviromental_ProjectConceptQueueId",
                schema: "concept",
                table: "Enviromental",
                column: "ProjectConceptQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillingCenterData_ProjectConceptQueueId",
                schema: "concept",
                table: "DrillingCenterData",
                column: "ProjectConceptQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_ProjectConceptQueueId",
                schema: "concept",
                table: "Concepts",
                column: "ProjectConceptQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectConceptQueue_CreatedByUserId",
                schema: "concept",
                table: "ProjectConceptQueue",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectConceptQueue_DeletedByUserId",
                schema: "concept",
                table: "ProjectConceptQueue",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectConceptQueue_ModifiedByUserId",
                schema: "concept",
                table: "ProjectConceptQueue",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concepts_ProjectConceptQueue_ProjectConceptQueueId",
                schema: "concept",
                table: "Concepts",
                column: "ProjectConceptQueueId",
                principalSchema: "concept",
                principalTable: "ProjectConceptQueue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DrillingCenterData_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "DrillingCenterData",
                column: "CreatedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DrillingCenterData_ProjectConceptQueue_ProjectConceptQueueId",
                schema: "concept",
                table: "DrillingCenterData",
                column: "ProjectConceptQueueId",
                principalSchema: "concept",
                principalTable: "ProjectConceptQueue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enviromental_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "Enviromental",
                column: "CreatedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enviromental_ProjectConceptQueue_ProjectConceptQueueId",
                schema: "concept",
                table: "Enviromental",
                column: "ProjectConceptQueueId",
                principalSchema: "concept",
                principalTable: "ProjectConceptQueue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldsData_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "FieldsData",
                column: "CreatedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldsData_ProjectConceptQueue_ProjectConceptQueueId",
                schema: "concept",
                table: "FieldsData",
                column: "ProjectConceptQueueId",
                principalSchema: "concept",
                principalTable: "ProjectConceptQueue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concepts_ProjectConceptQueue_ProjectConceptQueueId",
                schema: "concept",
                table: "Concepts");

            migrationBuilder.DropForeignKey(
                name: "FK_DrillingCenterData_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "DrillingCenterData");

            migrationBuilder.DropForeignKey(
                name: "FK_DrillingCenterData_ProjectConceptQueue_ProjectConceptQueueId",
                schema: "concept",
                table: "DrillingCenterData");

            migrationBuilder.DropForeignKey(
                name: "FK_Enviromental_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "Enviromental");

            migrationBuilder.DropForeignKey(
                name: "FK_Enviromental_ProjectConceptQueue_ProjectConceptQueueId",
                schema: "concept",
                table: "Enviromental");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldsData_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "FieldsData");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldsData_ProjectConceptQueue_ProjectConceptQueueId",
                schema: "concept",
                table: "FieldsData");

            migrationBuilder.DropTable(
                name: "ProjectConceptQueue",
                schema: "concept");

            migrationBuilder.DropIndex(
                name: "IX_FieldsData_ProjectConceptQueueId",
                schema: "concept",
                table: "FieldsData");

            migrationBuilder.DropIndex(
                name: "IX_Enviromental_ProjectConceptQueueId",
                schema: "concept",
                table: "Enviromental");

            migrationBuilder.DropIndex(
                name: "IX_DrillingCenterData_ProjectConceptQueueId",
                schema: "concept",
                table: "DrillingCenterData");

            migrationBuilder.DropIndex(
                name: "IX_Concepts_ProjectConceptQueueId",
                schema: "concept",
                table: "Concepts");

            migrationBuilder.DropColumn(
                name: "ProjectConceptQueueId",
                schema: "concept",
                table: "FieldsData");

            migrationBuilder.DropColumn(
                name: "ProjectConceptQueueId",
                schema: "concept",
                table: "Enviromental");

            migrationBuilder.DropColumn(
                name: "ProjectConceptQueueId",
                schema: "concept",
                table: "DrillingCenterData");

            migrationBuilder.DropColumn(
                name: "ProjectConceptQueueId",
                schema: "concept",
                table: "Concepts");

            migrationBuilder.AddForeignKey(
                name: "FK_DrillingCenterData_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "DrillingCenterData",
                column: "CreatedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enviromental_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "Enviromental",
                column: "CreatedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldsData_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "FieldsData",
                column: "CreatedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
