using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class FourthMigrationPatientPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergens_Patients_PatientId",
                table: "Allergens");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Allergens",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 1,
                column: "PatientId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 2,
                column: "PatientId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 3,
                column: "PatientId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 4,
                column: "PatientId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 5,
                column: "PatientId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 6,
                column: "PatientId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 7,
                column: "PatientId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 8,
                column: "PatientId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 9,
                column: "PatientId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 10,
                column: "PatientId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Allergens_Patients_PatientId",
                table: "Allergens",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergens_Patients_PatientId",
                table: "Allergens");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Allergens",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 1,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 2,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 3,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 4,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 5,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 6,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 7,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 8,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 9,
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Allergens",
                keyColumn: "Id",
                keyValue: 10,
                column: "PatientId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Allergens_Patients_PatientId",
                table: "Allergens",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
