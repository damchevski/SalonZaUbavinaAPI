using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonZaUbavinaAPI.Migrations
{
    public partial class Appointments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleDescription",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "AppointmentDescription",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDescription",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "ScheduleDescription",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
