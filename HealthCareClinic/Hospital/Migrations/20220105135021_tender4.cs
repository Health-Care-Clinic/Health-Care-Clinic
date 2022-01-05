using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class tender4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropColumn(
                name: "ForeignId",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "IsWinningBidChosen",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "TotalPrice_Amount",
                table: "Tenders");

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
                    TotalPrice_Amount = table.Column<double>(type: "double precision", nullable: true),
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

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice_Amount",
                table: "Tenders",
                type: "double precision",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    TenderId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompatibileMedicine = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Reactions = table.Column<string>(type: "text", nullable: true),
                    SideEffects = table.Column<string>(type: "text", nullable: true),
                    Usage = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => new { x.TenderId, x.Id });
                    table.ForeignKey(
                        name: "FK_Medicine_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
