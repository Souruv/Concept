using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class tablenamechangefromdefaultmanpowertodefaultmanpowermanhrsrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerFixedValues_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerFixedValues_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerFixedValues_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerFixedValues_Country_CountryId",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerFixedValues_MasterTypicalManpower_MasterTypicalManpowerId",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefaultManpowerFixedValues",
                schema: "cost",
                table: "DefaultManpowerFixedValues");

            migrationBuilder.RenameTable(
                name: "DefaultManpowerFixedValues",
                schema: "cost",
                newName: "DefaultManpowerManHrsRate",
                newSchema: "cost");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerFixedValues_ModifiedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                newName: "IX_DefaultManpowerManHrsRate_ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerFixedValues_MasterTypicalManpowerId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                newName: "IX_DefaultManpowerManHrsRate_MasterTypicalManpowerId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerFixedValues_DeletedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                newName: "IX_DefaultManpowerManHrsRate_DeletedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerFixedValues_CreatedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                newName: "IX_DefaultManpowerManHrsRate_CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerFixedValues_CountryId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                newName: "IX_DefaultManpowerManHrsRate_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefaultManpowerManHrsRate",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerManHrsRate_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerManHrsRate_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerManHrsRate_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerManHrsRate_Country_CountryId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                column: "CountryId",
                principalSchema: "cost",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerManHrsRate_MasterTypicalManpower_MasterTypicalManpowerId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate",
                column: "MasterTypicalManpowerId",
                principalSchema: "cost",
                principalTable: "MasterTypicalManpower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerManHrsRate_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerManHrsRate_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerManHrsRate_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerManHrsRate_Country_CountryId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate");

            migrationBuilder.DropForeignKey(
                name: "FK_DefaultManpowerManHrsRate_MasterTypicalManpower_MasterTypicalManpowerId",
                schema: "cost",
                table: "DefaultManpowerManHrsRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DefaultManpowerManHrsRate",
                schema: "cost",
                table: "DefaultManpowerManHrsRate");

            migrationBuilder.RenameTable(
                name: "DefaultManpowerManHrsRate",
                schema: "cost",
                newName: "DefaultManpowerFixedValues",
                newSchema: "cost");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerManHrsRate_ModifiedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                newName: "IX_DefaultManpowerFixedValues_ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerManHrsRate_MasterTypicalManpowerId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                newName: "IX_DefaultManpowerFixedValues_MasterTypicalManpowerId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerManHrsRate_DeletedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                newName: "IX_DefaultManpowerFixedValues_DeletedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerManHrsRate_CreatedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                newName: "IX_DefaultManpowerFixedValues_CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DefaultManpowerManHrsRate_CountryId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                newName: "IX_DefaultManpowerFixedValues_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DefaultManpowerFixedValues",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerFixedValues_AppUsers_CreatedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "CreatedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerFixedValues_AppUsers_DeletedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "DeletedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefaultManpowerFixedValues_AppUsers_ModifiedByUserId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "ModifiedByUserId",
                principalSchema: "cost",
                principalTable: "AppUsers",
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
                name: "FK_DefaultManpowerFixedValues_MasterTypicalManpower_MasterTypicalManpowerId",
                schema: "cost",
                table: "DefaultManpowerFixedValues",
                column: "MasterTypicalManpowerId",
                principalSchema: "cost",
                principalTable: "MasterTypicalManpower",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
