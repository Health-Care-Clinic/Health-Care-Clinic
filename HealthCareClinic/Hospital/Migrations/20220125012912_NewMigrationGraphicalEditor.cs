using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class NewMigrationGraphicalEditor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transfer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Equipment",
                table: "Transfer",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "SourceRoomId",
                table: "Transfer",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Transfer",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Transfer",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationRoomId",
                table: "Transfer",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfer",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "Transfer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 8, 22, 9, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Transfer",
                columns: new[] { "Id", "Date", "Duration", "Name", "Quantity", "DestinationRoomId", "SourceRoomId" },
                values: new object[] { 9, new DateTime(2021, 11, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 60, "Bed", 2, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transfer",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Transfer",
                newName: "Equipment");

            migrationBuilder.AlterColumn<int>(
                name: "SourceRoomId",
                table: "Transfer",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Transfer",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Transfer",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationRoomId",
                table: "Transfer",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transfer",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Transfer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2021, 11, 24, 9, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Transfer",
                columns: new[] { "Id", "Date", "DestinationRoomId", "Duration", "Equipment", "Quantity", "SourceRoomId" },
                values: new object[] { 1, new DateTime(2021, 11, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 2, 60, "Bed", 2, 1 });
        }
    }
}
