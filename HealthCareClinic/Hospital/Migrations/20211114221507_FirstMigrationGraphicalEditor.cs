using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class FirstMigrationGraphicalEditor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PositionId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BuildingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PositionId = table.Column<int>(type: "integer", nullable: false),
                    FloorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Name", "PositionId", "Type" },
                values: new object[,]
                {
                    { 3, "Building3", 10, 0 },
                    { 1, "Building1", 8, 0 },
                    { 4, "Building4", 11, 0 },
                    { 5, "Parking1", 12, 1 },
                    { 6, "Parking2", 13, 1 },
                    { 7, "Parking3", 14, 1 },
                    { 2, "Building2", 9, 0 }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "BuildingId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Floor 1" },
                    { 2, 1, "Floor 2" },
                    { 5, 2, "Floor 2" },
                    { 6, 3, "Floor 1" },
                    { 7, 3, "Floor 2" },
                    { 8, 3, "Floor 3" },
                    { 9, 4, "Floor 1" },
                    { 10, 4, "Floor 2" },
                    { 4, 2, "Floor 1" },
                    { 3, 1, "Floor 3" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 140f, 400f, 320f, 30f },
                    { 13, 70f, 200f, 800f, 30f },
                    { 14, 70f, 200f, 800f, 130f },
                    { 2, 140f, 380f, 320f, 260f },
                    { 3, 140f, 270f, 50f, 260f },
                    { 4, 140f, 300f, 700f, 260f },
                    { 6, 140f, 280f, 720f, 30f },
                    { 7, 90f, 150f, 50f, 170f },
                    { 5, 140f, 270f, 50f, 30f },
                    { 9, 140f, 400f, 260f, 230f },
                    { 10, 240f, 180f, 30f, 130f },
                    { 11, 140f, 300f, 700f, 230f },
                    { 12, 70f, 200f, 30f, 30f },
                    { 8, 140f, 400f, 260f, 30f }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "FloorId", "Name", "PositionId", "Type" },
                values: new object[,]
                {
                    { 50, "Room description...", 8, "Operation room", 1, 1 },
                    { 45, "Room description...", 7, "Room for appointments", 3, 0 },
                    { 49, "Room description...", 7, "WC", 7, 2 },
                    { 48, "Room description...", 7, "Room for appointments", 6, 0 },
                    { 47, "Room description...", 7, "Room for appointments", 5, 0 },
                    { 46, "Room description...", 7, "Room for appointments", 4, 0 },
                    { 44, "Room description...", 7, "Room for appointments", 2, 0 },
                    { 38, "Room description...", 6, "Room for appointments", 3, 0 },
                    { 42, "Room description...", 6, "WC", 7, 2 },
                    { 41, "Room description...", 6, "Room for appointments", 6, 0 },
                    { 40, "Room description...", 6, "Room for appointments", 5, 0 },
                    { 39, "Room description...", 6, "Room for appointments", 4, 0 },
                    { 37, "Room description...", 6, "Room for appointments", 2, 0 },
                    { 51, "Room description...", 8, "Room for appointments", 2, 0 },
                    { 43, "Room description...", 7, "Operation room", 1, 1 },
                    { 52, "Room description...", 8, "Room for appointments", 3, 0 },
                    { 67, "Room description...", 10, "Room for appointments", 4, 0 },
                    { 54, "Room description...", 8, "Room for appointments", 5, 0 },
                    { 68, "Room description...", 10, "Room for appointments", 5, 0 },
                    { 36, "Room description...", 6, "Operation room", 1, 1 },
                    { 66, "Room description...", 10, "Room for appointments", 3, 0 },
                    { 65, "Room description...", 10, "Room for appointments", 2, 0 },
                    { 64, "Room description...", 10, "Operation room", 1, 1 },
                    { 63, "Room description...", 9, "WC", 7, 2 },
                    { 53, "Room description...", 8, "Room for appointments", 4, 0 },
                    { 62, "Room description...", 9, "Room for appointments", 6, 0 },
                    { 60, "Room description...", 9, "Room for appointments", 4, 0 },
                    { 59, "Room description...", 9, "Room for appointments", 3, 0 },
                    { 58, "Room description...", 9, "Room for appointments", 2, 0 },
                    { 57, "Room description...", 9, "Operation room", 1, 1 },
                    { 56, "Room description...", 8, "WC", 7, 2 },
                    { 55, "Room description...", 8, "Room for appointments", 6, 0 },
                    { 61, "Room description...", 9, "Room for appointments", 5, 0 },
                    { 35, "Room description...", 5, "WC", 7, 2 },
                    { 20, "Room description...", 3, "Room for appointments", 6, 0 },
                    { 33, "Room description...", 5, "Room for appointments", 5, 0 },
                    { 14, "Room description...", 2, "WC", 7, 2 },
                    { 13, "Room description...", 2, "Room for appointments", 6, 0 },
                    { 12, "Room description...", 2, "Room for appointments", 5, 0 },
                    { 11, "Room description...", 2, "Room for appointments", 4, 0 },
                    { 10, "Room description...", 2, "Room for appointments", 3, 0 },
                    { 9, "Room description...", 2, "Room for appointments", 2, 0 },
                    { 15, "Room description...", 3, "Operation room", 1, 1 },
                    { 8, "Room description...", 2, "Operation room", 1, 1 },
                    { 6, "Room description...", 1, "Room for appointments", 6, 0 },
                    { 5, "Room description...", 1, "Room for appointments", 5, 0 },
                    { 4, "Room description...", 1, "Room for appointments", 4, 0 },
                    { 3, "Room description...", 1, "Room for appointments", 3, 0 },
                    { 2, "Room description...", 1, "Room for appointments", 2, 0 },
                    { 1, "Room description...", 1, "Operation room", 1, 1 },
                    { 7, "Room description...", 1, "WC", 7, 2 },
                    { 34, "Room description...", 5, "Room for appointments", 6, 0 },
                    { 16, "Room description...", 3, "Room for appointments", 2, 0 },
                    { 18, "Room description...", 3, "Room for appointments", 4, 0 },
                    { 32, "Room description...", 5, "Room for appointments", 4, 0 },
                    { 31, "Room description...", 5, "Room for appointments", 3, 0 },
                    { 30, "Room description...", 5, "Room for appointments", 2, 0 },
                    { 29, "Room description...", 5, "Operation room", 1, 1 },
                    { 28, "Room description...", 4, "WC", 7, 2 },
                    { 27, "Room description...", 4, "Room for appointments", 6, 0 },
                    { 17, "Room description...", 3, "Room for appointments", 3, 0 },
                    { 26, "Room description...", 4, "Room for appointments", 5, 0 },
                    { 24, "Room description...", 4, "Room for appointments", 3, 0 },
                    { 23, "Room description...", 4, "Room for appointments", 2, 0 },
                    { 22, "Room description...", 4, "Operation room", 1, 1 },
                    { 21, "Room description...", 3, "WC", 7, 2 },
                    { 69, "Room description...", 10, "Room for appointments", 6, 0 },
                    { 19, "Room description...", 3, "Room for appointments", 5, 0 },
                    { 25, "Room description...", 4, "Room for appointments", 4, 0 },
                    { 70, "Room description...", 10, "WC", 7, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
