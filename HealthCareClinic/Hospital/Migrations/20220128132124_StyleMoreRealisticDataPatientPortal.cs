using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class StyleMoreRealisticDataPatientPortal : Migration
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
                name: "CanceledAppointments",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false),
                    DateOfCancellation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanceledAppointments", x => new { x.PatientId, x.AppointmentId });
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkShiftId = table.Column<int>(type: "integer", nullable: false),
                    Specialty = table.Column<string>(type: "text", nullable: true),
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
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    ParentName = table.Column<string>(type: "text", nullable: true),
                    EmploymentStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    Usage = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    SideEffects = table.Column<string>(type: "text", nullable: true),
                    Reactions = table.Column<string>(type: "text", nullable: true),
                    CompatibileMedicine = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnCallShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnCallShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Renovations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstRoomId = table.Column<int>(type: "integer", nullable: false),
                    SecondRoomId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
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
                    X = table.Column<float>(type: "real", nullable: true),
                    Y = table.Column<float>(type: "real", nullable: true),
                    Width = table.Column<float>(type: "real", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

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
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateRange_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateRange_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
                    SourceRoomId = table.Column<int>(type: "integer", nullable: true),
                    DestinationRoomId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkDayShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDayShift", x => x.Id);
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
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalRecordId = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    DateOfRegistration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Hashcode = table.Column<string>(type: "text", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Patients_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    isCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    isDone = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false),
                    ReportId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Diagnosis = table.Column<string>(type: "text", nullable: true),
                    Medicine = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false),
                    Done = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SurveyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyCategories_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
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
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_SurveyCategories_SurveyCategoryId",
                        column: x => x.SurveyCategoryId,
                        principalTable: "SurveyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Aspirin" },
                    { 10, "Školjke" },
                    { 9, "Jaja" },
                    { 7, "Kikiriki" },
                    { 6, "Lateks" },
                    { 5, "Mačija dlaka" },
                    { 4, "Penicilin" },
                    { 8, "Kravlje mleko" },
                    { 1, "Polen ambrozije" },
                    { 2, "Ibuprofen" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "ReportId", "RoomId", "SurveyId", "isCancelled", "isDone" },
                values: new object[,]
                {
                    { 14, new DateTime(2022, 2, 22, 7, 30, 0, 0, DateTimeKind.Unspecified), 3, 10, null, 3, 14, false, false },
                    { 1, new DateTime(2022, 2, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 1, 1, false, false },
                    { 2, new DateTime(2022, 2, 22, 7, 30, 0, 0, DateTimeKind.Unspecified), 1, 2, null, 1, 2, false, false },
                    { 3, new DateTime(2022, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, null, 1, 3, false, false },
                    { 4, new DateTime(2022, 2, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 4, null, 1, 4, false, false },
                    { 5, new DateTime(2022, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, null, 1, 5, false, false },
                    { 6, new DateTime(2022, 2, 22, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 6, null, 1, 6, false, false },
                    { 7, new DateTime(2022, 2, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, null, 1, 7, false, false },
                    { 8, new DateTime(2022, 2, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 8, null, 1, 8, false, false },
                    { 9, new DateTime(2022, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 1, 9, false, false },
                    { 11, new DateTime(2022, 2, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 1, 11, false, false },
                    { 12, new DateTime(2022, 2, 22, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 1, 12, false, false },
                    { 13, new DateTime(2022, 2, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), 3, 9, null, 3, 13, false, false },
                    { 18, new DateTime(2022, 2, 22, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 14, null, 3, 18, false, false },
                    { 16, new DateTime(2022, 2, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 3, 12, null, 3, 16, false, false },
                    { 17, new DateTime(2022, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 13, null, 3, 17, false, false },
                    { 19, new DateTime(2022, 2, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 15, null, 3, 19, false, false },
                    { 20, new DateTime(2022, 2, 22, 10, 30, 0, 0, DateTimeKind.Unspecified), 3, 16, null, 3, 20, false, false },
                    { 21, new DateTime(2022, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, 17, null, 3, 21, false, false },
                    { 22, new DateTime(2022, 2, 22, 11, 30, 0, 0, DateTimeKind.Unspecified), 3, 18, null, 3, 22, false, false },
                    { 23, new DateTime(2022, 2, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 19, null, 3, 23, false, false },
                    { 24, new DateTime(2022, 2, 22, 12, 30, 0, 0, DateTimeKind.Unspecified), 3, 20, null, 3, 24, false, false },
                    { 15, new DateTime(2022, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, 11, null, 3, 15, false, false }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Height", "Name", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 3, 240f, "Building3", 0, 180f, 30f, 130f },
                    { 2, 140f, "Building2", 0, 400f, 260f, 230f },
                    { 1, 140f, "Building1", 0, 400f, 260f, 30f },
                    { 7, 70f, "Parking3", 1, 200f, 800f, 130f },
                    { 4, 140f, "Building4", 0, 300f, 700f, 230f },
                    { 5, 70f, "Parking1", 1, 200f, 30f, 30f },
                    { 6, 70f, "Parking2", 1, 200f, 800f, 30f }
                });

            migrationBuilder.InsertData(
                table: "CanceledAppointments",
                columns: new[] { "AppointmentId", "PatientId", "DateOfCancellation" },
                values: new object[,]
                {
                    { 1765, 1, new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1764, 1, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1763, 1, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1766, 1, new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1777, 1, new DateTime(2021, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1768, 6, new DateTime(2021, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1769, 6, new DateTime(2021, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1799, 2, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1780, 6, new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1870, 1, new DateTime(2021, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1767, 6, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "BirthDate", "Email", "EmploymentDate", "Gender", "Name", "Password", "Phone", "PrimaryRoom", "Salary", "Specialty", "Surname", "Username", "WorkShiftId" },
                values: new object[,]
                {
                    { 2, "Bogoboja Atanackovica 5", new DateTime(1986, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "markoradic@gmail.com", new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Marko", "marko", "0697856665", 2, 80000.0, "General medicine", "Radic", "marko", 1 },
                    { 3, "Bulevar Oslobodjenja 5", new DateTime(1986, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "jozika@gmail.com", new DateTime(2011, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Jozef", "jozef", "0697856665", 3, 80000.0, "General medicine", "Sivc", "jozef", 1 },
                    { 1, "Brace Radica 15", new DateTime(1981, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "nikolanikolic@gmail.com", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Nikola", "nikola", "0697856665", 1, 80000.0, "General medicine", "Nikolic", "nikola", 2 },
                    { 4, "Mike Antice 5", new DateTime(1968, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "dragana@gmail.com", new DateTime(2017, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "female", "Dragana", "dragana", "0697856665", 4, 80000.0, "Surgery", "Zoric", "dragana", 2 },
                    { 5, "Pariske Komune 35", new DateTime(1978, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "mile@gmail.com", new DateTime(2007, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Mile", "mile", "0697856665", 5, 80000.0, "Surgery", "Grandic", "mile", 2 },
                    { 6, "Pariske Komune 85", new DateTime(1968, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "misa@gmail.com", new DateTime(2006, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "male", "Misa", "misa", "0697856665", 6, 80000.0, "General medicine", "Bradina", "misa", 1 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Name", "Quantity", "RoomId", "Type" },
                values: new object[,]
                {
                    { 33, "TV", 3, 40, 0 },
                    { 32, "Needle", 4, 36, 1 },
                    { 31, "Bed", 7, 36, 0 },
                    { 2, "Needle", 25, 1, 1 },
                    { 21, "Bed", 1, 20, 0 },
                    { 22, "Needle", 1, 22, 1 },
                    { 23, "TV", 1, 22, 0 },
                    { 24, "Bandage", 1, 23, 1 },
                    { 30, "Blanket", 4, 30, 0 },
                    { 29, "Bandage", 4, 30, 1 },
                    { 28, "TV", 2, 29, 0 },
                    { 1, "Bed", 5, 1, 0 },
                    { 20, "Blanket", 52, 18, 0 },
                    { 3, "TV", 1, 1, 0 },
                    { 6, "Bed", 2, 2, 0 },
                    { 5, "Blanket", 5, 1, 0 },
                    { 14, "Bandage", 6, 11, 1 },
                    { 7, "Needle", 3, 2, 1 },
                    { 8, "TV", 3, 4, 0 },
                    { 9, "Bandage", 5, 4, 1 },
                    { 10, "Blanket", 2, 4, 0 },
                    { 19, "Bandage", 120, 17, 1 },
                    { 18, "TV", 1, 17, 0 },
                    { 17, "Needle", 23, 17, 1 },
                    { 16, "Bed", 26, 15, 0 },
                    { 15, "Blanket", 5, 11, 0 },
                    { 11, "Bed", 25, 8, 0 },
                    { 12, "Needle", 3, 9, 1 },
                    { 4, "Bandage", 10, 1, 1 },
                    { 13, "TV", 4, 9, 0 },
                    { 25, "Blanket", 1, 23, 0 },
                    { 35, "Blanket", 9, 40, 0 },
                    { 54, "Bandage", 17, 69, 1 },
                    { 53, "TV", 2, 68, 0 },
                    { 52, "Needle", 17, 66, 1 },
                    { 51, "Bed", 17, 65, 0 },
                    { 50, "Blanket", 13, 65, 0 },
                    { 49, "Bandage", 13, 62, 1 },
                    { 34, "Bandage", 1, 40, 1 },
                    { 48, "TV", 2, 62, 0 },
                    { 47, "Needle", 13, 60, 1 },
                    { 46, "Bed", 13, 60, 0 },
                    { 27, "Needle", 2, 26, 1 },
                    { 44, "Bandage", 11, 55, 1 },
                    { 36, "Bed", 9, 43, 0 },
                    { 37, "Needle", 9, 43, 1 },
                    { 38, "TV", 3, 45, 0 },
                    { 39, "Bandage", 9, 47, 1 },
                    { 55, "Blanket", 17, 69, 0 },
                    { 40, "Blanket", 9, 47, 0 },
                    { 45, "Blanket", 15, 55, 0 },
                    { 26, "Bed", 3, 26, 0 },
                    { 41, "Bed", 7, 50, 0 },
                    { 42, "Needle", 4, 51, 1 },
                    { 43, "TV", 1, 52, 0 }
                });

            migrationBuilder.InsertData(
                table: "FeedbackMessages",
                columns: new[] { "Id", "CanBePublished", "Date", "Identity", "IsAnonymous", "IsPublished", "Text" },
                values: new object[,]
                {
                    { 4, true, new DateTime(2021, 5, 20, 9, 10, 21, 0, DateTimeKind.Unspecified), "UrosDevic0", false, false, "Odlični lekari." },
                    { 7, true, new DateTime(2021, 10, 18, 15, 27, 36, 0, DateTimeKind.Unspecified), "JovanaGugl", false, true, "Ljubazno osoblje, imam prijatno iskustvo boravka ovde." },
                    { 8, true, new DateTime(2021, 11, 26, 19, 42, 24, 0, DateTimeKind.Unspecified), "RatkoVarda8", false, true, "Drago mi je da u mojoj blizini postoji ovako kvalitetna zdravstvena ustanova." },
                    { 3, false, new DateTime(2021, 2, 16, 11, 8, 47, 0, DateTimeKind.Unspecified), "MarijaPopovic", false, false, "Informacionom sistemu potrebne su određene popravke." },
                    { 2, true, new DateTime(2021, 6, 21, 14, 21, 56, 0, DateTimeKind.Unspecified), "NikolaTodorovic94", true, false, "Čekanje je moglo biti kraće." },
                    { 1, true, new DateTime(2021, 4, 29, 18, 34, 21, 0, DateTimeKind.Unspecified), "acaNikolic", false, false, "Zadovoljan sam uslugom." },
                    { 5, true, new DateTime(2021, 9, 30, 7, 50, 19, 0, DateTimeKind.Unspecified), "MladenAlicic1", false, true, "Savremena bolnica koju bih preporučio ljudima." },
                    { 6, true, new DateTime(2021, 10, 3, 11, 45, 3, 0, DateTimeKind.Unspecified), "IvanJovanovic", false, true, "Bolnica koja se revnosno stara o vašem zdravlju." }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "BuildingId", "Height", "Name", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, 1, 0f, "Floor 1", 0f, 0f, 0f },
                    { 3, 1, 0f, "Floor 3", 0f, 0f, 0f },
                    { 4, 2, 0f, "Floor 1", 0f, 0f, 0f },
                    { 5, 2, 0f, "Floor 2", 0f, 0f, 0f },
                    { 6, 3, 0f, "Floor 1", 0f, 0f, 0f },
                    { 7, 3, 0f, "Floor 2", 0f, 0f, 0f },
                    { 8, 3, 0f, "Floor 3", 0f, 0f, 0f },
                    { 10, 4, 0f, "Floor 2", 0f, 0f, 0f },
                    { 9, 4, 0f, "Floor 1", 0f, 0f, 0f },
                    { 2, 1, 0f, "Floor 2", 0f, 0f, 0f }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "BloodType", "BirthDate", "EmploymentStatus", "Gender", "Name", "ParentName", "Surname" },
                values: new object[,]
                {
                    { 1, "A", new DateTime(2005, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employed", "male", "Petar", "Marko", "Maljković" },
                    { 3, "A-", new DateTime(1978, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employed", "female", "Zorana", "Radovan", "Bilić" },
                    { 4, "0", new DateTime(1969, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employed", "female", "Milica", "Ana", "Marić" },
                    { 2, "A+", new DateTime(1985, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employed", "male", "Jovan", "Ilija", "Zorić" },
                    { 7, "AB-", new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employed", "male", "Matija", "Stojan", "Nikolić" },
                    { 8, "B+", new DateTime(1987, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unemployed", "female", "Zorka", "Vesna", "Đokić" },
                    { 6, "0+", new DateTime(1975, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employed", "male", "Predrag", "Natalija", "Urošević" },
                    { 5, "0-", new DateTime(1936, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Employed", "male", "Igor", "Nikola", "Carić" }
                });

            migrationBuilder.InsertData(
                table: "OnCallShifts",
                columns: new[] { "Id", "Date", "DoctorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2021, 11, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2022, 8, 22, 9, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2021, 11, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2021, 11, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2021, 11, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Renovations",
                columns: new[] { "Id", "Date", "Duration", "FirstRoomId", "SecondRoomId", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 1 },
                    { 2, new DateTime(2022, 2, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 0, 0 },
                    { 3, new DateTime(2022, 2, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, 47, 62, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Comment", "Date" },
                values: new object[,]
                {
                    { 1, "Pacijent se žali na tegobe sa mučninom i bolom u stomaku.", new DateTime(2022, 1, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Pacijent se žali na tegobe sa glavoboljom.", new DateTime(2022, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Pacijent se žali na zubobolju.", new DateTime(2021, 2, 22, 11, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "FloorId", "Name", "Type", "Height", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 1, "Room description...", 1, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 33, "Room description...", 5, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 40, "Room description...", 6, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 39, "Room description...", 6, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 38, "Room description...", 6, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 37, "Room description...", 6, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 36, "Room description...", 6, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 35, "Room description...", 5, "WC", 2, 90f, 150f, 50f, 170f },
                    { 34, "Room description...", 5, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 7, "Room description...", 1, "WC", 2, 90f, 150f, 50f, 170f },
                    { 32, "Room description...", 5, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 31, "Room description...", 5, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 30, "Room description...", 5, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 29, "Room description...", 5, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 28, "Room description...", 4, "WC", 2, 90f, 150f, 50f, 170f },
                    { 27, "Room description...", 4, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 26, "Room description...", 4, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 25, "Room description...", 4, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 24, "Room description...", 4, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 11, "Room description...", 2, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 10, "Room description...", 2, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 9, "Room description...", 2, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 8, "Room description...", 2, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 14, "Room description...", 2, "WC", 2, 90f, 150f, 50f, 170f },
                    { 15, "Room description...", 3, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 41, "Room description...", 6, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 16, "Room description...", 3, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 18, "Room description...", 3, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 19, "Room description...", 3, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 20, "Room description...", 3, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 21, "Room description...", 3, "WC", 2, 90f, 150f, 50f, 170f },
                    { 22, "Room description...", 4, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 23, "Room description...", 4, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 17, "Room description...", 3, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 12, "Room description...", 2, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 42, "Room description...", 6, "WC", 2, 90f, 150f, 50f, 170f },
                    { 44, "Room description...", 7, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 2, "Room description...", 1, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 3, "Room description...", 1, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 4, "Room description...", 1, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 5, "Room description...", 1, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 6, "Room description...", 1, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 70, "Room description...", 10, "WC", 2, 90f, 150f, 50f, 170f },
                    { 69, "Room description...", 10, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 68, "Room description...", 10, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 67, "Room description...", 10, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 66, "Room description...", 10, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 65, "Room description...", 10, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 64, "Room description...", 10, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 63, "Room description...", 9, "WC", 2, 90f, 150f, 50f, 170f },
                    { 62, "Room description...", 9, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 61, "Room description...", 9, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 60, "Room description...", 9, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 59, "Room description...", 9, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 45, "Room description...", 7, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 46, "Room description...", 7, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 47, "Room description...", 7, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 48, "Room description...", 7, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 49, "Room description...", 7, "WC", 2, 90f, 150f, 50f, 170f },
                    { 50, "Room description...", 8, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 43, "Room description...", 7, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 51, "Room description...", 8, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 53, "Room description...", 8, "Room for appointments", 0, 140f, 300f, 700f, 260f },
                    { 54, "Room description...", 8, "Room for appointments", 0, 140f, 270f, 50f, 30f },
                    { 55, "Room description...", 8, "Room for appointments", 0, 140f, 280f, 720f, 30f },
                    { 56, "Room description...", 8, "WC", 2, 90f, 150f, 50f, 170f },
                    { 57, "Room description...", 9, "Operation room", 1, 140f, 400f, 320f, 30f },
                    { 58, "Room description...", 9, "Room for appointments", 0, 140f, 380f, 320f, 260f },
                    { 52, "Room description...", 8, "Room for appointments", 0, 140f, 270f, 50f, 260f },
                    { 13, "Room description...", 2, "Room for appointments", 0, 140f, 280f, 720f, 30f }
                });

            migrationBuilder.InsertData(
                table: "Transfer",
                columns: new[] { "Id", "Date", "Duration", "Name", "Quantity", "DestinationRoomId", "SourceRoomId" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 11, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), 15, "Blanket", 10, 23, 18 },
                    { 4, new DateTime(2022, 8, 22, 9, 30, 0, 0, DateTimeKind.Unspecified), 15, "Bandage", 4, 62, 47 },
                    { 3, new DateTime(2021, 11, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), 45, "TV", 1, 52, 45 },
                    { 2, new DateTime(2021, 11, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 45, "Bed", 4, 60, 50 },
                    { 6, new DateTime(2022, 8, 22, 9, 30, 0, 0, DateTimeKind.Unspecified), 60, "Needle", 5, 51, 1 },
                    { 9, new DateTime(2021, 11, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 60, "Bed", 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "Id", "Description", "DoctorId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 8, "Description...", 2, new DateTime(2022, 1, 21, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Description...", 1, new DateTime(2022, 1, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Description...", 1, new DateTime(2020, 5, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Description...", 1, new DateTime(2020, 10, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Description...", 2, new DateTime(2020, 10, 21, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Description...", 1, new DateTime(2021, 3, 20, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Description...", 2, new DateTime(2021, 8, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Description...", 2, new DateTime(2022, 8, 26, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Description...", 1, new DateTime(2022, 5, 7, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Description...", 2, new DateTime(2020, 7, 3, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WorkDayShift",
                columns: new[] { "Id", "Name", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, "First", new DateTime(2022, 2, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Second", new DateTime(2022, 2, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 22, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "PatientId", "ReportId", "RoomId", "SurveyId", "isCancelled", "isDone" },
                values: new object[,]
                {
                    { 10, new DateTime(2022, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1, 2, 10, false, true },
                    { 25, new DateTime(2022, 1, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 1, 25, false, true },
                    { 26, new DateTime(2022, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3, 3, 26, false, true }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DoctorId", "Hashcode", "MedicalRecordId", "DateOfRegistration", "IsActive", "IsBlocked", "Password", "Username", "Address", "Email", "Phone" },
                values: new object[,]
                {
                    { 6, 3, null, 6, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "predragp006", "predrag", "Maksima Gorkog 55 stan br. 6, Novi Sad", "predrag@gmail.com", "0644530769" },
                    { 5, 3, null, 5, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "igorp005", "igor", "Radnička 7 stan br. 3, Novi Sad", "igor@gmail.com", "0631742209" },
                    { 4, 3, null, 4, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "milicap004", "milica", "Žarka Zrenjanina 2, Novi Sad", "milica@gmail.com", "0624756905" },
                    { 3, 2, null, 3, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "zoranap003", "zorana", "Sonje Marinković 44, Novi Sad", "zorana@gmail.com", "0648210031" },
                    { 2, 2, null, 2, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "jovanp002", "jovan", "Svetog Save 17, Novi Sad", "jovan@gmail.com", "0697627440" },
                    { 1, 1, null, 1, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "petarp001", "petar", "Bogoboja Atanackovića 15, Novi Sad", "petar@gmail.com", "0634556665" },
                    { 7, 3, null, 7, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "matijap007", "matija", "Starca Vujadina 22, Novi Sad", "matija@gmail.com", "0658003294" },
                    { 8, 6, null, 8, new DateTime(2020, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "zorkap008", "zorka", "Bulevar Kralja Petra I 19, Novi Sad", "zorka@gmail.com", "0627133687" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "AppointmentId", "Done" },
                values: new object[,]
                {
                    { 9, 9, false },
                    { 1, 1, false },
                    { 2, 2, false },
                    { 3, 3, false },
                    { 4, 4, false },
                    { 5, 5, false },
                    { 6, 6, false },
                    { 24, 24, false },
                    { 23, 23, false },
                    { 22, 22, false },
                    { 8, 8, false },
                    { 21, 21, false },
                    { 19, 19, false },
                    { 18, 18, false },
                    { 17, 17, false },
                    { 16, 16, false },
                    { 7, 7, false },
                    { 14, 14, false },
                    { 13, 13, false },
                    { 12, 12, false },
                    { 11, 11, false },
                    { 20, 20, false },
                    { 15, 15, false }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "AppointmentId", "Date", "Diagnosis", "Medicine", "PatientId", "Quantity" },
                values: new object[,]
                {
                    { 3, 26, new DateTime(2022, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "Uzimati 3 puta dnevno do poboljšanja.", "Kafetin", 1, 400 },
                    { 2, 25, new DateTime(2022, 1, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), "Uzimati 2 puta dnevno do poboljšanja.", "Brufen", 1, 200 },
                    { 1, 10, new DateTime(2022, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Uzimati 1 put dnevno do poboljšanja.", "Panklav", 1, 300 }
                });

            migrationBuilder.InsertData(
                table: "SurveyCategories",
                columns: new[] { "Id", "Name", "SurveyId" },
                values: new object[,]
                {
                    { 53, "Medical stuff", 18 },
                    { 52, "Doctor", 18 },
                    { 51, "Hospital", 17 },
                    { 50, "Medical stuff", 17 },
                    { 49, "Doctor", 17 },
                    { 48, "Hospital", 16 },
                    { 54, "Hospital", 18 },
                    { 47, "Medical stuff", 16 },
                    { 45, "Hospital", 15 },
                    { 44, "Medical stuff", 15 },
                    { 43, "Doctor", 15 },
                    { 42, "Hospital", 14 },
                    { 41, "Medical stuff", 14 },
                    { 40, "Doctor", 14 },
                    { 46, "Doctor", 16 },
                    { 72, "Hospital", 24 },
                    { 55, "Doctor", 19 },
                    { 57, "Hospital", 19 },
                    { 71, "Medical stuff", 24 },
                    { 70, "Doctor", 24 },
                    { 69, "Hospital", 23 },
                    { 68, "Medical stuff", 23 },
                    { 67, "Doctor", 23 },
                    { 66, "Hospital", 22 },
                    { 39, "Hospital", 13 },
                    { 65, "Medical stuff", 22 },
                    { 63, "Hospital", 21 },
                    { 62, "Medical stuff", 21 },
                    { 61, "Doctor", 21 },
                    { 60, "Hospital", 20 },
                    { 59, "Medical stuff", 20 },
                    { 58, "Doctor", 20 },
                    { 64, "Doctor", 22 },
                    { 56, "Medical stuff", 19 },
                    { 38, "Medical stuff", 13 },
                    { 36, "Hospital", 12 },
                    { 14, "Medical stuff", 5 },
                    { 13, "Doctor", 5 },
                    { 12, "Hospital", 4 },
                    { 11, "Medical stuff", 4 },
                    { 10, "Doctor", 4 },
                    { 9, "Hospital", 3 },
                    { 37, "Doctor", 13 },
                    { 8, "Medical stuff", 3 },
                    { 6, "Hospital", 2 },
                    { 5, "Medical stuff", 2 },
                    { 4, "Doctor", 2 },
                    { 3, "Hospital", 1 },
                    { 2, "Medical stuff", 1 },
                    { 1, "Doctor", 1 },
                    { 7, "Doctor", 3 },
                    { 16, "Doctor", 6 },
                    { 15, "Hospital", 5 },
                    { 18, "Hospital", 6 },
                    { 35, "Medical stuff", 12 },
                    { 34, "Doctor", 12 },
                    { 33, "Hospital", 11 },
                    { 32, "Medical stuff", 11 },
                    { 31, "Doctor", 11 },
                    { 17, "Medical stuff", 6 },
                    { 26, "Medical stuff", 9 },
                    { 27, "Hospital", 9 },
                    { 24, "Hospital", 8 },
                    { 23, "Medical stuff", 8 },
                    { 22, "Doctor", 8 },
                    { 21, "Hospital", 7 },
                    { 20, "Medical stuff", 7 },
                    { 19, "Doctor", 7 },
                    { 25, "Doctor", 9 }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "AppointmentId", "Done" },
                values: new object[,]
                {
                    { 26, 26, false },
                    { 25, 25, false },
                    { 10, 10, true }
                });

            migrationBuilder.InsertData(
                table: "SurveyCategories",
                columns: new[] { "Id", "Name", "SurveyId" },
                values: new object[,]
                {
                    { 28, "Doctor", 10 },
                    { 77, "Medical stuff", 26 },
                    { 76, "Doctor", 26 },
                    { 75, "Hospital", 25 },
                    { 78, "Hospital", 26 },
                    { 73, "Doctor", 25 },
                    { 30, "Hospital", 10 },
                    { 29, "Medical stuff", 10 },
                    { 74, "Medical stuff", 25 }
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "Content", "Grade", "SurveyCategoryId" },
                values: new object[,]
                {
                    { 243, "Has he explained you your condition enough that you can understand it?", 0, 49 },
                    { 249, "How good has stuff explained you our procedures?", 0, 50 },
                    { 248, "How prepared were stuff for emergency situations?", 0, 50 },
                    { 247, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 50 },
                    { 246, "How much our medical staff were polite?", 0, 50 },
                    { 245, "Your general grade for doctors' service", 0, 49 },
                    { 244, "How would you rate doctors' professionalism?", 0, 49 },
                    { 242, "Has doctor been polite?", 0, 49 },
                    { 237, "How would you rate hospitals' hygiene?", 0, 48 },
                    { 240, "Your general grade for whole hospital' service", 0, 48 },
                    { 239, "How easy was to use our application?", 0, 48 },
                    { 238, "How good were procedure for booking appointment?", 0, 48 },
                    { 250, "Your general grade for medical stuffs' service", 0, 50 },
                    { 236, "How would you rate our appointment organisation?", 0, 48 },
                    { 235, "Your general grade for medical stuffs' service", 0, 47 },
                    { 234, "How good has stuff explained you our procedures?", 0, 47 },
                    { 233, "How prepared were stuff for emergency situations?", 0, 47 },
                    { 241, "How careful did doctor listen you?", 0, 49 },
                    { 251, "How would you rate our appointment organisation?", 0, 51 },
                    { 256, "How careful did doctor listen you?", 0, 52 },
                    { 253, "How good were procedure for booking appointment?", 0, 51 },
                    { 271, "How careful did doctor listen you?", 0, 55 },
                    { 270, "Your general grade for whole hospital' service", 0, 54 },
                    { 269, "How easy was to use our application?", 0, 54 },
                    { 268, "How good were procedure for booking appointment?", 0, 54 },
                    { 267, "How would you rate hospitals' hygiene?", 0, 54 },
                    { 266, "How would you rate our appointment organisation?", 0, 54 },
                    { 265, "Your general grade for medical stuffs' service", 0, 53 },
                    { 264, "How good has stuff explained you our procedures?", 0, 53 },
                    { 252, "How would you rate hospitals' hygiene?", 0, 51 },
                    { 263, "How prepared were stuff for emergency situations?", 0, 53 },
                    { 261, "How much our medical staff were polite?", 0, 53 },
                    { 260, "Your general grade for doctors' service", 0, 52 },
                    { 259, "How would you rate doctors' professionalism?", 0, 52 },
                    { 258, "Has he explained you your condition enough that you can understand it?", 0, 52 },
                    { 257, "Has doctor been polite?", 0, 52 },
                    { 232, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 47 },
                    { 255, "Your general grade for whole hospital' service", 0, 51 },
                    { 254, "How easy was to use our application?", 0, 51 },
                    { 262, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 53 },
                    { 231, "How much our medical staff were polite?", 0, 47 },
                    { 227, "Has doctor been polite?", 0, 46 },
                    { 229, "How would you rate doctors' professionalism?", 0, 46 },
                    { 206, "How would you rate our appointment organisation?", 0, 42 },
                    { 205, "Your general grade for medical stuffs' service", 0, 41 },
                    { 204, "How good has stuff explained you our procedures?", 0, 41 },
                    { 203, "How prepared were stuff for emergency situations?", 0, 41 },
                    { 202, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 41 },
                    { 201, "How much our medical staff were polite?", 0, 41 },
                    { 200, "Your general grade for doctors' service", 0, 40 },
                    { 199, "How would you rate doctors' professionalism?", 0, 40 },
                    { 198, "Has he explained you your condition enough that you can understand it?", 0, 40 },
                    { 197, "Has doctor been polite?", 0, 40 },
                    { 196, "How careful did doctor listen you?", 0, 40 },
                    { 195, "Your general grade for whole hospital' service", 0, 39 },
                    { 194, "How easy was to use our application?", 0, 39 },
                    { 193, "How good were procedure for booking appointment?", 0, 39 },
                    { 192, "How would you rate hospitals' hygiene?", 0, 39 },
                    { 191, "How would you rate our appointment organisation?", 0, 39 },
                    { 190, "Your general grade for medical stuffs' service", 0, 38 },
                    { 207, "How would you rate hospitals' hygiene?", 0, 42 },
                    { 208, "How good were procedure for booking appointment?", 0, 42 },
                    { 209, "How easy was to use our application?", 0, 42 },
                    { 210, "Your general grade for whole hospital' service", 0, 42 },
                    { 228, "Has he explained you your condition enough that you can understand it?", 0, 46 },
                    { 272, "Has doctor been polite?", 0, 55 },
                    { 226, "How careful did doctor listen you?", 0, 46 },
                    { 225, "Your general grade for whole hospital' service", 0, 45 },
                    { 224, "How easy was to use our application?", 0, 45 },
                    { 223, "How good were procedure for booking appointment?", 0, 45 },
                    { 222, "How would you rate hospitals' hygiene?", 0, 45 },
                    { 221, "How would you rate our appointment organisation?", 0, 45 },
                    { 230, "Your general grade for doctors' service", 0, 46 },
                    { 220, "Your general grade for medical stuffs' service", 0, 44 },
                    { 218, "How prepared were stuff for emergency situations?", 0, 44 },
                    { 217, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 44 },
                    { 216, "How much our medical staff were polite?", 0, 44 },
                    { 215, "Your general grade for doctors' service", 0, 43 },
                    { 214, "How would you rate doctors' professionalism?", 0, 43 },
                    { 213, "Has he explained you your condition enough that you can understand it?", 0, 43 },
                    { 212, "Has doctor been polite?", 0, 43 },
                    { 211, "How careful did doctor listen you?", 0, 43 },
                    { 219, "How good has stuff explained you our procedures?", 0, 44 },
                    { 273, "Has he explained you your condition enough that you can understand it?", 0, 55 },
                    { 278, "How prepared were stuff for emergency situations?", 0, 56 },
                    { 275, "Your general grade for doctors' service", 0, 55 },
                    { 336, "How much our medical staff were polite?", 0, 68 },
                    { 335, "Your general grade for doctors' service", 0, 67 },
                    { 334, "How would you rate doctors' professionalism?", 0, 67 },
                    { 333, "Has he explained you your condition enough that you can understand it?", 0, 67 },
                    { 332, "Has doctor been polite?", 0, 67 },
                    { 331, "How careful did doctor listen you?", 0, 67 },
                    { 330, "Your general grade for whole hospital' service", 0, 66 },
                    { 329, "How easy was to use our application?", 0, 66 },
                    { 328, "How good were procedure for booking appointment?", 0, 66 },
                    { 327, "How would you rate hospitals' hygiene?", 0, 66 },
                    { 326, "How would you rate our appointment organisation?", 0, 66 },
                    { 325, "Your general grade for medical stuffs' service", 0, 65 },
                    { 324, "How good has stuff explained you our procedures?", 0, 65 },
                    { 323, "How prepared were stuff for emergency situations?", 0, 65 },
                    { 322, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 65 },
                    { 321, "How much our medical staff were polite?", 0, 65 },
                    { 320, "Your general grade for doctors' service", 0, 64 },
                    { 337, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 68 },
                    { 338, "How prepared were stuff for emergency situations?", 0, 68 },
                    { 339, "How good has stuff explained you our procedures?", 0, 68 },
                    { 340, "Your general grade for medical stuffs' service", 0, 68 },
                    { 358, "How good were procedure for booking appointment?", 0, 72 },
                    { 357, "How would you rate hospitals' hygiene?", 0, 72 },
                    { 356, "How would you rate our appointment organisation?", 0, 72 },
                    { 355, "Your general grade for medical stuffs' service", 0, 71 },
                    { 354, "How good has stuff explained you our procedures?", 0, 71 },
                    { 353, "How prepared were stuff for emergency situations?", 0, 71 },
                    { 352, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 71 },
                    { 351, "How much our medical staff were polite?", 0, 71 },
                    { 319, "How would you rate doctors' professionalism?", 0, 64 },
                    { 350, "Your general grade for doctors' service", 0, 70 },
                    { 348, "Has he explained you your condition enough that you can understand it?", 0, 70 },
                    { 347, "Has doctor been polite?", 0, 70 },
                    { 346, "How careful did doctor listen you?", 0, 70 },
                    { 345, "Your general grade for whole hospital' service", 0, 69 },
                    { 344, "How easy was to use our application?", 0, 69 },
                    { 343, "How good were procedure for booking appointment?", 0, 69 },
                    { 342, "How would you rate hospitals' hygiene?", 0, 69 },
                    { 341, "How would you rate our appointment organisation?", 0, 69 },
                    { 349, "How would you rate doctors' professionalism?", 0, 70 },
                    { 318, "Has he explained you your condition enough that you can understand it?", 0, 64 },
                    { 317, "Has doctor been polite?", 0, 64 },
                    { 316, "How careful did doctor listen you?", 0, 64 },
                    { 293, "How prepared were stuff for emergency situations?", 0, 59 },
                    { 292, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 59 },
                    { 291, "How much our medical staff were polite?", 0, 59 },
                    { 290, "Your general grade for doctors' service", 0, 58 },
                    { 289, "How would you rate doctors' professionalism?", 0, 58 },
                    { 288, "Has he explained you your condition enough that you can understand it?", 0, 58 },
                    { 287, "Has doctor been polite?", 0, 58 },
                    { 286, "How careful did doctor listen you?", 0, 58 },
                    { 294, "How good has stuff explained you our procedures?", 0, 59 },
                    { 285, "Your general grade for whole hospital' service", 0, 57 },
                    { 283, "How good were procedure for booking appointment?", 0, 57 },
                    { 282, "How would you rate hospitals' hygiene?", 0, 57 },
                    { 281, "How would you rate our appointment organisation?", 0, 57 },
                    { 280, "Your general grade for medical stuffs' service", 0, 56 },
                    { 279, "How good has stuff explained you our procedures?", 0, 56 },
                    { 189, "How good has stuff explained you our procedures?", 0, 38 },
                    { 277, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 56 },
                    { 276, "How much our medical staff were polite?", 0, 56 },
                    { 284, "How easy was to use our application?", 0, 57 },
                    { 274, "How would you rate doctors' professionalism?", 0, 55 },
                    { 295, "Your general grade for medical stuffs' service", 0, 59 },
                    { 297, "How would you rate hospitals' hygiene?", 0, 60 },
                    { 315, "Your general grade for whole hospital' service", 0, 63 },
                    { 314, "How easy was to use our application?", 0, 63 },
                    { 313, "How good were procedure for booking appointment?", 0, 63 },
                    { 312, "How would you rate hospitals' hygiene?", 0, 63 },
                    { 311, "How would you rate our appointment organisation?", 0, 63 },
                    { 310, "Your general grade for medical stuffs' service", 0, 62 },
                    { 309, "How good has stuff explained you our procedures?", 0, 62 },
                    { 308, "How prepared were stuff for emergency situations?", 0, 62 },
                    { 296, "How would you rate our appointment organisation?", 0, 60 },
                    { 307, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 62 },
                    { 305, "Your general grade for doctors' service", 0, 61 },
                    { 304, "How would you rate doctors' professionalism?", 0, 61 },
                    { 303, "Has he explained you your condition enough that you can understand it?", 0, 61 },
                    { 302, "Has doctor been polite?", 0, 61 },
                    { 301, "How careful did doctor listen you?", 0, 61 },
                    { 300, "Your general grade for whole hospital' service", 0, 60 },
                    { 299, "How easy was to use our application?", 0, 60 },
                    { 298, "How good were procedure for booking appointment?", 0, 60 },
                    { 306, "How much our medical staff were polite?", 0, 62 },
                    { 188, "How prepared were stuff for emergency situations?", 0, 38 },
                    { 183, "Has he explained you your condition enough that you can understand it?", 0, 37 },
                    { 186, "How much our medical staff were polite?", 0, 38 },
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
                    { 50, "Your general grade for doctors' service", 0, 10 },
                    { 49, "How would you rate doctors' professionalism?", 0, 10 },
                    { 48, "Has he explained you your condition enough that you can understand it?", 0, 10 },
                    { 47, "Has doctor been polite?", 0, 10 },
                    { 46, "How careful did doctor listen you?", 0, 10 },
                    { 45, "Your general grade for whole hospital' service", 0, 9 },
                    { 62, "Has doctor been polite?", 0, 13 },
                    { 63, "Has he explained you your condition enough that you can understand it?", 0, 13 },
                    { 64, "How would you rate doctors' professionalism?", 0, 13 },
                    { 65, "Your general grade for doctors' service", 0, 13 },
                    { 83, "How prepared were stuff for emergency situations?", 0, 17 },
                    { 82, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 17 },
                    { 81, "How much our medical staff were polite?", 0, 17 },
                    { 80, "Your general grade for doctors' service", 0, 16 },
                    { 79, "How would you rate doctors' professionalism?", 0, 16 },
                    { 78, "Has he explained you your condition enough that you can understand it?", 0, 16 },
                    { 77, "Has doctor been polite?", 0, 16 },
                    { 76, "How careful did doctor listen you?", 0, 16 },
                    { 44, "How easy was to use our application?", 0, 9 },
                    { 75, "Your general grade for whole hospital' service", 0, 15 },
                    { 73, "How good were procedure for booking appointment?", 0, 15 },
                    { 72, "How would you rate hospitals' hygiene?", 0, 15 },
                    { 71, "How would you rate our appointment organisation?", 0, 15 },
                    { 70, "Your general grade for medical stuffs' service", 0, 14 },
                    { 69, "How good has stuff explained you our procedures?", 0, 14 },
                    { 68, "How prepared were stuff for emergency situations?", 0, 14 },
                    { 67, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 14 },
                    { 66, "How much our medical staff were polite?", 0, 14 },
                    { 74, "How easy was to use our application?", 0, 15 },
                    { 43, "How good were procedure for booking appointment?", 0, 9 },
                    { 42, "How would you rate hospitals' hygiene?", 0, 9 },
                    { 41, "How would you rate our appointment organisation?", 0, 9 },
                    { 18, "Has he explained you your condition enough that you can understand it?", 0, 4 },
                    { 17, "Has doctor been polite?", 0, 4 },
                    { 16, "How careful did doctor listen you?", 0, 4 },
                    { 15, "Your general grade for whole hospital' service", 0, 3 },
                    { 14, "How easy was to use our application?", 0, 3 },
                    { 13, "How good were procedure for booking appointment?", 0, 3 },
                    { 12, "How would you rate hospitals' hygiene?", 0, 3 },
                    { 11, "How would you rate our appointment organisation?", 0, 3 },
                    { 19, "How would you rate doctors' professionalism?", 0, 4 },
                    { 10, "Your general grade for medical stuffs' service", 0, 2 },
                    { 8, "How prepared were stuff for emergency situations?", 0, 2 },
                    { 7, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 2 },
                    { 6, "How much our medical staff were polite?", 0, 2 },
                    { 5, "Your general grade for doctors' service", 0, 1 },
                    { 4, "How would you rate doctors' professionalism?", 0, 1 },
                    { 3, "Has he explained you your condition enough that you can understand it?", 0, 1 },
                    { 2, "Has doctor been polite?", 0, 1 },
                    { 1, "How careful did doctor listen you?", 0, 1 },
                    { 9, "How good has stuff explained you our procedures?", 0, 2 },
                    { 84, "How good has stuff explained you our procedures?", 0, 17 },
                    { 20, "Your general grade for doctors' service", 0, 4 },
                    { 22, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 5 },
                    { 40, "Your general grade for medical stuffs' service", 0, 8 },
                    { 39, "How good has stuff explained you our procedures?", 0, 8 },
                    { 38, "How prepared were stuff for emergency situations?", 0, 8 },
                    { 37, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 8 },
                    { 36, "How much our medical staff were polite?", 0, 8 },
                    { 35, "Your general grade for doctors' service", 0, 7 },
                    { 34, "How would you rate doctors' professionalism?", 0, 7 },
                    { 33, "Has he explained you your condition enough that you can understand it?", 0, 7 },
                    { 21, "How much our medical staff were polite?", 0, 5 },
                    { 32, "Has doctor been polite?", 0, 7 },
                    { 30, "Your general grade for whole hospital' service", 0, 6 },
                    { 29, "How easy was to use our application?", 0, 6 },
                    { 28, "How good were procedure for booking appointment?", 0, 6 },
                    { 27, "How would you rate hospitals' hygiene?", 0, 6 },
                    { 26, "How would you rate our appointment organisation?", 0, 6 },
                    { 25, "Your general grade for medical stuffs' service", 0, 5 },
                    { 24, "How good has stuff explained you our procedures?", 0, 5 },
                    { 23, "How prepared were stuff for emergency situations?", 0, 5 },
                    { 31, "How careful did doctor listen you?", 0, 7 },
                    { 187, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 38 },
                    { 85, "Your general grade for medical stuffs' service", 0, 17 },
                    { 87, "How would you rate hospitals' hygiene?", 0, 18 },
                    { 163, "How good were procedure for booking appointment?", 0, 33 },
                    { 162, "How would you rate hospitals' hygiene?", 0, 33 },
                    { 161, "How would you rate our appointment organisation?", 0, 33 },
                    { 160, "Your general grade for medical stuffs' service", 0, 32 },
                    { 159, "How good has stuff explained you our procedures?", 0, 32 },
                    { 158, "How prepared were stuff for emergency situations?", 0, 32 },
                    { 157, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 32 },
                    { 156, "How much our medical staff were polite?", 0, 32 },
                    { 155, "Your general grade for doctors' service", 0, 31 },
                    { 154, "How would you rate doctors' professionalism?", 0, 31 },
                    { 153, "Has he explained you your condition enough that you can understand it?", 0, 31 },
                    { 152, "Has doctor been polite?", 0, 31 },
                    { 151, "How careful did doctor listen you?", 0, 31 },
                    { 135, "Your general grade for whole hospital' service", 0, 27 },
                    { 134, "How easy was to use our application?", 0, 27 },
                    { 133, "How good were procedure for booking appointment?", 0, 27 },
                    { 132, "How would you rate hospitals' hygiene?", 0, 27 },
                    { 164, "How easy was to use our application?", 0, 33 },
                    { 165, "Your general grade for whole hospital' service", 0, 33 },
                    { 166, "How careful did doctor listen you?", 0, 34 },
                    { 167, "Has doctor been polite?", 0, 34 },
                    { 185, "Your general grade for doctors' service", 0, 37 },
                    { 184, "How would you rate doctors' professionalism?", 0, 37 },
                    { 359, "How easy was to use our application?", 0, 72 },
                    { 182, "Has doctor been polite?", 0, 37 },
                    { 181, "How careful did doctor listen you?", 0, 37 },
                    { 180, "Your general grade for whole hospital' service", 0, 36 },
                    { 179, "How easy was to use our application?", 0, 36 },
                    { 178, "How good were procedure for booking appointment?", 0, 36 },
                    { 131, "How would you rate our appointment organisation?", 0, 27 },
                    { 177, "How would you rate hospitals' hygiene?", 0, 36 },
                    { 175, "Your general grade for medical stuffs' service", 0, 35 },
                    { 174, "How good has stuff explained you our procedures?", 0, 35 },
                    { 173, "How prepared were stuff for emergency situations?", 0, 35 },
                    { 172, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 35 },
                    { 171, "How much our medical staff were polite?", 0, 35 },
                    { 170, "Your general grade for doctors' service", 0, 34 },
                    { 169, "How would you rate doctors' professionalism?", 0, 34 },
                    { 168, "Has he explained you your condition enough that you can understand it?", 0, 34 },
                    { 176, "How would you rate our appointment organisation?", 0, 36 },
                    { 130, "Your general grade for medical stuffs' service", 0, 26 },
                    { 129, "How good has stuff explained you our procedures?", 0, 26 },
                    { 128, "How prepared were stuff for emergency situations?", 0, 26 },
                    { 105, "Your general grade for whole hospital' service", 0, 21 },
                    { 104, "How easy was to use our application?", 0, 21 },
                    { 103, "How good were procedure for booking appointment?", 0, 21 },
                    { 102, "How would you rate hospitals' hygiene?", 0, 21 },
                    { 101, "How would you rate our appointment organisation?", 0, 21 },
                    { 100, "Your general grade for medical stuffs' service", 0, 20 },
                    { 99, "How good has stuff explained you our procedures?", 0, 20 },
                    { 98, "How prepared were stuff for emergency situations?", 0, 20 },
                    { 106, "How careful did doctor listen you?", 0, 22 },
                    { 97, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 20 },
                    { 95, "Your general grade for doctors' service", 0, 19 },
                    { 94, "How would you rate doctors' professionalism?", 0, 19 },
                    { 93, "Has he explained you your condition enough that you can understand it?", 0, 19 },
                    { 92, "Has doctor been polite?", 0, 19 },
                    { 91, "How careful did doctor listen you?", 0, 19 },
                    { 90, "Your general grade for whole hospital' service", 0, 18 },
                    { 89, "How easy was to use our application?", 0, 18 },
                    { 88, "How good were procedure for booking appointment?", 0, 18 },
                    { 96, "How much our medical staff were polite?", 0, 20 },
                    { 86, "How would you rate our appointment organisation?", 0, 18 },
                    { 107, "Has doctor been polite?", 0, 22 },
                    { 109, "How would you rate doctors' professionalism?", 0, 22 },
                    { 127, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 26 },
                    { 126, "How much our medical staff were polite?", 0, 26 },
                    { 125, "Your general grade for doctors' service", 0, 25 },
                    { 124, "How would you rate doctors' professionalism?", 0, 25 },
                    { 123, "Has he explained you your condition enough that you can understand it?", 0, 25 },
                    { 122, "Has doctor been polite?", 0, 25 },
                    { 121, "How careful did doctor listen you?", 0, 25 },
                    { 120, "Your general grade for whole hospital' service", 0, 24 },
                    { 108, "Has he explained you your condition enough that you can understand it?", 0, 22 },
                    { 119, "How easy was to use our application?", 0, 24 },
                    { 117, "How would you rate hospitals' hygiene?", 0, 24 },
                    { 116, "How would you rate our appointment organisation?", 0, 24 },
                    { 115, "Your general grade for medical stuffs' service", 0, 23 },
                    { 114, "How good has stuff explained you our procedures?", 0, 23 },
                    { 113, "How prepared were stuff for emergency situations?", 0, 23 },
                    { 112, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 23 },
                    { 111, "How much our medical staff were polite?", 0, 23 },
                    { 110, "Your general grade for doctors' service", 0, 22 },
                    { 118, "How good were procedure for booking appointment?", 0, 24 },
                    { 360, "Your general grade for whole hospital' service", 0, 72 }
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "Content", "Grade", "SurveyCategoryId" },
                values: new object[,]
                {
                    { 136, "How careful did doctor listen you?", 1, 28 },
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
                    { 381, "How much our medical staff were polite?", 0, 77 },
                    { 382, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 77 },
                    { 383, "How prepared were stuff for emergency situations?", 0, 77 },
                    { 384, "How good has stuff explained you our procedures?", 0, 77 },
                    { 385, "Your general grade for medical stuffs' service", 0, 77 },
                    { 386, "How would you rate our appointment organisation?", 0, 78 },
                    { 387, "How would you rate hospitals' hygiene?", 0, 78 },
                    { 388, "How good were procedure for booking appointment?", 0, 78 },
                    { 369, "How good has stuff explained you our procedures?", 0, 74 },
                    { 389, "How easy was to use our application?", 0, 78 },
                    { 368, "How prepared were stuff for emergency situations?", 0, 74 },
                    { 366, "How much our medical staff were polite?", 0, 74 },
                    { 137, "Has doctor been polite?", 3, 28 },
                    { 138, "Has he explained you your condition enough that you can understand it?", 4, 28 },
                    { 139, "How would you rate doctors' professionalism?", 5, 28 },
                    { 140, "Your general grade for doctors' service", 3, 28 },
                    { 141, "How much our medical staff were polite?", 2, 29 },
                    { 142, "How would you rate time span that you spend waiting untill doctor attended you?", 3, 29 },
                    { 143, "How prepared were stuff for emergency situations?", 4, 29 },
                    { 144, "How good has stuff explained you our procedures?", 5, 29 },
                    { 145, "Your general grade for medical stuffs' service", 3, 29 },
                    { 146, "How would you rate our appointment organisation?", 1, 30 },
                    { 147, "How would you rate hospitals' hygiene?", 4, 30 },
                    { 148, "How good were procedure for booking appointment?", 4, 30 },
                    { 149, "How easy was to use our application?", 5, 30 },
                    { 150, "Your general grade for whole hospital' service", 3, 30 },
                    { 361, "How careful did doctor listen you?", 0, 73 },
                    { 362, "Has doctor been polite?", 0, 73 },
                    { 363, "Has he explained you your condition enough that you can understand it?", 0, 73 },
                    { 364, "How would you rate doctors' professionalism?", 0, 73 },
                    { 365, "Your general grade for doctors' service", 0, 73 },
                    { 367, "How would you rate time span that you spend waiting untill doctor attended you?", 0, 74 },
                    { 390, "Your general grade for whole hospital' service", 0, 78 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ReportId",
                table: "Appointments",
                column: "ReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Day_DoctorId",
                table: "Day",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalRecordId",
                table: "Patients",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AppointmentId",
                table: "Prescriptions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyCategories_SurveyId",
                table: "SurveyCategories",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyCategoryId",
                table: "SurveyQuestions",
                column: "SurveyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AppointmentId",
                table: "Surveys",
                column: "AppointmentId");

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
                name: "CanceledAppointments");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "FeedbackMessages");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "OnCallShifts");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "ProfilePictures");

            migrationBuilder.DropTable(
                name: "Renovations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "TenderResponses_TenderItems");

            migrationBuilder.DropTable(
                name: "Tenders_TenderItems");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "WorkDay");

            migrationBuilder.DropTable(
                name: "WorkDayShift");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "SurveyCategories");

            migrationBuilder.DropTable(
                name: "TenderResponses");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
