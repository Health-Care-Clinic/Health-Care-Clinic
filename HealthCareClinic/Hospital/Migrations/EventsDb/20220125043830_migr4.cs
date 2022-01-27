using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations.EventsDb
{
    public partial class migr4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Content", "Timestamp", "UserId" },
                values: new object[,]
                {
                    { 5, "1:2:TV:4", new DateTime(2022, 1, 3, 12, 35, 42, 0, DateTimeKind.Unspecified), 100 },
                    { 6, "1:2:TV:3", new DateTime(2022, 1, 3, 13, 32, 17, 0, DateTimeKind.Unspecified), 100 },
                    { 7, "2:1:Blanket:1", new DateTime(2022, 1, 4, 18, 21, 8, 0, DateTimeKind.Unspecified), 100 },
                    { 8, "1:2:Bed:1", new DateTime(2022, 1, 5, 9, 41, 28, 0, DateTimeKind.Unspecified), 100 },
                    { 9, "7:8:TV:4", new DateTime(2022, 1, 3, 12, 35, 42, 0, DateTimeKind.Unspecified), 100 },
                    { 10, "11:12:TV:3", new DateTime(2022, 1, 3, 13, 32, 17, 0, DateTimeKind.Unspecified), 100 },
                    { 11, "1:2:Blanket:1", new DateTime(2022, 1, 4, 18, 21, 8, 0, DateTimeKind.Unspecified), 100 },
                    { 12, "1:2:Bed:1", new DateTime(2022, 1, 5, 9, 41, 28, 0, DateTimeKind.Unspecified), 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
