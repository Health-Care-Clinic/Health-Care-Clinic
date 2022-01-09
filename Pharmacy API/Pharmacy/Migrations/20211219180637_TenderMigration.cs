using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Migrations
{
    public partial class TenderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Medicines",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 4.5);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 5.25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Medicines");
        }
    }
}
