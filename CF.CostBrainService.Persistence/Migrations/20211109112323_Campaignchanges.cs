using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class Campaignchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignDuration_CostSummaryStructure_CostSummaryId",
                schema: "cost",
                table: "CampaignDuration");

            migrationBuilder.DropIndex(
                name: "IX_CampaignDuration_CostSummaryId",
                schema: "cost",
                table: "CampaignDuration");

            migrationBuilder.RenameColumn(
                name: "CostSummaryId",
                schema: "cost",
                table: "CampaignDuration",
                newName: "ConceptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConceptId",
                schema: "cost",
                table: "CampaignDuration",
                newName: "CostSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDuration_CostSummaryId",
                schema: "cost",
                table: "CampaignDuration",
                column: "CostSummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignDuration_CostSummaryStructure_CostSummaryId",
                schema: "cost",
                table: "CampaignDuration",
                column: "CostSummaryId",
                principalSchema: "cost",
                principalTable: "CostSummaryStructure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
