using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class AddNotificationMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicationConsumptions",
                table: "MedicationConsumptions");

            migrationBuilder.RenameTable(
                name: "MedicationConsumptions",
                newName: "MedicationConsumption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicationConsumption",
                table: "MedicationConsumption",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Seen = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicationConsumption",
                table: "MedicationConsumption");

            migrationBuilder.RenameTable(
                name: "MedicationConsumption",
                newName: "MedicationConsumptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicationConsumptions",
                table: "MedicationConsumptions",
                column: "Id");
        }
    }
}
