using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class DataSpan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "Id", "Description", "DoctorId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, "Description...", 1, new DateTime(2020, 5, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Description...", 2, new DateTime(2020, 7, 3, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Description...", 1, new DateTime(2020, 10, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Description...", 2, new DateTime(2020, 10, 21, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Description...", 1, new DateTime(2020, 3, 20, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Description...", 2, new DateTime(2020, 8, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Description...", 1, new DateTime(2020, 1, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Description...", 2, new DateTime(2022, 1, 21, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Description...", 1, new DateTime(2022, 5, 7, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Description...", 2, new DateTime(2022, 8, 26, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
