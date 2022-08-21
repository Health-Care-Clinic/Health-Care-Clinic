using Hospital.Mapper;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Service;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Patient_portal
{
    public class SchedulingByRecommendationTests
    {
        [Fact]
        public void Get_all_doctors()
        {
            var options = CreateStubDatabase();

            using (var context = new HospitalDbContext(options))
            {
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);

                DoctorController doctorController = new DoctorController(doctorService, appointmentService);

                OkObjectResult result = doctorController.GetAllDoctors() as OkObjectResult;
                List<DoctorWithSpecialtyDTO> doctorDtos = result.Value as List<DoctorWithSpecialtyDTO>;

                clearData(context);

                Assert.Single(doctorDtos);
            }
        }

        private static void clearData(HospitalDbContext context)
        {
            foreach (Doctor doctor in context.Doctors)
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
            }

            foreach (Appointment appointment in context.Appointments)
            {
                context.Appointments.Remove(appointment);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Get_free_terms_for_doctor()
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

                DoctorAndDateRangeDataDTO dtoInput = new DoctorAndDateRangeDataDTO(1, "General medicine", "2022-2-22T00:00:00", "2022-2-22T00:00:00");

                OkObjectResult result = appointmentController.GetAvailableTermsForDoctor(dtoInput) as OkObjectResult;

                List<string> availableTerms = result.Value as List<string>;

                clearData(context);

                Assert.Equal(10, availableTerms.Count);
            }
        }

        [Fact]
        public void Get_free_terms_for_date_range()
        {
            var options = CreateStubDatabase();
            var doctorId = 1;
            var specialty = "General medicine";
            var beginningDateAsString = "2022-02-22T00:00:00";
            var endingDateAsString = "2022-02-22T00:00:00";

            using (var context = new HospitalDbContext(options))
            {
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);

                SurveyRepository surveyRepository = new SurveyRepository(context);
                SurveyService surveyService = new SurveyService(surveyRepository);

                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                AppointmentController appointmentController =
                    new AppointmentController(appointmentService, surveyService, doctorService);
                DoctorAndDateRangeDataDTO dto =
                    new DoctorAndDateRangeDataDTO(doctorId, specialty, beginningDateAsString, endingDateAsString);

                OkObjectResult result = appointmentController.GetAvailableTermsForDateRange(dto) as OkObjectResult;

                TermsInDateRangeDTO termsInDateRangeDTO = result.Value as TermsInDateRangeDTO;
                List<TermsInDateRangeForDoctorDTO> termsInDateRangeForDoctorDTOs =
                    termsInDateRangeDTO.TermsInDateRangeForDoctors;

                clearData(context);

                Assert.Single(termsInDateRangeForDoctorDTOs);
                Assert.Equal(10, termsInDateRangeForDoctorDTOs[0].Terms.Count);
            }
        }

        private DbContextOptions<HospitalDbContext> CreateStubDatabase()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
                .UseInMemoryDatabase(databaseName: "RecommendationAppointments").Options;

            using (var context = new HospitalDbContext(options))
            {
                Doctor doctor1 = new Doctor(1, "Nikola", "Nikolic", "male", new DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com", "nikola", "nikola",
                     new DateTime(2021, 06, 10), null, "General medicine", 1)
                { WorkShiftId = 1};


                context.Doctors.Add(doctor1);

                context.Appointments.Add(new Appointment(1, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 7, 0, 0), 1));
                context.Appointments.Add(new Appointment(2, 2, 1, 1, false, false, new DateTime(2022, 2, 22, 7, 30, 0), 2));

                context.SaveChanges();
            }

            return options;
        }
    }
}
