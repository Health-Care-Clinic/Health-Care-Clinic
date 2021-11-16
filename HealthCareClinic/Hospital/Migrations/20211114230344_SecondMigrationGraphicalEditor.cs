using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class SecondMigrationGraphicalEditor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Buildings");

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Width",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "X",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Y",
                table: "Rooms",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Floors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Width",
                table: "Floors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "X",
                table: "Floors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Y",
                table: "Floors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Buildings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Width",
                table: "Buildings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "X",
                table: "Buildings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Y",
                table: "Buildings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 260f, 30f });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 260f, 230f });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 240f, 180f, 30f, 130f });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 230f });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 70f, 200f, 30f, 30f });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 70f, 200f, 800f, 30f });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 70f, 200f, 800f, 130f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 400f, 320f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 380f, 320f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 300f, 700f, 260f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 270f, 50f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 140f, 280f, 720f, 30f });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Height", "Width", "X", "Y" },
                values: new object[] { 90f, 150f, 50f, 170f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Floors");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Buildings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1,
                column: "PositionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2,
                column: "PositionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 3,
                column: "PositionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 4,
                column: "PositionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 5,
                column: "PositionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 6,
                column: "PositionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 7,
                column: "PositionId",
                value: 14);

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 140f, 400f, 320f, 30f },
                    { 14, 70f, 200f, 800f, 130f },
                    { 13, 70f, 200f, 800f, 30f },
                    { 12, 70f, 200f, 30f, 30f },
                    { 11, 140f, 300f, 700f, 230f },
                    { 9, 140f, 400f, 260f, 230f },
                    { 8, 140f, 400f, 260f, 30f },
                    { 7, 90f, 150f, 50f, 170f },
                    { 6, 140f, 280f, 720f, 30f },
                    { 5, 140f, 270f, 50f, 30f },
                    { 4, 140f, 300f, 700f, 260f },
                    { 3, 140f, 270f, 50f, 260f },
                    { 2, 140f, 380f, 320f, 260f },
                    { 10, 240f, 180f, 30f, 130f }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 25,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 26,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 27,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 28,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 29,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 30,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 31,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 32,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 33,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 34,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 35,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 36,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 37,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 38,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 39,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 40,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 41,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 42,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 43,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 44,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 45,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 46,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 47,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 48,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 49,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 50,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 51,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 52,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 53,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 54,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 55,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 56,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 57,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 58,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 59,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 60,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 61,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 62,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 63,
                column: "PositionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 64,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 65,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 66,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 67,
                column: "PositionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 68,
                column: "PositionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 69,
                column: "PositionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 70,
                column: "PositionId",
                value: 7);
        }
    }
}
