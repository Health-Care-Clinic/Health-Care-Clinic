using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class ThirdMigrationPatientPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1767, 16 });

            migrationBuilder.DeleteData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1768, 16 });

            migrationBuilder.DeleteData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1769, 16 });

            migrationBuilder.DeleteData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1780, 16 });

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1763, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1764, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1765, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1766, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1777, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1870, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1799, 2 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "CanceledAppointments",
                columns: new[] { "AppointmentId", "PatientId", "DateOfCancellation" },
                values: new object[,]
                {
                    { 1767, 6, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1768, 6, new DateTime(2021, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1769, 6, new DateTime(2021, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1780, 6, new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1767, 6 });

            migrationBuilder.DeleteData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1768, 6 });

            migrationBuilder.DeleteData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1769, 6 });

            migrationBuilder.DeleteData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1780, 6 });

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1763, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1764, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1765, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1766, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1777, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1870, 1 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CanceledAppointments",
                keyColumns: new[] { "AppointmentId", "PatientId" },
                keyValues: new object[] { 1799, 2 },
                column: "DateOfCancellation",
                value: new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "CanceledAppointments",
                columns: new[] { "AppointmentId", "PatientId", "DateOfCancellation" },
                values: new object[,]
                {
                    { 1767, 16, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1768, 16, new DateTime(2021, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1769, 16, new DateTime(2021, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1780, 16, new DateTime(2021, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
