using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Pharmacy.Migrations
{
    public partial class tender3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Tenders_TenderId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_TenderId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ForeignId",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "IsWinningBidChosen",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "TenderId",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "TenderResponseDescription",
                table: "Tenders",
                newName: "Description");

            migrationBuilder.CreateTable(
                name: "TenderResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenderId = table.Column<int>(type: "integer", nullable: false),
                    PharmacyName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsWinningBid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenders_TenderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenderId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders_TenderItems", x => new { x.TenderId, x.Id });
                    table.ForeignKey(
                        name: "FK_Tenders_TenderItems_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenderResponses_TenderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenderResponseId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderResponses_TenderItems", x => new { x.TenderResponseId, x.Id });
                    table.ForeignKey(
                        name: "FK_TenderResponses_TenderItems_TenderResponses_TenderResponseId",
                        column: x => x.TenderResponseId,
                        principalTable: "TenderResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenderResponses_TenderItems");

            migrationBuilder.DropTable(
                name: "Tenders_TenderItems");

            migrationBuilder.DropTable(
                name: "TenderResponses");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tenders",
                newName: "TenderResponseDescription");

            migrationBuilder.AddColumn<int>(
                name: "ForeignId",
                table: "Tenders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsWinningBidChosen",
                table: "Tenders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TenderId",
                table: "Medicines",
                type: "integer",
                nullable: true);

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
    }
}
