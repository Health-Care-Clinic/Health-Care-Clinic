using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class PatientPortalFourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialty_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Survey_Appointment_AppointmentId",
                table: "Survey");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyCategory_Survey_SurveyId",
                table: "SurveyCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestion_SurveyCategory_SurveyCategoryId",
                table: "SurveyQuestion");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyQuestion",
                table: "SurveyQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyCategory",
                table: "SurveyCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Survey",
                table: "Survey");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.DeleteData(
                table: "Transfer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "VacationTimeStart",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "SurveyQuestion",
                newName: "SurveyQuestions");

            migrationBuilder.RenameTable(
                name: "SurveyCategory",
                newName: "SurveyCategories");

            migrationBuilder.RenameTable(
                name: "Survey",
                newName: "Surveys");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyQuestion_SurveyCategoryId",
                table: "SurveyQuestions",
                newName: "IX_SurveyQuestions_SurveyCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyCategory_SurveyId",
                table: "SurveyCategories",
                newName: "IX_SurveyCategories_SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_Survey_AppointmentId",
                table: "Surveys",
                newName: "IX_Surveys_AppointmentId");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Doctors",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyQuestions",
                table: "SurveyQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyCategories",
                table: "SurveyCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "SurveyId" },
                values: new object[] { new DateTime(2022, 2, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "RoomId", "SurveyId", "isCancelled", "isDone" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 2, 22, 7, 30, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 2, false, false },
                    { 3, new DateTime(2022, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 1, 3, false, false },
                    { 4, new DateTime(2022, 2, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 4, 1, 4, false, false },
                    { 5, new DateTime(2022, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 1, 5, false, false },
                    { 6, new DateTime(2022, 2, 22, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 6, 1, 6, false, false },
                    { 7, new DateTime(2022, 2, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, 1, 7, false, false },
                    { 8, new DateTime(2022, 2, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 8, 1, 8, false, false },
                    { 9, new DateTime(2022, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 9, false, false },
                    { 10, new DateTime(2021, 2, 22, 11, 30, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 10, false, true }
                });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Specialty",
                value: "General medicine");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Specialty",
                value: "General medicine");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Specialty",
                value: "General medicine");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Specialty",
                value: "Surgery");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Specialty",
                value: "Surgery");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Specialty",
                value: "General medicine");

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Grade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 1,
                column: "Done",
                value: false);

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "AppointmentId", "Done" },
                values: new object[,]
                {
                    { 2, 2, false },
                    { 3, 3, false },
                    { 4, 4, false },
                    { 5, 5, false },
                    { 6, 6, false },
                    { 7, 7, false },
                    { 8, 8, false },
                    { 9, 9, false },
                    { 10, 10, true }
                });

            migrationBuilder.InsertData(
                table: "SurveyCategories",
                columns: new[] { "Id", "Name", "SurveyId" },
                values: new object[,]
                {
                    { 4, "Doctor", 2 },
                    { 28, "Doctor", 10 },
                    { 27, "Hospital", 9 },
                    { 26, "Medical stuff", 9 },
                    { 25, "Doctor", 9 },
                    { 24, "Hospital", 8 },
                    { 23, "Medical stuff", 8 },
                    { 22, "Doctor", 8 },
                    { 21, "Hospital", 7 },
                    { 20, "Medical stuff", 7 },
                    { 19, "Doctor", 7 },
                    { 18, "Hospital", 6 },
                    { 29, "Medical stuff", 10 },
                    { 17, "Medical stuff", 6 },
                    { 15, "Hospital", 5 },
                    { 14, "Medical stuff", 5 },
                    { 13, "Doctor", 5 },
                    { 12, "Hospital", 4 },
                    { 11, "Medical stuff", 4 },
                    { 10, "Doctor", 4 },
                    { 9, "Hospital", 3 },
                    { 8, "Medical stuff", 3 },
                    { 7, "Doctor", 3 },
                    { 6, "Hospital", 2 },
                    { 5, "Medical stuff", 2 },
                    { 16, "Doctor", 6 },
                    { 30, "Hospital", 10 }
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "Content", "Grade", "SurveyCategoryId" },
                values: new object[,]
                {
                    { 16, "How careful did doctor listen you?", 0, 4 },
                    { 114, "How good has stuff explained you our procedures?", 0, 23 },
                    { 113, "How prepared were stuff for emergency situations?", 0, 23 },
                    { 112, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 23 },
                    { 111, "How much our medical staff were polite?", 0, 23 },
                    { 110, "Your general grade for doctors' service", 0, 22 },
                    { 109, "How would you rate doctors' professionalism?", 0, 22 },
                    { 108, "Has he explained you your condition enough that you can understand it?", 0, 22 },
                    { 107, "Has doctor been polite?", 0, 22 },
                    { 106, "How careful did doctor listen you?", 0, 22 },
                    { 105, "Your general grade for whole hospital' service", 0, 21 },
                    { 104, "How easy was to use our application?", 0, 21 },
                    { 103, "How good were procedure for booking appointment?", 0, 21 },
                    { 102, "How would you rate hospitals' hygiene?", 0, 21 },
                    { 101, "How would you rate our appointment organisation?", 0, 21 },
                    { 115, "Your general grade for medical stuffs' service", 0, 23 },
                    { 100, "Your general grade for medical stuffs' service", 0, 20 },
                    { 98, "How prepared were stuff for emergency situations?", 0, 20 },
                    { 97, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 20 },
                    { 96, "How much our medical staff were polite?", 0, 20 },
                    { 95, "Your general grade for doctors' service", 0, 19 },
                    { 94, "How would you rate doctors' professionalism?", 0, 19 },
                    { 93, "Has he explained you your condition enough that you can understand it?", 0, 19 },
                    { 92, "Has doctor been polite?", 0, 19 },
                    { 91, "How careful did doctor listen you?", 0, 19 },
                    { 90, "Your general grade for whole hospital' service", 0, 18 },
                    { 89, "How easy was to use our application?", 0, 18 },
                    { 88, "How good were procedure for booking appointment?", 0, 18 },
                    { 87, "How would you rate hospitals' hygiene?", 0, 18 },
                    { 86, "How would you rate our appointment organisation?", 0, 18 },
                    { 85, "Your general grade for medical stuffs' service", 0, 17 },
                    { 99, "How good has stuff explained you our procedures?", 0, 20 },
                    { 84, "How good has stuff explained you our procedures?", 0, 17 },
                    { 116, "How would you rate our appointment organisation?", 0, 24 },
                    { 118, "How good were procedure for booking appointment?", 0, 24 },
                    { 148, "How good were procedure for booking appointment?", 4, 30 },
                    { 147, "How would you rate hospitals' hygiene?", 4, 30 },
                    { 146, "How would you rate our appointment organisation?", 1, 30 },
                    { 145, "Your general grade for medical stuffs' service", 3, 29 },
                    { 144, "How good has stuff explained you our procedures?", 5, 29 },
                    { 143, "How prepared were stuff for emergency situations?", 4, 29 },
                    { 142, "How would you rate time span that you spend waiting untill doctor attended you?", 3, 29 },
                    { 141, "How much our medical staff were polite?", 2, 29 },
                    { 140, "Your general grade for doctors' service", 3, 28 },
                    { 139, "How would you rate doctors' professionalism?", 5, 28 },
                    { 138, "Has he explained you your condition enough that you can understand it?", 4, 28 },
                    { 137, "Has doctor been polite?", 3, 28 },
                    { 136, "How careful did doctor listen you?", 1, 28 },
                    { 135, "Your general grade for whole hospital' service", 0, 27 },
                    { 117, "How would you rate hospitals' hygiene?", 0, 24 },
                    { 134, "How easy was to use our application?", 0, 27 },
                    { 132, "How would you rate hospitals' hygiene?", 0, 27 },
                    { 131, "How would you rate our appointment organisation?", 0, 27 },
                    { 130, "Your general grade for medical stuffs' service", 0, 26 },
                    { 129, "How good has stuff explained you our procedures?", 0, 26 },
                    { 128, "How prepared were stuff for emergency situations?", 0, 26 },
                    { 127, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 26 },
                    { 126, "How much our medical staff were polite?", 0, 26 },
                    { 125, "Your general grade for doctors' service", 0, 25 },
                    { 124, "How would you rate doctors' professionalism?", 0, 25 },
                    { 123, "Has he explained you your condition enough that you can understand it?", 0, 25 },
                    { 122, "Has doctor been polite?", 0, 25 },
                    { 121, "How careful did doctor listen you?", 0, 25 },
                    { 120, "Your general grade for whole hospital' service", 0, 24 },
                    { 119, "How easy was to use our application?", 0, 24 },
                    { 133, "How good were procedure for booking appointment?", 0, 27 },
                    { 149, "How easy was to use our application?", 5, 30 },
                    { 83, "How prepared were stuff for emergency situations?", 0, 17 },
                    { 81, "How much our medical staff were polite?", 0, 17 },
                    { 46, "How careful did doctor listen you?", 0, 10 },
                    { 45, "Your general grade for whole hospital' service", 0, 9 },
                    { 44, "How easy was to use our application?", 0, 9 },
                    { 43, "How good were procedure for booking appointment?", 0, 9 },
                    { 42, "How would you rate hospitals' hygiene?", 0, 9 },
                    { 41, "How would you rate our appointment organisation?", 0, 9 },
                    { 40, "Your general grade for medical stuffs' service", 0, 8 },
                    { 39, "How good has stuff explained you our procedures?", 0, 8 },
                    { 38, "How prepared were stuff for emergency situations?", 0, 8 },
                    { 37, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 8 },
                    { 36, "How much our medical staff were polite?", 0, 8 },
                    { 35, "Your general grade for doctors' service", 0, 7 },
                    { 34, "How would you rate doctors' professionalism?", 0, 7 },
                    { 33, "Has he explained you your condition enough that you can understand it?", 0, 7 },
                    { 47, "Has doctor been polite?", 0, 10 },
                    { 32, "Has doctor been polite?", 0, 7 },
                    { 30, "Your general grade for whole hospital' service", 0, 6 },
                    { 29, "How easy was to use our application?", 0, 6 },
                    { 28, "How good were procedure for booking appointment?", 0, 6 },
                    { 27, "How would you rate hospitals' hygiene?", 0, 6 },
                    { 26, "How would you rate our appointment organisation?", 0, 6 },
                    { 25, "Your general grade for medical stuffs' service", 0, 5 },
                    { 24, "How good has stuff explained you our procedures?", 0, 5 },
                    { 23, "How prepared were stuff for emergency situations?", 0, 5 },
                    { 22, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 5 },
                    { 21, "How much our medical staff were polite?", 0, 5 },
                    { 20, "Your general grade for doctors' service", 0, 4 },
                    { 19, "How would you rate doctors' professionalism?", 0, 4 },
                    { 18, "Has he explained you your condition enough that you can understand it?", 0, 4 },
                    { 17, "Has doctor been polite?", 0, 4 },
                    { 31, "How careful did doctor listen you?", 0, 7 },
                    { 82, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 17 },
                    { 48, "Has he explained you your condition enough that you can understand it?", 0, 10 },
                    { 50, "Your general grade for doctors' service", 0, 10 },
                    { 80, "Your general grade for doctors' service", 0, 16 },
                    { 79, "How would you rate doctors' professionalism?", 0, 16 },
                    { 78, "Has he explained you your condition enough that you can understand it?", 0, 16 },
                    { 77, "Has doctor been polite?", 0, 16 },
                    { 76, "How careful did doctor listen you?", 0, 16 },
                    { 75, "Your general grade for whole hospital' service", 0, 15 },
                    { 74, "How easy was to use our application?", 0, 15 },
                    { 73, "How good were procedure for booking appointment?", 0, 15 },
                    { 72, "How would you rate hospitals' hygiene?", 0, 15 },
                    { 71, "How would you rate our appointment organisation?", 0, 15 },
                    { 70, "Your general grade for medical stuffs' service", 0, 14 },
                    { 69, "How good has stuff explained you our procedures?", 0, 14 },
                    { 68, "How prepared were stuff for emergency situations?", 0, 14 },
                    { 67, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 14 },
                    { 49, "How would you rate doctors' professionalism?", 0, 10 },
                    { 66, "How much our medical staff were polite?", 0, 14 },
                    { 64, "How would you rate doctors' professionalism?", 0, 13 },
                    { 63, "Has he explained you your condition enough that you can understand it?", 0, 13 },
                    { 62, "Has doctor been polite?", 0, 13 },
                    { 61, "How careful did doctor listen you?", 0, 13 },
                    { 60, "Your general grade for whole hospital' service", 0, 12 },
                    { 59, "How easy was to use our application?", 0, 12 },
                    { 58, "How good were procedure for booking appointment?", 0, 12 },
                    { 57, "How would you rate hospitals' hygiene?", 0, 12 },
                    { 56, "How would you rate our appointment organisation?", 0, 12 },
                    { 55, "Your general grade for medical stuffs' service", 0, 11 },
                    { 54, "How good has stuff explained you our procedures?", 0, 11 },
                    { 53, "How prepared were stuff for emergency situations?", 0, 11 },
                    { 52, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 11 },
                    { 51, "How much our medical staff were polite?", 0, 11 },
                    { 65, "Your general grade for doctors' service", 0, 13 },
                    { 150, "Your general grade for whole hospital' service", 3, 30 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyCategories_Surveys_SurveyId",
                table: "SurveyCategories",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestions_SurveyCategories_SurveyCategoryId",
                table: "SurveyQuestions",
                column: "SurveyCategoryId",
                principalTable: "SurveyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Appointments_AppointmentId",
                table: "Surveys",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyCategories_Surveys_SurveyId",
                table: "SurveyCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestions_SurveyCategories_SurveyCategoryId",
                table: "SurveyQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Appointments_AppointmentId",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyQuestions",
                table: "SurveyQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyCategories",
                table: "SurveyCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "SurveyQuestions",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SurveyCategories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Surveys",
                newName: "Survey");

            migrationBuilder.RenameTable(
                name: "SurveyQuestions",
                newName: "SurveyQuestion");

            migrationBuilder.RenameTable(
                name: "SurveyCategories",
                newName: "SurveyCategory");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Surveys_AppointmentId",
                table: "Survey",
                newName: "IX_Survey_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyQuestions_SurveyCategoryId",
                table: "SurveyQuestion",
                newName: "IX_SurveyQuestion_SurveyCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyCategories_SurveyId",
                table: "SurveyCategory",
                newName: "IX_SurveyCategory_SurveyId");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "VacationTimeStart",
                table: "Doctors",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Survey",
                table: "Survey",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyQuestion",
                table: "SurveyQuestion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyCategory",
                table: "SurveyCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.SpecialtyId);
                });

            migrationBuilder.UpdateData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "SurveyId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.InsertData(
                table: "Specialty",
                columns: new[] { "SpecialtyId", "Name" },
                values: new object[,]
                {
                    { 1, "General medicine" },
                    { 2, "Surgery" }
                });

            migrationBuilder.UpdateData(
                table: "Survey",
                keyColumn: "Id",
                keyValue: 1,
                column: "Done",
                value: true);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 1,
                column: "Grade",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 2,
                column: "Grade",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 3,
                column: "Grade",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 4,
                column: "Grade",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 5,
                column: "Grade",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 6,
                column: "Grade",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 7,
                column: "Grade",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 8,
                column: "Grade",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 9,
                column: "Grade",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 10,
                column: "Grade",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 11,
                column: "Grade",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 12,
                column: "Grade",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 13,
                column: "Grade",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 14,
                column: "Grade",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SurveyQuestion",
                keyColumn: "Id",
                keyValue: 15,
                column: "Grade",
                value: 3);

            migrationBuilder.InsertData(
                table: "Transfer",
                columns: new[] { "Id", "Date", "DestinationRoomId", "Duration", "Equipment", "Quantity", "SourceRoomId" },
                values: new object[] { 6, new DateTime(2022, 2, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 45, "TV", 1, 1 });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecialtyId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecialtyId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecialtyId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "SpecialtyId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "SpecialtyId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "SpecialtyId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialty_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_Appointment_AppointmentId",
                table: "Survey",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyCategory_Survey_SurveyId",
                table: "SurveyCategory",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestion_SurveyCategory_SurveyCategoryId",
                table: "SurveyQuestion",
                column: "SurveyCategoryId",
                principalTable: "SurveyCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
