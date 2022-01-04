using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class GraphicalEditorShiftsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkShift",
                table: "Doctors",
                newName: "WorkShiftId");

            migrationBuilder.CreateTable(
                name: "WorkDayShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDayShift", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkShiftId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkShiftId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkShiftId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "WorkShiftId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "WorkShiftId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "WorkShiftId",
                value: -1);

            migrationBuilder.InsertData(
                table: "WorkDayShift",
                columns: new[] { "Id", "EndTime", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), "First", new DateTime(2022, 2, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 2, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), "Second", new DateTime(2022, 2, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkDayShift");

            migrationBuilder.RenameColumn(
                name: "WorkShiftId",
                table: "Doctors",
                newName: "WorkShift");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkShift",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkShift",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "WorkShift",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "WorkShift",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "WorkShift",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "WorkShift",
                value: 1);
        }
    }
}
