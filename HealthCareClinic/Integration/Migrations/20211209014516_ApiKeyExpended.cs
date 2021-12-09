using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class ApiKeyExpended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ApiKeys",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ApiKeys",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ApiKeys");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "ApiKeys");
        }
    }
}
