using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonZaUbavinaAPI.Migrations
{
    public partial class newNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDescription",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Appointments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceDescription",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ServiceDescription",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "AppointmentDescription",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
