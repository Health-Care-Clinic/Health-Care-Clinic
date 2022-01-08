using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations.EventsDb
{
    public partial class EventsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Content", "Timestamp", "UserId" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2022, 1, 3, 12, 35, 42, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "", new DateTime(2022, 1, 3, 13, 32, 17, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "", new DateTime(2022, 1, 4, 18, 21, 8, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "", new DateTime(2022, 1, 5, 9, 41, 28, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
