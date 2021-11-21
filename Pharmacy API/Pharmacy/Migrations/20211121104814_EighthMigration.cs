using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Migrations
{
    public partial class EighthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompatibileMedicine",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reactions",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SideEffects",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usage",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Medicines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompatibileMedicine", "Manufacturer", "Reactions", "SideEffects", "Usage", "Weight" },
                values: new object[] { "Aspirin", "Bayer", "Headache", "Rash, Stomach pain", "Pain relief", 400 });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompatibileMedicine", "Manufacturer", "Reactions", "SideEffects", "Usage", "Weight" },
                values: new object[] { "Aspirin", "Bayer", "Headache, Swelling", "Rash, Unconsciousness", "Lung infections, Bronchitis", 500 });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompatibileMedicine", "Manufacturer", "Reactions", "SideEffects", "Usage", "Weight" },
                values: new object[] { "Aspirin", "Galenika", "None", "None", "Toothache, Headache", 500 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompatibileMedicine",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Reactions",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "SideEffects",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Usage",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Medicines");
        }
    }
}
