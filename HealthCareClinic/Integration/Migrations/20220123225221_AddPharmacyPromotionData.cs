using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class AddPharmacyPromotionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PharmacyPromotions",
                columns: new[] { "Id", "Content", "EndTime", "PharmacyName", "Posted", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1, "Samo danas i sutra AKCIJA: Brufen 30% snizenje!!!", new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tilda", true, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale" },
                    { 2, "Od sutra stupa novi lek na trziste -> VIJAGRA samo tada", new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "BENU", true, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "New season" },
                    { 3, "Finalna rasprodaja lekova...", new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biljana i Luka", true, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale" },
                    { 4, "Petkom idite u apoteku 'Jankovic'", new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jankovic", true, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black friday" },
                    { 5, "Grrrr strasan demetrin", new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medico", true, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween action" },
                    { 6, "Svugde podji, u Rodu dodji", new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roda", true, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PharmacyPromotions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PharmacyPromotions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PharmacyPromotions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PharmacyPromotions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PharmacyPromotions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PharmacyPromotions",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
