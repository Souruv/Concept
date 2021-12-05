using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.ConceptBrainService.Persistence.Migrations
{
    public partial class renaminglookupgenericweightestimate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lookupgenericweightestimate_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate");

            migrationBuilder.DropForeignKey(
                name: "FK_Lookupgenericweightestimate_AppUsers_DeletedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate");

            migrationBuilder.DropForeignKey(
                name: "FK_Lookupgenericweightestimate_AppUsers_ModifiedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate");

            migrationBuilder.DropForeignKey(
                name: "FK_Lookupgenericweightestimate_Equipment_EquipmentId",
                schema: "concept",
                table: "Lookupgenericweightestimate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lookupgenericweightestimate",
                schema: "concept",
                table: "Lookupgenericweightestimate");

            migrationBuilder.RenameTable(
                name: "Lookupgenericweightestimate",
                schema: "concept",
                newName: "LookupGenericWeightEstimate",
                newSchema: "concept");

            migrationBuilder.RenameIndex(
                name: "IX_Lookupgenericweightestimate_ModifiedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                newName: "IX_LookupGenericWeightEstimate_ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Lookupgenericweightestimate_EquipmentId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                newName: "IX_LookupGenericWeightEstimate_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Lookupgenericweightestimate_DeletedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                newName: "IX_LookupGenericWeightEstimate_DeletedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Lookupgenericweightestimate_CreatedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                newName: "IX_LookupGenericWeightEstimate_CreatedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookupGenericWeightEstimate",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LookupGenericWeightEstimate_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "CreatedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookupGenericWeightEstimate_AppUsers_DeletedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "DeletedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookupGenericWeightEstimate_AppUsers_ModifiedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "ModifiedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookupGenericWeightEstimate_Equipment_EquipmentId",
                schema: "concept",
                table: "LookupGenericWeightEstimate",
                column: "EquipmentId",
                principalSchema: "concept",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookupGenericWeightEstimate_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropForeignKey(
                name: "FK_LookupGenericWeightEstimate_AppUsers_DeletedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropForeignKey(
                name: "FK_LookupGenericWeightEstimate_AppUsers_ModifiedByUserId",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropForeignKey(
                name: "FK_LookupGenericWeightEstimate_Equipment_EquipmentId",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookupGenericWeightEstimate",
                schema: "concept",
                table: "LookupGenericWeightEstimate");

            migrationBuilder.RenameTable(
                name: "LookupGenericWeightEstimate",
                schema: "concept",
                newName: "Lookupgenericweightestimate",
                newSchema: "concept");

            migrationBuilder.RenameIndex(
                name: "IX_LookupGenericWeightEstimate_ModifiedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                newName: "IX_Lookupgenericweightestimate_ModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_LookupGenericWeightEstimate_EquipmentId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                newName: "IX_Lookupgenericweightestimate_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_LookupGenericWeightEstimate_DeletedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                newName: "IX_Lookupgenericweightestimate_DeletedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_LookupGenericWeightEstimate_CreatedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                newName: "IX_Lookupgenericweightestimate_CreatedByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lookupgenericweightestimate",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lookupgenericweightestimate_AppUsers_CreatedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "CreatedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lookupgenericweightestimate_AppUsers_DeletedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "DeletedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lookupgenericweightestimate_AppUsers_ModifiedByUserId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "ModifiedByUserId",
                principalSchema: "concept",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lookupgenericweightestimate_Equipment_EquipmentId",
                schema: "concept",
                table: "Lookupgenericweightestimate",
                column: "EquipmentId",
                principalSchema: "concept",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
