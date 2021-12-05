using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.CostBrainService.Persistence.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cost");

            migrationBuilder.CreateTable(
                name: "AppUser",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserPrincipal = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
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
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_AppUser_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUser_AppUser_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUser_AppUser_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WBSId = table.Column<int>(type: "int", nullable: false),
                    Manifolding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostimatorCBS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_AppUser_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_AppUser_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_AppUser_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCost",
                schema: "cost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Standard = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Acid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrimarySteel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondarySteel = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Piping = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Electrical = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Instrument = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Others = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_EquipmentCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentCost_AppUser_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentCost_AppUser_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentCost_AppUser_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "cost",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentCost_Equipment_Id",
                        column: x => x.Id,
                        principalSchema: "cost",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_CreatedByUserId",
                schema: "cost",
                table: "AppUser",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_DeletedByUserId",
                schema: "cost",
                table: "AppUser",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_ModifiedByUserId",
                schema: "cost",
                table: "AppUser",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CreatedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_DeletedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ModifiedByUserId",
                schema: "cost",
                table: "Equipment",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCost_CreatedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCost_DeletedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCost_ModifiedByUserId",
                schema: "cost",
                table: "EquipmentCost",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentCost",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "cost");

            migrationBuilder.DropTable(
                name: "AppUser",
                schema: "cost");
        }
    }
}
