using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.AuthService.Persistence.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "FelStages",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
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
                    table.PrimaryKey("PK_FelStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
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
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FelStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "auth",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUsers_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalSchema: "auth",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalSchema: "auth",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUsers_FelStages_FelStageId",
                        column: x => x.FelStageId,
                        principalSchema: "auth",
                        principalTable: "FelStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "AppUsers",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "DepartmentName", "Email", "FelStageId", "IsAdmin", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name", "RoleId", "UserPrincipal" },
                values: new object[] { new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "admin", "admin", null, true, false, null, null, "ConceptorAdmin", null, "admin" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "DeletedByUserId", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "Name" },
                values: new object[] { new Guid("7e94e736-4b5c-416b-8a40-6a6130484f84"), new Guid("eaa6081c-16f1-41be-9153-5662bc03e9fc"), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "FEE TM" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CreatedByUserId",
                schema: "auth",
                table: "AppUsers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DeletedByUserId",
                schema: "auth",
                table: "AppUsers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_FelStageId",
                schema: "auth",
                table: "AppUsers",
                column: "FelStageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_ModifiedByUserId",
                schema: "auth",
                table: "AppUsers",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_RoleId",
                schema: "auth",
                table: "AppUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_FelStages_CreatedByUserId",
                schema: "auth",
                table: "FelStages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FelStages_DeletedByUserId",
                schema: "auth",
                table: "FelStages",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FelStages_ModifiedByUserId",
                schema: "auth",
                table: "FelStages",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedByUserId",
                schema: "auth",
                table: "Roles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedByUserId",
                schema: "auth",
                table: "Roles",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModifiedByUserId",
                schema: "auth",
                table: "Roles",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FelStages_AppUsers_CreatedByUserId",
                schema: "auth",
                table: "FelStages",
                column: "CreatedByUserId",
                principalSchema: "auth",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FelStages_AppUsers_DeletedByUserId",
                schema: "auth",
                table: "FelStages",
                column: "DeletedByUserId",
                principalSchema: "auth",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FelStages_AppUsers_ModifiedByUserId",
                schema: "auth",
                table: "FelStages",
                column: "ModifiedByUserId",
                principalSchema: "auth",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_AppUsers_CreatedByUserId",
                schema: "auth",
                table: "Roles",
                column: "CreatedByUserId",
                principalSchema: "auth",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_AppUsers_DeletedByUserId",
                schema: "auth",
                table: "Roles",
                column: "DeletedByUserId",
                principalSchema: "auth",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_AppUsers_ModifiedByUserId",
                schema: "auth",
                table: "Roles",
                column: "ModifiedByUserId",
                principalSchema: "auth",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_FelStages_FelStageId",
                schema: "auth",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Roles_RoleId",
                schema: "auth",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "FelStages",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "auth");
        }
    }
}
