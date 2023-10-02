using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalhaBaris.Repository.Migrations
{
    public partial class Init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Specialization", "Surname" },
                values: new object[] { "Tony", "Psikoloji", "Soprano" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Specialization", "Surname" },
                values: new object[] { "Tyrion", "Beyin ve Sinir Cerrahisi", "Lannister" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Specialization", "Surname" },
                values: new object[] { "John", "Kulak Burun Boğaz", "Locke" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "Specialization", "Surname" },
                values: new object[,]
                {
                    { 4, "Walter", "Nöroloji", "White" },
                    { 5, "Dexter", "Genel Cerrahi", "Morgan" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Specialization", "Surname" },
                values: new object[] { "Talha", "KBB", "Baris" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Specialization", "Surname" },
                values: new object[] { "cemal", "noroloji", "Baris" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Specialization", "Surname" },
                values: new object[] { "mehmet", "göz", "Baris" });
        }
    }
}
