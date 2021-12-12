using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class EighthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicationConsumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationConsumptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MedicationConsumptions",
                columns: new[] { "Id", "Amount", "Date", "Name" },
                values: new object[,]
                {
                    { 1, 30, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 2, 25, new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 3, 40, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 4, 33, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paracetamol" },
                    { 5, 15, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robenan" },
                    { 6, 10, new DateTime(2021, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationConsumptions");
        }
    }
}
