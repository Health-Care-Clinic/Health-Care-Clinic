using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class ThirdMigrationPatientPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergens_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Name", "PatientId" },
                values: new object[,]
                {
                    { 1, "Polen ambrozije", null },
                    { 2, "Ibuprofen", null },
                    { 3, "Aspirin", null },
                    { 4, "Penicilin", null },
                    { 5, "Mačija dlaka", null },
                    { 6, "Lateks", null },
                    { 7, "Kikiriki", null },
                    { 8, "Kravlje mleko", null },
                    { 9, "Jaja", null },
                    { 10, "Školjke", null }
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

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_PatientId",
                table: "Allergens",
                column: "PatientId");

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
                name: "IX_WorkDay_DoctorId",
                table: "WorkDay",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "WorkDay");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Specialty");
        }
    }
}
