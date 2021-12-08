using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class graphicalEditorRenovationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Renovations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstRoomId = table.Column<int>(type: "integer", nullable: false),
                    SecondRoomId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Renovations",
                columns: new[] { "Id", "Date", "Duration", "FirstRoomId", "SecondRoomId", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 1 },
                    { 2, new DateTime(2022, 2, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 0, 0 },
                    { 3, new DateTime(2022, 2, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 47, 62, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Renovations");
        }
    }
}
