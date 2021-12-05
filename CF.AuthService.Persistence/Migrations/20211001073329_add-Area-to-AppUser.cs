using Microsoft.EntityFrameworkCore.Migrations;

namespace CF.AuthService.Persistence.Migrations
{
    public partial class addAreatoAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                schema: "auth",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                schema: "auth",
                table: "AppUsers");
        }
    }
}
