using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class nullablevaluefordefaultmanpowertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpower_MasterProjectType_ProjectTypeMasterId",
                schema: "cost",
                table: "DefaultManpower");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeMasterId",
                schema: "cost",
                table: "DefaultManpower",
                newName: "MasterProjectTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpower_ProjectTypeMasterId",
                schema: "cost",
                table: "DefaultManpower",
                newName: "IX_DefaultManpower_MasterProjectTypeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                schema: "cost",
                table: "DefaultManpower",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                schema: "cost",
                table: "DefaultManpower",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpower_MasterProjectType_MasterProjectTypeId",
                schema: "cost",
                table: "DefaultManpower",
                column: "MasterProjectTypeId",
                principalSchema: "cost",
                principalTable: "MasterProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpower_MasterProjectType_MasterProjectTypeId",
                schema: "cost",
                table: "DefaultManpower");

            migrationBuilder.RenameColumn(
                name: "MasterProjectTypeId",
                schema: "cost",
                table: "DefaultManpower",
                newName: "ProjectTypeMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpower_MasterProjectTypeId",
                schema: "cost",
                table: "DefaultManpower",
                newName: "IX_DefaultManpower_ProjectTypeMasterId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                schema: "cost",
                table: "DefaultManpower",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                schema: "cost",
                table: "DefaultManpower",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpower_MasterProjectType_ProjectTypeMasterId",
                schema: "cost",
                table: "DefaultManpower",
                column: "ProjectTypeMasterId",
                principalSchema: "cost",
                principalTable: "MasterProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
