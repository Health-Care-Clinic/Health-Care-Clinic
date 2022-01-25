using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class DateSpan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "WorkDayShift",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "WorkDayShift",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Vacations",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Vacations",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<float>(
                name: "Y",
                table: "Rooms",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "X",
                table: "Rooms",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Width",
                table: "Rooms",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "Rooms",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "WorkDayShift",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "WorkDayShift",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Vacations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Vacations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Y",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "X",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Width",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "Id", "Description", "DoctorId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, "Description...", 1, new DateTime(2020, 2, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "Description...", 4, new DateTime(2022, 5, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "Description...", 3, new DateTime(2022, 4, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "Description...", 2, new DateTime(2022, 3, 3, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "Description...", 1, new DateTime(2022, 2, 2, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "Description...", 6, new DateTime(2022, 12, 29, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "Description...", 5, new DateTime(2022, 12, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "Description...", 4, new DateTime(2022, 11, 11, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "Description...", 3, new DateTime(2022, 10, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Description...", 2, new DateTime(2021, 9, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Description...", 1, new DateTime(2021, 8, 8, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Description...", 6, new DateTime(2021, 7, 7, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Description...", 5, new DateTime(2021, 6, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Description...", 4, new DateTime(2021, 5, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Description...", 3, new DateTime(2021, 3, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Description...", 2, new DateTime(2021, 2, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Description...", 1, new DateTime(2021, 2, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Description...", 6, new DateTime(2021, 12, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Description...", 5, new DateTime(2021, 11, 19, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Description...", 4, new DateTime(2020, 10, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Description...", 3, new DateTime(2020, 9, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Description...", 2, new DateTime(2020, 8, 28, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Description...", 1, new DateTime(2020, 7, 20, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Description...", 6, new DateTime(2020, 7, 7, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Description...", 5, new DateTime(2020, 5, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Description...", 4, new DateTime(2020, 4, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Description...", 3, new DateTime(2020, 3, 21, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Description...", 2, new DateTime(2020, 2, 20, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "Description...", 5, new DateTime(2022, 6, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "Description...", 6, new DateTime(2022, 7, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
