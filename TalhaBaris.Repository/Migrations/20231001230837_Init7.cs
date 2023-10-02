using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalhaBaris.Repository.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Appointments_DoctorId_PatientId_AppointmentDate_AppointmentTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentTime",
                table: "Appointments");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Appointments_DoctorId_PatientId_AppointmentDate",
                table: "Appointments",
                columns: new[] { "DoctorId", "PatientId", "AppointmentDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Appointments_DoctorId_PatientId_AppointmentDate",
                table: "Appointments");

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
    }
}
