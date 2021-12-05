using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class TIChangesForIntegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "cost",
                table: "ProjectLocation",
                newName: "Area");

            migrationBuilder.AddColumn<Guid>(
                name: "ConceptDCDetailsId",
                schema: "cost",
                table: "TICostCalculation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DCName",
                schema: "cost",
                table: "TICostCalculation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConceptId",
                schema: "cost",
                table: "CostSummarySubTotal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConceptDCDetailsId",
                schema: "cost",
                table: "CostSummarySubTotal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DCName",
                schema: "cost",
                table: "CostSummarySubTotal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConceptId",
                schema: "cost",
                table: "CostSummaryStructure",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConceptDCDetailsId",
                schema: "cost",
                table: "CostSummaryStructure",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DCName",
                schema: "cost",
                table: "CostSummaryStructure",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConceptDCDetailsId",
                schema: "cost",
                table: "CampaignDuration",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DCName",
                schema: "cost",
                table: "CampaignDuration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TICostCalculationCompleted",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConceptDCDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCalculated = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_TICostCalculationCompleted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TICostCalculationCompleted_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TICostCalculationCompleted_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TICostCalculationCompleted_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"),
                column: "Area",
                value: "Malaysia - Sabah");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"),
                column: "Area",
                value: "Malaysia - Sarawak");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"),
                column: "Area",
                value: "Malaysia - Peninsular");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculationCompleted_CreatedByUserId",
                schema: "cost",
                table: "TICostCalculationCompleted",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculationCompleted_DeletedByUserId",
                schema: "cost",
                table: "TICostCalculationCompleted",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TICostCalculationCompleted_ModifiedByUserId",
                schema: "cost",
                table: "TICostCalculationCompleted",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TICostCalculationCompleted",
                schema: "cost");

            migrationBuilder.DropColumn(
                name: "ConceptDCDetailsId",
                schema: "cost",
                table: "TICostCalculation");

            migrationBuilder.DropColumn(
                name: "DCName",
                schema: "cost",
                table: "TICostCalculation");

            migrationBuilder.DropColumn(
                name: "ConceptDCDetailsId",
                schema: "cost",
                table: "CostSummarySubTotal");

            migrationBuilder.DropColumn(
                name: "DCName",
                schema: "cost",
                table: "CostSummarySubTotal");

            migrationBuilder.DropColumn(
                name: "ConceptDCDetailsId",
                schema: "cost",
                table: "CostSummaryStructure");

            migrationBuilder.DropColumn(
                name: "DCName",
                schema: "cost",
                table: "CostSummaryStructure");

            migrationBuilder.DropColumn(
                name: "ConceptDCDetailsId",
                schema: "cost",
                table: "CampaignDuration");

            migrationBuilder.DropColumn(
                name: "DCName",
                schema: "cost",
                table: "CampaignDuration");

            migrationBuilder.RenameColumn(
                name: "Area",
                schema: "cost",
                table: "ProjectLocation",
                newName: "Value");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConceptId",
                schema: "cost",
                table: "CostSummarySubTotal",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConceptId",
                schema: "cost",
                table: "CostSummaryStructure",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("6d735b6d-4d99-45ff-a11a-fb3fe8345ca5"),
                column: "Value",
                value: "SB");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("8b416969-0bcf-4a86-a2c6-78c155e40c22"),
                column: "Value",
                value: "SK");

            migrationBuilder.UpdateData(
                schema: "cost",
                table: "ProjectLocation",
                keyColumn: "Id",
                keyValue: new Guid("ed6b863c-fd44-4bef-87c8-14d53e1a4f04"),
                column: "Value",
                value: "PM");
        }
    }
}
