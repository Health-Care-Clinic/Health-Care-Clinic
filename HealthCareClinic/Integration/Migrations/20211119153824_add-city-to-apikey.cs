using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class addcitytoapikey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ApiKeys",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "ApiKeys");
        }
    }
}
