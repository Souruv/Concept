using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class altertablemastersubsheduleforHUC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScheduleMasterId",
                schema: "cost",
                table: "MasterSubSchedule",
                newName: "MasterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSubSchedule_MasterScheduleId",
                schema: "cost",
                table: "MasterSubSchedule",
                column: "MasterScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterSubSchedule_MasterSchedule_MasterScheduleId",
                schema: "cost",
                table: "MasterSubSchedule",
                column: "MasterScheduleId",
                principalSchema: "cost",
                principalTable: "MasterSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterSubSchedule_MasterSchedule_MasterScheduleId",
                schema: "cost",
                table: "MasterSubSchedule");

            migrationBuilder.DropIndex(
                name: "IX_MasterSubSchedule_MasterScheduleId",
                schema: "cost",
                table: "MasterSubSchedule");

            migrationBuilder.RenameColumn(
                name: "MasterScheduleId",
                schema: "cost",
                table: "MasterSubSchedule",
                newName: "ScheduleMasterId");
        }
    }
}
