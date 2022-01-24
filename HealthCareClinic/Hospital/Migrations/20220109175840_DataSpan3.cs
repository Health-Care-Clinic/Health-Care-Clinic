using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class DataSpan3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 5,
                column: "EndTime",
                value: new DateTime(2021, 3, 20, 23, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 6,
                column: "EndTime",
                value: new DateTime(2021, 8, 22, 23, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 7,
                column: "EndTime",
                value: new DateTime(2022, 1, 13, 23, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 5,
                column: "EndTime",
                value: new DateTime(2020, 3, 20, 23, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 6,
                column: "EndTime",
                value: new DateTime(2020, 8, 22, 23, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 7,
                column: "EndTime",
                value: new DateTime(2020, 1, 13, 23, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
