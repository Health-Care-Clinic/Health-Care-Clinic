using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class SecondMigrationPatientPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FeedbackMessages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false),
                    Done = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_survey_appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "surveyCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SurveyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveyCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_surveyCategory_survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "surveyQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    SurveyCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveyQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_surveyQuestion_surveyCategory_SurveyCategoryId",
                        column: x => x.SurveyCategoryId,
                        principalTable: "surveyCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FeedbackMessages",
                columns: new[] { "Id", "CanBePublished", "Date", "Identity", "IsAnonymous", "IsPublished", "Text" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 4, 29, 18, 34, 21, 0, DateTimeKind.Unspecified), "acaNikolic", false, false, "Zadovoljan sam uslugom." },
                    { 2, true, new DateTime(2021, 6, 21, 14, 21, 56, 0, DateTimeKind.Unspecified), "NikolaTodorovic94", true, false, "Čekanje je moglo biti kraće." },
                    { 3, false, new DateTime(2021, 2, 16, 11, 8, 47, 0, DateTimeKind.Unspecified), "MarijaPopovic", false, false, "Informacionom sistemu potrebne su određene popravke." },
                    { 4, true, new DateTime(2021, 5, 20, 9, 10, 21, 0, DateTimeKind.Unspecified), "UrosDevic0", false, false, "Odlični lekari." },
                    { 5, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "MladenAlicic1", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 6, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "IvanJovanovic", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 7, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "JovanaGugl", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 8, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "RatkoVarda8", false, true, "Savremena bolnica koju bih preporučio ljudima." }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "Id", "DoctorId", "PatientId", "RoomId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "survey",
                columns: new[] { "Id", "AppointmentId", "Done" },
                values: new object[] { 1, 1, true });

            migrationBuilder.InsertData(
                table: "surveyCategory",
                columns: new[] { "Id", "Name", "SurveyId" },
                values: new object[,]
                {
                    { 1, "Doctor", 1 },
                    { 2, "Medical stuff", 1 },
                    { 3, "Hospital", 1 }
                });

            migrationBuilder.InsertData(
                table: "surveyQuestion",
                columns: new[] { "Id", "Content", "Grade", "SurveyCategoryId" },
                values: new object[,]
                {
                    { 1, "How careful did doctor listen you?", 1, 1 },
                    { 2, "Has doctor been polite?", 3, 1 },
                    { 3, "Has he explained you your condition enough that you can understand it?", 4, 1 },
                    { 4, "How would you rate doctors' professionalism?", 5, 1 },
                    { 5, "Your general grade for doctors' service", 3, 1 },
                    { 6, "How much our medical staff were polite?", 2, 2 },
                    { 7, "How would you rate time span that you spend waiting untill doctor attended you?", 3, 2 },
                    { 8, "How prepared were stuff for emergency situations?", 4, 2 },
                    { 9, "How good has stuff explained you our procedures?", 5, 2 },
                    { 10, "Your general grade for medical stuffs' service", 3, 2 },
                    { 11, "How would you rate our appointment organisation?", 1, 3 },
                    { 12, "How would you rate hospitals' hygiene?", 4, 3 },
                    { 13, "How good were procedure for booking appointment?", 4, 3 },
                    { 14, "How easy was to use our application?", 5, 3 },
                    { 15, "Your general grade for whole hospital' service", 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_survey_AppointmentId",
                table: "survey",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_surveyCategory_SurveyId",
                table: "surveyCategory",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_surveyQuestion_SurveyCategoryId",
                table: "surveyQuestion",
                column: "SurveyCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "surveyQuestion");

            migrationBuilder.DropTable(
                name: "surveyCategory");

            migrationBuilder.DropTable(
                name: "survey");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FeedbackMessages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "FeedbackMessages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "FeedbackMessages",
                columns: new[] { "Id", "CanBePublished", "Date", "Identity", "IsAnonymous", "IsPublished", "Text" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2021, 4, 29, 18, 34, 21, 0, DateTimeKind.Unspecified), "acaNikolic", false, false, "Zadovoljan sam uslugom." },
                    { 2L, true, new DateTime(2021, 6, 21, 14, 21, 56, 0, DateTimeKind.Unspecified), "NikolaTodorovic94", true, false, "Čekanje je moglo biti kraće." },
                    { 3L, false, new DateTime(2021, 2, 16, 11, 8, 47, 0, DateTimeKind.Unspecified), "MarijaPopovic", false, false, "Informacionom sistemu potrebne su određene popravke." },
                    { 4L, true, new DateTime(2021, 5, 20, 9, 10, 21, 0, DateTimeKind.Unspecified), "UrosDevic0", false, false, "Odlični lekari." },
                    { 5L, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "MladenAlicic1", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 6L, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "IvanJovanovic", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 7L, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "JovanaGugl", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 8L, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "RatkoVarda8", false, true, "Savremena bolnica koju bih preporučio ljudima." }
                });
        }
    }
}
