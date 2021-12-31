using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class tender2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRange_End",
                table: "Tenders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRange_Start",
                table: "Tenders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice_Amount",
                table: "Tenders",
                type: "double precision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRange_End",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "DateRange_Start",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "TotalPrice_Amount",
                table: "Tenders");
        }
    }
}
