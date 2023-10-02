using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalhaBaris.Repository.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Appointments_DoctorId_PatientId_AppointmentDateTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentDateTime",
                table: "Appointments",
                newName: "AppointmentDate");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AppointmentTime",
                table: "Appointments",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Appointments_DoctorId_PatientId_AppointmentDate_AppointmentTime",
                table: "Appointments",
                columns: new[] { "DoctorId", "PatientId", "AppointmentDate", "AppointmentTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Appointments_DoctorId_PatientId_AppointmentDate_AppointmentTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentTime",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Appointments",
                newName: "AppointmentDateTime");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Appointments_DoctorId_PatientId_AppointmentDateTime",
                table: "Appointments",
                columns: new[] { "DoctorId", "PatientId", "AppointmentDateTime" });
        }
    }
}
