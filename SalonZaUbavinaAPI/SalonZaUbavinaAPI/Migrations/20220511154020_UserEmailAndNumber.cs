using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonZaUbavinaAPI.Migrations
{
    public partial class UserEmailAndNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Schedules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Schedules");
        }
    }
}
