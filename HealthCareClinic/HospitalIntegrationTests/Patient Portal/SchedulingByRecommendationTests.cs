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

                Assert.Equal(6, doctorDtos.Count);
                Assert.IsType<List<DoctorWithSpecialtyDTO>>(doctorDtos);
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

                Assert.Single(availableTerms);
                Assert.IsType<List<string>>(availableTerms);
                Assert.Equal(PatientAdapter.ConvertToString(new DateTime(2022, 2, 22, 11, 30, 0)), availableTerms[0]);
            }
        }

        [Theory]
        [MemberData(nameof(DoctorIdAndDateRangeData))]
        public void Get_free_terms_for_date_range(int doctorId, string specialty, string beginningDateAsString, string endingDateAsString)
        {
            var options = CreateStubDatabase();

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

                Assert.IsType<TermsInDateRangeDTO>(termsInDateRangeDTO);
                Assert.IsType<List<TermsInDateRangeForDoctorDTO>>(termsInDateRangeForDoctorDTOs);
                switch (doctorId)
                {
                    case 1:
                        Assert.Single(termsInDateRangeForDoctorDTOs);
                        Assert.Equal(25, termsInDateRangeForDoctorDTOs[0].Terms.Count);
                        Assert.Equal(new DateTime(2022, 2, 22, 11, 30, 0).ToString(), 
                            termsInDateRangeForDoctorDTOs[0].Terms[0]);
                        break;
                    case 2:
                        Assert.Single(termsInDateRangeForDoctorDTOs);
                        Assert.Equal(35, termsInDateRangeForDoctorDTOs[0].Terms.Count);
                        Assert.DoesNotContain(new DateTime(2022, 2, 22, 11, 30, 0).ToString(), 
                            termsInDateRangeForDoctorDTOs[0].Terms);
                        break;
                    case 3:
                        Assert.Equal(3, termsInDateRangeForDoctorDTOs.Count);
                        Assert.Single(termsInDateRangeForDoctorDTOs[0].Terms);
                        Assert.Equal(new DateTime(2022, 2, 22, 11, 30, 0).ToString(),
                            termsInDateRangeForDoctorDTOs[0].Terms[0]);
                        Assert.Equal(11, termsInDateRangeForDoctorDTOs[1].Terms.Count);
                        Assert.DoesNotContain(new DateTime(2022, 2, 22, 11, 30, 0).ToString(),
                            termsInDateRangeForDoctorDTOs[1].Terms);
                        Assert.Equal(12, termsInDateRangeForDoctorDTOs[2].Terms.Count);
                        Assert.Equal(new DateTime(2022, 2, 22, 13, 0, 0).ToString(),
                            termsInDateRangeForDoctorDTOs[2].Terms[0]);
                        break;
                }
            }
        }

        public static IEnumerable<object[]> DoctorIdAndDateRangeData()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { 1, "General medicine", "2022-02-22T00:00:00", "2022-02-24T00:00:00" });
            retVal.Add(new object[] { 2, "General medicine", "2022-02-22T00:00:00", "2022-02-24T00:00:00" });
            retVal.Add(new object[] { 3, "General medicine", "2022-02-22T00:00:00", "2022-02-22T00:00:00" });

            return retVal;
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

                Doctor doctor2 = new Doctor(2, "Marko", "Radic", "male", new DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com", "marko", "marko",
                     new DateTime(2020, 06, 07), null, "General medicine", 2)
                { WorkShiftId = 1 };

                Doctor doctor3 = new Doctor(3, "Jozef", "Sivc", "male", new DateTime(1971, 06, 09), 80000.0, "Bulevar Oslobodjenja 45", "0697856665", "jozika@gmail.com", "jozef", "jozef",
                     new DateTime(2011, 03, 10), null, "General medicine", 3)
                { WorkShiftId = 1 };

                Doctor doctor4 = new Doctor(4, "Dragana", "Zoric", "female", new DateTime(1968, 01, 08), 80000.0, "Mike Antice 5", "0697856665", "dragana@gmail.com", "dragana", "dragana",
                     new DateTime(2015, 09, 11), null, "Surgery", 4)
                { WorkShiftId = 2 };

                Doctor doctor5 = new Doctor(5, "Mile", "Grandic", "male", new DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "mile@gmail.com", "mile", "mile",
                     new DateTime(2017, 08, 12), null, "Surgery", 5)
                { WorkShiftId = 2 };

                Doctor doctor6 = new Doctor(6, "Misa", "Bradina", "male", new DateTime(1968, 06, 07), 80000.0, "Pariske Komune 85", "0697856665", "misa@gmail.com", "misa", "misa",
                    new DateTime(2006, 03, 10), null, "General medicine", 6)
                { WorkShiftId = 2 };


                context.Doctors.Add(doctor1);
                context.Doctors.Add(doctor2);
                context.Doctors.Add(doctor3);
                context.Doctors.Add(doctor4);
                context.Doctors.Add(doctor5);
                context.Doctors.Add(doctor6);

                context.Appointments.Add(new Appointment(1, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 7, 0, 0), 1));
                context.Appointments.Add(new Appointment(2, 2, 1, 1, false, false, new DateTime(2022, 2, 22, 7, 30, 0), 2));
                context.Appointments.Add(new Appointment(3, 3, 1, 1, false, false, new DateTime(2022, 2, 22, 8, 0, 0), 3));
                context.Appointments.Add(new Appointment(4, 4, 1, 1, false, false, new DateTime(2022, 2, 22, 8, 30, 0), 4));
                context.Appointments.Add(new Appointment(5, 5, 1, 1, false, false, new DateTime(2022, 2, 22, 9, 0, 0), 5));
                context.Appointments.Add(new Appointment(6, 6, 1, 1, false, false, new DateTime(2022, 2, 22, 9, 30, 0), 6));
                context.Appointments.Add(new Appointment(7, 7, 1, 1, false, false, new DateTime(2022, 2, 22, 10, 0, 0), 7));
                context.Appointments.Add(new Appointment(8, 8, 1, 1, false, false, new DateTime(2022, 2, 22, 10, 30, 0), 8));
                context.Appointments.Add(new Appointment(9, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 11, 0, 0), 9));
                context.Appointments.Add(new Appointment(10, 1, 2, 1, false, false, new DateTime(2022, 2, 22, 11, 30, 0), 10));
                context.Appointments.Add(new Appointment(11, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 12, 0, 0), 11));
                context.Appointments.Add(new Appointment(12, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 12, 30, 0), 12));

                context.Appointments.Add(new Appointment(13, 9, 3, 3, false, false, new DateTime(2022, 2, 22, 7, 0, 0), 13));
                context.Appointments.Add(new Appointment(14, 10, 3, 3, false, false, new DateTime(2022, 2, 22, 7, 30, 0), 14));
                context.Appointments.Add(new Appointment(15, 11, 3, 3, false, false, new DateTime(2022, 2, 22, 8, 0, 0), 15));
                context.Appointments.Add(new Appointment(16, 12, 3, 3, false, false, new DateTime(2022, 2, 22, 8, 30, 0), 16));
                context.Appointments.Add(new Appointment(17, 13, 3, 3, false, false, new DateTime(2022, 2, 22, 9, 0, 0), 17));
                context.Appointments.Add(new Appointment(18, 14, 3, 3, false, false, new DateTime(2022, 2, 22, 9, 30, 0), 18));
                context.Appointments.Add(new Appointment(19, 15, 3, 3, false, false, new DateTime(2022, 2, 22, 10, 0, 0), 19));
                context.Appointments.Add(new Appointment(20, 16, 3, 3, false, false, new DateTime(2022, 2, 22, 10, 30, 0), 20));
                context.Appointments.Add(new Appointment(21, 17, 3, 3, false, false, new DateTime(2022, 2, 22, 11, 0, 0), 21));
                context.Appointments.Add(new Appointment(22, 18, 3, 3, false, false, new DateTime(2022, 2, 22, 11, 30, 0), 22));
                context.Appointments.Add(new Appointment(23, 19, 3, 3, false, false, new DateTime(2022, 2, 22, 12, 0, 0), 23));
                context.Appointments.Add(new Appointment(24, 20, 3, 3, false, false, new DateTime(2022, 2, 22, 12, 30, 0), 24));

                context.SaveChanges();
            }

            return options;
        }
    }
}
