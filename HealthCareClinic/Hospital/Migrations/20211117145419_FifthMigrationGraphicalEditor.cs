using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class FifthMigrationGraphicalEditor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Name", "Quantity", "RoomId", "Type" },
                values: new object[,]
                {
                    { 6, "Bed", 2, 2, 0 },
                    { 33, "TV", 3, 40, 0 },
                    { 34, "Bandage", 1, 40, 1 },
                    { 35, "Blanket", 9, 40, 0 },
                    { 36, "Bed", 9, 43, 0 },
                    { 37, "Needle", 9, 43, 1 },
                    { 38, "TV", 3, 45, 0 },
                    { 39, "Bandage", 9, 47, 1 },
                    { 40, "Blanket", 9, 47, 0 },
                    { 41, "Bed", 7, 50, 0 },
                    { 42, "Needle", 4, 51, 1 },
                    { 43, "TV", 1, 52, 0 },
                    { 44, "Bandage", 11, 55, 1 },
                    { 45, "Blanket", 15, 55, 0 },
                    { 46, "Bed", 13, 60, 0 },
                    { 47, "Needle", 13, 60, 1 },
                    { 48, "TV", 2, 62, 0 },
                    { 49, "Bandage", 13, 62, 1 },
                    { 50, "Blanket", 13, 64, 0 },
                    { 51, "Bed", 17, 64, 0 },
                    { 52, "Needle", 17, 66, 1 },
                    { 53, "TV", 2, 68, 0 },
                    { 32, "Needle", 4, 35, 1 },
                    { 31, "Bed", 7, 35, 0 },
                    { 30, "Blanket", 4, 30, 0 },
                    { 29, "Bandage", 4, 30, 1 },
                    { 7, "Needle", 3, 2, 1 },
                    { 8, "TV", 3, 4, 0 },
                    { 9, "Bandage", 5, 4, 1 },
                    { 10, "Blanket", 2, 4, 0 },
                    { 11, "Bed", 25, 8, 0 },
                    { 12, "Needle", 3, 9, 1 },
                    { 13, "TV", 4, 9, 0 },
                    { 14, "Bandage", 6, 11, 1 },
                    { 15, "Blanket", 5, 11, 0 },
                    { 16, "Bed", 26, 14, 0 },
                    { 54, "Bandage", 17, 70, 1 },
                    { 17, "Needle", 23, 17, 1 },
                    { 19, "Bandage", 120, 17, 1 },
                    { 20, "Blanket", 52, 18, 0 },
                    { 21, "Bed", 1, 20, 0 },
                    { 22, "Needle", 1, 22, 1 },
                    { 23, "TV", 1, 22, 0 },
                    { 24, "Bandage", 1, 23, 1 },
                    { 25, "Blanket", 1, 23, 0 },
                    { 26, "Bed", 3, 26, 0 },
                    { 27, "Needle", 2, 26, 1 },
                    { 28, "TV", 2, 28, 0 },
                    { 18, "TV", 1, 17, 0 },
                    { 55, "Blanket", 17, 70, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 55);
        }
    }
}
