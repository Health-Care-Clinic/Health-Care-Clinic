using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Pharmacy.Migrations
{
    public partial class Tender2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenderId",
                table: "Medicines",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ForeignId = table.Column<int>(type: "integer", nullable: false),
                    TenderResponseDescription = table.Column<string>(type: "text", nullable: true),
                    IsWinningBidChosen = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_TenderId",
                table: "Medicines",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Tenders_TenderId",
                table: "Medicines",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Tenders_TenderId",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_TenderId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "TenderId",
                table: "Medicines");
        }
    }
}
