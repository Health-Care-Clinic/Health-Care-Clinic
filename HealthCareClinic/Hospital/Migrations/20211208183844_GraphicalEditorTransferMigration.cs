using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class GraphicalEditorTransferMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transfer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "DestinationRoomId", "Duration", "Equipment", "Quantity" },
                values: new object[] { new DateTime(2022, 8, 22, 9, 30, 0, 0, DateTimeKind.Unspecified), 51, 60, "Needle", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transfer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "DestinationRoomId", "Duration", "Equipment", "Quantity" },
                values: new object[] { new DateTime(2022, 2, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 45, "TV", 1 });
        }
    }
}
