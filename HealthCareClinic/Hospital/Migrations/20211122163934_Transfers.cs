using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class Transfers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Equipment = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    SourceRoomId = table.Column<int>(type: "integer", nullable: false),
                    DestinationRoomId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transfer",
                columns: new[] { "Id", "Date", "DestinationRoomId", "Duration", "Equipment", "Quantity", "SourceRoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 2, 60, "Bed", 2, 1 },
                    { 2, new DateTime(2021, 11, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 60, 45, "Bed", 4, 50 },
                    { 3, new DateTime(2021, 11, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), 52, 15, "TV", 1, 45 },
                    { 4, new DateTime(2021, 11, 24, 9, 30, 0, 0, DateTimeKind.Unspecified), 62, 15, "Bandage", 4, 47 },
                    { 5, new DateTime(2021, 11, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), 23, 15, "Blanket", 10, 18 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfer");
        }
    }
}
