using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonZaUbavinaAPI.Migrations
{
    public partial class Appointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_ScheduleStatuses_StatusId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleStatuses",
                table: "ScheduleStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "ScheduleStatuses",
                newName: "AppointmentStatuses");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_StatusId",
                table: "Appointments",
                newName: "IX_Appointments_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentStatuses",
                table: "AppointmentStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentStatuses_StatusId",
                table: "Appointments",
                column: "StatusId",
                principalTable: "AppointmentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentStatuses_StatusId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentStatuses",
                table: "AppointmentStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "AppointmentStatuses",
                newName: "ScheduleStatuses");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Schedules");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_StatusId",
                table: "Schedules",
                newName: "IX_Schedules_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleStatuses",
                table: "ScheduleStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_ScheduleStatuses_StatusId",
                table: "Schedules",
                column: "StatusId",
                principalTable: "ScheduleStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
