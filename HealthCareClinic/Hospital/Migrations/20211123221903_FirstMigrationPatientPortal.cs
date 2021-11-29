using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class FirstMigrationPatientPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

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
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: false),
                    Identity = table.Column<string>(type: "text", nullable: true),
                    CanBePublished = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BuildingId = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FloorId = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

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
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VacationTimeStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorkShift = table.Column<int>(type: "integer", nullable: false),
                    SpecialtyId = table.Column<int>(type: "integer", nullable: false),
                    PrimaryRoom = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<double>(type: "double precision", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyId",
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
                name: "Day",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Spec_Day = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.DayId);
                    table.ForeignKey(
                        name: "FK_Day_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentName = table.Column<string>(type: "text", nullable: true),
                    DateOfRegistration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    BloodType = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    EmploymentStatus = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkDay_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "AllergenForPatients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AllergenId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenForPatients", x => new { x.PatientId, x.AllergenId });
                    table.ForeignKey(
                        name: "FK_AllergenForPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Kikiriki" },
                    { 10, "Školjke" },
                    { 9, "Jaja" },
                    { 8, "Kravlje mleko" },
                    { 6, "Lateks" },
                    { 5, "Mačija dlaka" },
                    { 4, "Penicilin" },
                    { 1, "Polen ambrozije" },
                    { 2, "Ibuprofen" },
                    { 3, "Aspirin" }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Height", "Name", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 140f, "Building1", 0, 400f, 260f, 30f },
                    { 6, 70f, "Parking2", 1, 200f, 800f, 30f },
                    { 5, 70f, "Parking1", 1, 200f, 30f, 30f },
                    { 4, 140f, "Building4", 0, 300f, 700f, 230f },
                    { 3, 240f, "Building3", 0, 180f, 30f, 130f },
                    { 2, 140f, "Building2", 0, 400f, 260f, 230f },
                    { 7, 70f, "Parking3", 1, 200f, 800f, 130f }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Name", "Quantity", "RoomId", "Type" },
                values: new object[,]
                {
                    { 43, "TV", 1, 52, 0 },
                    { 35, "Blanket", 9, 40, 0 },
                    { 36, "Bed", 9, 43, 0 },
                    { 37, "Needle", 9, 43, 1 },
                    { 38, "TV", 3, 45, 0 },
                    { 39, "Bandage", 9, 47, 1 },
                    { 40, "Blanket", 9, 47, 0 },
                    { 41, "Bed", 7, 50, 0 },
                    { 42, "Needle", 4, 51, 1 },
                    { 44, "Bandage", 11, 55, 1 },
                    { 53, "TV", 2, 68, 0 },
                    { 46, "Bed", 13, 60, 0 },
                    { 47, "Needle", 13, 60, 1 },
                    { 48, "TV", 2, 62, 0 },
                    { 49, "Bandage", 13, 62, 1 },
                    { 50, "Blanket", 13, 65, 0 },
                    { 52, "Needle", 17, 66, 1 },
                    { 34, "Bandage", 1, 40, 1 },
                    { 54, "Bandage", 17, 69, 1 },
                    { 55, "Blanket", 17, 69, 0 },
                    { 45, "Blanket", 15, 55, 0 },
                    { 33, "TV", 3, 40, 0 },
                    { 51, "Bed", 17, 65, 0 },
                    { 31, "Bed", 7, 36, 0 },
                    { 1, "Bed", 5, 1, 0 },
                    { 2, "Needle", 25, 1, 1 },
                    { 3, "TV", 1, 1, 0 },
                    { 4, "Bandage", 10, 1, 1 },
                    { 32, "Needle", 4, 36, 1 },
                    { 6, "Bed", 2, 2, 0 },
                    { 7, "Needle", 3, 2, 1 },
                    { 8, "TV", 3, 4, 0 },
                    { 9, "Bandage", 5, 4, 1 },
                    { 10, "Blanket", 2, 4, 0 },
                    { 11, "Bed", 25, 8, 0 },
                    { 12, "Needle", 3, 9, 1 },
                    { 13, "TV", 4, 9, 0 },
                    { 14, "Bandage", 6, 11, 1 },
                    { 15, "Blanket", 5, 11, 0 },
                    { 5, "Blanket", 5, 1, 0 },
                    { 28, "TV", 2, 29, 0 },
                    { 25, "Blanket", 1, 23, 0 },
                    { 24, "Bandage", 1, 23, 1 },
                    { 23, "TV", 1, 22, 0 },
                    { 22, "Needle", 1, 22, 1 },
                    { 21, "Bed", 1, 20, 0 },
                    { 29, "Bandage", 4, 30, 1 },
                    { 30, "Blanket", 4, 30, 0 },
                    { 26, "Bed", 3, 26, 0 },
                    { 27, "Needle", 2, 26, 1 },
                    { 16, "Bed", 26, 15, 0 },
                    { 20, "Blanket", 52, 18, 0 },
                    { 19, "Bandage", 120, 17, 1 },
                    { 18, "TV", 1, 17, 0 },
                    { 17, "Needle", 23, 17, 1 }
                });

            migrationBuilder.InsertData(
                table: "FeedbackMessages",
                columns: new[] { "Id", "CanBePublished", "Date", "Identity", "IsAnonymous", "IsPublished", "Text" },
                values: new object[,]
                {
                    { 7, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "JovanaGugl", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 8, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "RatkoVarda8", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 3, false, new DateTime(2021, 2, 16, 11, 8, 47, 0, DateTimeKind.Unspecified), "MarijaPopovic", false, false, "Informacionom sistemu potrebne su određene popravke." },
                    { 2, true, new DateTime(2021, 6, 21, 14, 21, 56, 0, DateTimeKind.Unspecified), "NikolaTodorovic94", true, false, "Čekanje je moglo biti kraće." },
                    { 1, true, new DateTime(2021, 4, 29, 18, 34, 21, 0, DateTimeKind.Unspecified), "acaNikolic", false, false, "Zadovoljan sam uslugom." },
                    { 5, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "MladenAlicic1", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 6, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "IvanJovanovic", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 4, true, new DateTime(2021, 5, 20, 9, 10, 21, 0, DateTimeKind.Unspecified), "UrosDevic0", false, false, "Odlični lekari." }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "BuildingId", "Height", "Name", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 10, 4, 0f, "Floor 2", 0f, 0f, 0f },
                    { 9, 4, 0f, "Floor 1", 0f, 0f, 0f },
                    { 8, 3, 0f, "Floor 3", 0f, 0f, 0f },
                    { 7, 3, 0f, "Floor 2", 0f, 0f, 0f },
                    { 6, 3, 0f, "Floor 1", 0f, 0f, 0f },
                    { 5, 2, 0f, "Floor 2", 0f, 0f, 0f },
                    { 4, 2, 0f, "Floor 1", 0f, 0f, 0f },
                    { 3, 1, 0f, "Floor 3", 0f, 0f, 0f },
                    { 2, 1, 0f, "Floor 2", 0f, 0f, 0f },
                    { 1, 1, 0f, "Floor 1", 0f, 0f, 0f }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "FloorId", "Height", "Name", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 56, "Room description...", 8, 90f, "WC", 2, 150f, 50f, 170f },
                    { 55, "Room description...", 8, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 54, "Room description...", 8, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 53, "Room description...", 8, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 52, "Room description...", 8, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 47, "Room description...", 7, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 50, "Room description...", 8, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 49, "Room description...", 7, 90f, "WC", 2, 150f, 50f, 170f },
                    { 48, "Room description...", 7, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 57, "Room description...", 9, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 51, "Room description...", 8, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 58, "Room description...", 9, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 46, "Room description...", 7, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 60, "Room description...", 9, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 61, "Room description...", 9, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 62, "Room description...", 9, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 63, "Room description...", 9, 90f, "WC", 2, 150f, 50f, 170f },
                    { 64, "Room description...", 10, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 65, "Room description...", 10, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 66, "Room description...", 10, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 67, "Room description...", 10, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 68, "Room description...", 10, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 69, "Room description...", 10, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 70, "Room description...", 10, 90f, "WC", 2, 150f, 50f, 170f },
                    { 59, "Room description...", 9, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 45, "Room description...", 7, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 10, "Room description...", 2, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 43, "Room description...", 7, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 19, "Room description...", 3, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 18, "Room description...", 3, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 17, "Room description...", 3, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 16, "Room description...", 3, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 15, "Room description...", 3, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 14, "Room description...", 2, 90f, "WC", 2, 150f, 50f, 170f },
                    { 13, "Room description...", 2, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 12, "Room description...", 2, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 20, "Room description...", 3, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 11, "Room description...", 2, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 8, "Room description...", 2, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 7, "Room description...", 1, 90f, "WC", 2, 150f, 50f, 170f },
                    { 6, "Room description...", 1, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 5, "Room description...", 1, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 4, "Room description...", 1, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 3, "Room description...", 1, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 2, "Room description...", 1, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 1, "Room description...", 1, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 9, "Room description...", 2, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 44, "Room description...", 7, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 21, "Room description...", 3, 90f, "WC", 2, 150f, 50f, 170f },
                    { 23, "Room description...", 4, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 40, "Room description...", 6, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 39, "Room description...", 6, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 38, "Room description...", 6, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 37, "Room description...", 6, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 36, "Room description...", 6, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 35, "Room description...", 5, 90f, "WC", 2, 150f, 50f, 170f },
                    { 34, "Room description...", 5, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 22, "Room description...", 4, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 41, "Room description...", 6, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 33, "Room description...", 5, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 31, "Room description...", 5, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 30, "Room description...", 5, 140f, "Room for appointments", 0, 380f, 320f, 260f },
                    { 29, "Room description...", 5, 140f, "Operation room", 1, 400f, 320f, 30f },
                    { 28, "Room description...", 4, 90f, "WC", 2, 150f, 50f, 170f },
                    { 27, "Room description...", 4, 140f, "Room for appointments", 0, 280f, 720f, 30f },
                    { 26, "Room description...", 4, 140f, "Room for appointments", 0, 270f, 50f, 30f },
                    { 25, "Room description...", 4, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 24, "Room description...", 4, 140f, "Room for appointments", 0, 270f, 50f, 260f },
                    { 32, "Room description...", 5, 140f, "Room for appointments", 0, 300f, 700f, 260f },
                    { 42, "Room description...", 6, 90f, "WC", 2, 150f, 50f, 170f }
                });

            migrationBuilder.InsertData(
                table: "Specialty",
                columns: new[] { "SpecialtyId", "Name" },
                values: new object[,]
                {
                    { 1, "General medicine" },
                    { 2, "Surgery" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "Id", "DoctorId", "PatientId", "RoomId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "BirthDate", "Email", "EmploymentDate", "Gender", "Name", "Password", "Phone", "PrimaryRoom", "Salary", "SpecialtyId", "Surname", "Username", "VacationTimeStart", "WorkShift" },
                values: new object[,]
                {
                    { 1, "Brace Radica 15", new DateTime(1981, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "nikolanikolic@gmail.com", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Nikola", "nikola", "0697856665", 1, 80000.0, 1, "Nikolic", "nikola", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "Bogoboja Atanackovica 5", new DateTime(1986, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "markoradic@gmail.com", new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Marko", "marko", "0697856665", 2, 80000.0, 1, "Radic", "marko", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, "Bulevar Oslobodjenja 5", new DateTime(1986, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "jozika@gmail.com", new DateTime(2011, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Jozef", "jozef", "0697856665", 3, 80000.0, 1, "Sivc", "jozef", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 6, "Pariske Komune 85", new DateTime(1968, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "misa@gmail.com", new DateTime(2006, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Misa", "misa", "0697856665", 3, 80000.0, 1, "Bradina", "misa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 4, "Mike Antice 5", new DateTime(1968, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "dragana@gmail.com", new DateTime(2017, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "female", "Dragana", "dragana", "0697856665", 4, 80000.0, 2, "Zoric", "dragana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 5, "Pariske Komune 35", new DateTime(1978, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "mile@gmail.com", new DateTime(2007, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Mile", "mile", "0697856665", 4, 80000.0, 2, "Grandic", "mile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "survey",
                columns: new[] { "Id", "AppointmentId", "Done" },
                values: new object[] { 1, 1, true });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "BirthDate", "BloodType", "DateOfRegistration", "DoctorId", "Email", "EmploymentStatus", "Gender", "IsActive", "IsBlocked", "Name", "ParentName", "Password", "Phone", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, "Bogoboja Atanackovica 15", new DateTime(2005, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "petar@gmail.com", "Employed", "male", true, false, "Petar", "miki", "petar", "0634556665", "Petrovic", "petar" },
                    { 2, "Voje Rodica 19", new DateTime(1985, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "miki@gmail.com", "Employed", "male", true, false, "Jovan", "miki", "miki", "0697856665", "Zoric", "miki" },
                    { 3, "Voje Rodica 19", new DateTime(1978, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "miki@gmail.com", "Employed", "male", true, false, "Zorana", "miki", "miki", "0697856665", "Bilic", "miki" },
                    { 4, "Voje Rodica 19", new DateTime(1969, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "miki@gmail.com", "Employed", "male", true, false, "Milica", "miki", "miki", "0697856665", "Maric", "miki" },
                    { 5, "Voje Rodica 19", new DateTime(1936, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "miki@gmail.com", "Employed", "male", true, false, "Igor", "miki", "miki", "0697856665", "Caric", "miki" },
                    { 6, "Voje Rodica 19", new DateTime(1975, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "miki@gmail.com", "Employed", "male", true, false, "Predrag", "miki", "miki", "0697856665", "Zaric", "miki" },
                    { 7, "Voje Rodica 19", new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "miki@gmail.com", "Employed", "male", true, false, "Miki", "miki", "miki", "0697856665", "Nikolic", "miki" },
                    { 8, "Kralja Petra 19", new DateTime(1987, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "zorka@gmail.com", "Unemployed", "female", true, false, "Zorka", "zorka", "zorka", "0697856665", "Djokic", "zorka" }
                });

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
                name: "IX_Day_DoctorId",
                table: "Day",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkDay_DoctorId",
                table: "WorkDay",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenForPatients");

            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "FeedbackMessages");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "surveyQuestion");

            migrationBuilder.DropTable(
                name: "WorkDay");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "surveyCategory");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "survey");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "appointment");
        }
    }
}
