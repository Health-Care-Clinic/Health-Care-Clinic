using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class GraphicalEditorVacationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacations");
        }
    }
}
