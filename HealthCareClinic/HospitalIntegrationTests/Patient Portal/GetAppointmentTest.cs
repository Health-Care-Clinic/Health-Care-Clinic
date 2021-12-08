using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using Hospital_API.DTO;

namespace HospitalIntegrationTests.Patient_portal
{
    public class GetAppointmentTest
    {
        [Fact]
        public void Get_Appointments_by_patient_id()
        {
            var options = CreateStubDatabase();

            using (var context = new HospitalDbContext(options))
            {
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);

                AppointmentController appointmentController = new AppointmentController(appointmentService);

                int PatientId = 10;

                var response = appointmentController.GetAppointmentsByPatientId(PatientId) as OkObjectResult;

                foreach (Appointment appointment in context.Appointments)
                {
                    context.Appointments.Remove(appointment);
                    context.SaveChanges();
                }

                response.Value.ShouldBeAssignableTo<List<AppointmentDTO>>();

                List<AppointmentDTO> appointmentDTOs = (List<AppointmentDTO>)response.Value;

                appointmentDTOs.Count.ShouldBeEquivalentTo(2);

            }
        }
        [Fact]
        public void Cancel_appointment_success()
        {
            var options = CreateStubDatabase();

            using (var context = new HospitalDbContext(options))
            {
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);

                AppointmentController appointmentController = new AppointmentController(appointmentService);

                int AppointmentId = 2;

                var response = appointmentController.CancelAppointment(AppointmentId) as OkObjectResult;

                foreach (Appointment appointment in context.Appointments)
                {
                    context.Appointments.Remove(appointment);
                    context.SaveChanges();
                }

                response.Value.ShouldBeAssignableTo<AppointmentDTO>();
                AppointmentDTO appointmentDTO = (AppointmentDTO)response.Value;
                appointmentDTO.isCancelled.ShouldBe(true);
            }
        }

        private DbContextOptions<HospitalDbContext> CreateStubDatabase()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Appointments")
            .Options;

            using (var context = new HospitalDbContext(options))
            {

                Appointment appointment1 = new Appointment()
                {
                    Id = 1,
                    DoctorId = 1,
                    PatientId = 10,
                    Date = new System.DateTime(2021, 07, 11, 10, 0, 0),
                    SurveyId = 1,
                    RoomId = 1,
                    isCancelled = false,
                    isDone = true
                };
                Appointment appointment2 = new Appointment()
                {
                    Id = 2,
                    DoctorId = 2,
                    PatientId = 10,
                    Date = new System.DateTime(2021, 12, 11, 10, 0, 0),
                    SurveyId = 2,
                    RoomId = 2,
                    isCancelled = false,
                    isDone = false
                };

                context.Appointments.Add(appointment1);
                context.Appointments.Add(appointment2);

                context.SaveChanges();
            }
            return options;
        }
    }
}
