using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class AddedPerscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Prescriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "RoomId", "SurveyId", "isCancelled", "isDone" },
                values: new object[,]
                {
                    { 25, new DateTime(2022, 1, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1, 25, false, false },
                    { 26, new DateTime(2022, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3, 26, false, false },
                    { 27, new DateTime(2022, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, 27, false, false }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "AppointmentId", "Date", "Diagnosis", "Medicine", "PatientId", "Quantity" },
                values: new object[,]
                {
                    { 1, 25, new DateTime(2022, 1, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), "Uzimati 1 put dnevno do poboljsanja", "Panklav", 1, 300 },
                    { 2, 26, new DateTime(2022, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "Uzimati 2 put dnevno do poboljsanja", "Brufen", 1, 200 },
                    { 3, 27, new DateTime(2022, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Uzimati 3 put dnevno do poboljsanja", "Kafetin", 1, 400 }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "AppointmentId", "Done" },
                values: new object[,]
                {
                    { 25, 25, false },
                    { 26, 26, false },
                    { 27, 27, false }
                });

            migrationBuilder.InsertData(
                table: "SurveyCategories",
                columns: new[] { "Id", "Name", "SurveyId" },
                values: new object[,]
                {
                    { 73, "Doctor", 25 },
                    { 74, "Medical stuff", 25 },
                    { 75, "Hospital", 25 },
                    { 76, "Doctor", 26 },
                    { 77, "Medical stuff", 26 },
                    { 78, "Hospital", 26 },
                    { 79, "Doctor", 27 },
                    { 80, "Medical stuff", 27 },
                    { 81, "Hospital", 27 }
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "Content", "Grade", "SurveyCategoryId" },
                values: new object[,]
                {
                    { 361, "How careful did doctor listen you?", 0, 73 },
                    { 385, "Your general grade for medical stuffs' service", 0, 77 },
                    { 386, "How would you rate our appointment organisation?", 0, 78 },
                    { 387, "How would you rate hospitals' hygiene?", 0, 78 },
                    { 388, "How good were procedure for booking appointment?", 0, 78 },
                    { 389, "How easy was to use our application?", 0, 78 },
                    { 390, "Your general grade for whole hospital' service", 0, 78 },
                    { 391, "How careful did doctor listen you?", 0, 79 },
                    { 392, "Has doctor been polite?", 0, 79 },
                    { 393, "Has he explained you your condition enough that you can understand it?", 0, 79 },
                    { 394, "How would you rate doctors' professionalism?", 0, 79 },
                    { 395, "Your general grade for doctors' service", 0, 79 },
                    { 396, "How much our medical staff were polite?", 0, 80 },
                    { 397, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 80 },
                    { 398, "How prepared were stuff for emergency situations?", 0, 80 },
                    { 399, "How good has stuff explained you our procedures?", 0, 80 },
                    { 400, "Your general grade for medical stuffs' service", 0, 80 },
                    { 401, "How would you rate our appointment organisation?", 0, 81 },
                    { 402, "How would you rate hospitals' hygiene?", 0, 81 },
                    { 403, "How good were procedure for booking appointment?", 0, 81 },
                    { 384, "How good has stuff explained you our procedures?", 0, 77 },
                    { 404, "How easy was to use our application?", 0, 81 },
                    { 383, "How prepared were stuff for emergency situations?", 0, 77 },
                    { 381, "How much our medical staff were polite?", 0, 77 },
                    { 362, "Has doctor been polite?", 0, 73 },
                    { 363, "Has he explained you your condition enough that you can understand it?", 0, 73 },
                    { 364, "How would you rate doctors' professionalism?", 0, 73 },
                    { 365, "Your general grade for doctors' service", 0, 73 },
                    { 366, "How much our medical staff were polite?", 0, 74 },
                    { 367, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 74 },
                    { 368, "How prepared were stuff for emergency situations?", 0, 74 },
                    { 369, "How good has stuff explained you our procedures?", 0, 74 },
                    { 370, "Your general grade for medical stuffs' service", 0, 74 },
                    { 371, "How would you rate our appointment organisation?", 0, 75 },
                    { 372, "How would you rate hospitals' hygiene?", 0, 75 },
                    { 373, "How good were procedure for booking appointment?", 0, 75 },
                    { 374, "How easy was to use our application?", 0, 75 },
                    { 375, "Your general grade for whole hospital' service", 0, 75 },
                    { 376, "How careful did doctor listen you?", 0, 76 },
                    { 377, "Has doctor been polite?", 0, 76 },
                    { 378, "Has he explained you your condition enough that you can understand it?", 0, 76 },
                    { 379, "How would you rate doctors' professionalism?", 0, 76 },
                    { 380, "Your general grade for doctors' service", 0, 76 },
                    { 382, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 77 },
                    { 405, "Your general grade for whole hospital' service", 0, 81 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Appointments_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Appointments_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Prescriptions");
        }
    }
}
