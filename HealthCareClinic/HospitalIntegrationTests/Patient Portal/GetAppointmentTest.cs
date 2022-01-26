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
using Hospital.Schedule.Repository;
using Hospital.Medical_records.Repository;
using Hospital.Schedule.Service;
using Hospital.Medical_records.Service;
using Hospital.Schedule.Model;
using Hospital.Medical_records.Model;

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

                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                AppointmentController appointmentController = new AppointmentController(appointmentService,surveyService, doctorService);

                int PatientId = 8;

                var response = appointmentController.GetAppointmentsByPatientId(PatientId) as OkObjectResult;

                foreach (Appointment appointment in context.Appointments)
                {
                    context.Appointments.Remove(appointment);
                    context.SaveChanges();
                }

                response.Value.ShouldBeAssignableTo<List<AppointmentDTOForMedicalRecord>>();

                List<AppointmentDTOForMedicalRecord> appointmentDTOs = (List<AppointmentDTOForMedicalRecord>)response.Value;

                appointmentDTOs.Count.ShouldBeEquivalentTo(2);
                appointmentDTOs.ForEach(appointmentDTO => {
                    if (appointmentDTO.isDone == false)
                        appointmentDTO.ReportDTO.ShouldBe(null);
                    else
                        appointmentDTO.ReportDTO.ShouldNotBe(null);
                    });

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

                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                AppointmentController appointmentController = new AppointmentController(appointmentService, surveyService, doctorService);

                int AppointmentId = 2;

                var response = appointmentController.CancelAppointment(AppointmentId) as OkObjectResult;

                foreach (Appointment appointment in context.Appointments)
                {
                    context.Appointments.Remove(appointment);
                    context.SaveChanges();
                }

                response.Value.ShouldBeAssignableTo<AppointmentDTOForMedicalRecord>();
                AppointmentDTOForMedicalRecord appointmentDTO = (AppointmentDTOForMedicalRecord)response.Value;
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
                Report report = new Report { Id = 1, Comment = "Pacijent se zali na tegobe sa mucninom i bolom u stomaku", Date = new DateTime(2022, 1, 22, 7, 0, 0) };
                Appointment appointment1 = new Appointment()
                {
                    Id = 1,
                    DoctorId = 1,
                    PatientId = 8,
                    Date = new System.DateTime(2022, 12, 10, 10, 0, 0),
                    SurveyId = 1,
                    RoomId = 1,
                    isCancelled = false,
                    isDone = true,
                    ReportId = 1        
                };
                Appointment appointment2 = new Appointment()
                {
                    Id = 2,
                    DoctorId = 2,
                    PatientId = 8,
                    Date = new System.DateTime(2022, 12, 11, 10, 0, 0),
                    SurveyId = 2,
                    RoomId = 2,
                    isCancelled = false,
                    isDone = false
                };
                Survey survey1 = new Survey { Id = 1, Done = true, SurveyCategories = new List<SurveyCategory>(), AppointmentId = 1 };
                Survey survey2 =  new Survey { Id = 2, Done = false, SurveyCategories = new List<SurveyCategory>(), AppointmentId = 2 };
               

                context.Reports.Add(report);
                context.Appointments.Add(appointment1);
                context.Appointments.Add(appointment2);
                context.Surveys.Add(survey1);
                context.Surveys.Add(survey2);

                context.SaveChanges();
            }
            return options;
        }
    }
}
