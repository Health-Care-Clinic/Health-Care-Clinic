using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "CompatibileMedicine",
                table: "Medicines",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Reactions",
                table: "Medicines",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "SideEffects",
                table: "Medicines",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usage",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Medicines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Manufacturer", "Usage", "Weight" },
                values: new object[] { "Galenika", "Lek BRUFEN se može kratkotrajno upotrebljavati u terapiji bolnih stanja poput zubobolje, bolova nakon operativnih zahvata, bolnih menstruacija i glavobolje (uključujući migrenu).Brufen može da se koristi kod povreda mekih tkiva kao što su uganuća i istegnuća.Aktivna supstanca leka BRUFEN je ibuprofen i svaka tableta sadrži 200 mg ibuprofena", 200 });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Manufacturer", "Usage", "Weight" },
                values: new object[] { "Galenika", "Klacid tablete se koriste za lečenje infekcija kao što su infekcije donjih disajnih puteva pluća, kao što je bronhitis i zapaljenje pluća, infekcije gornjih disajnih puteva kao što je infekcija grla i sinusa, infekcije kože i mekih tkiva, infekcije Helicobacter pylori kod pacijenata sa čirom na dvanaestopalačnom crevu Lek Klacid MR namenjen je odraslima i deci", 200 });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Manufacturer", "Usage", "Weight" },
                values: new object[] { "Galenika", "Paracetamol je blag analgetik i antipiretik. Upotreba tableta se preporučuje za lečenje bolnih i febrilnih stanja kao što su glavobolja(uključujući i migrenu i tenzionu glavobolju), zubobolja, bol u leđima, reumatski, bolovi i bolovi u mišićima, dismenoreja, bol u grlu, kao i za ublažavanje groznice, odnosno tegoba i bolova koji prate prehladu i grip.Lek se takođe može koristiti kao simptomatska terapija kod bolova povezanih sa osteoartritisom", 200 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompatibileMedicine",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Reactions",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "SideEffects",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Usage",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Medicines");
        }
    }
}
