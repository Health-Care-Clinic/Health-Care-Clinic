using Hospital.Mapper;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Service;
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

                DoctorController doctorController = new DoctorController(doctorService);

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

                Assert.Equal(7, doctorDtos.Count);
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

                AppointmentController appointmentController = new AppointmentController(appointmentService, doctorService);

                OkObjectResult result = appointmentController.GetAvailableTermsForDoctor(1, "2022-2-22T00:00:00", "2022-2-22T00:00:00") as OkObjectResult;
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
                Assert.Equal(PatientAdapter.ConvertToString(new System.DateTime(2022, 2, 22, 11, 30, 0)), availableTerms[0]);
            }
        }

        [Fact]
        public void Get_free_terms_for_date_range()
        {
            var options = CreateStubDatabase();

            using (var context = new HospitalDbContext(options))
            {
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);

                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                AppointmentController appointmentController = new AppointmentController(appointmentService, doctorService);

                OkObjectResult result = appointmentController.GetAvailableTermsForDateRange(1, "2022-02-22T00:00:00", "2022-02-24T00:00:00") as OkObjectResult;
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

                Assert.IsType<List<string>>(availableTerms);
                Assert.Equal(25, availableTerms.Count);
                Assert.Equal(PatientAdapter.ConvertToString(new DateTime(2022, 2, 24, 12, 30, 0)), 
                    availableTerms[availableTerms.Count - 1]);
            }
        }

        private DbContextOptions<HospitalDbContext> CreateStubDatabase()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
             .UseInMemoryDatabase(databaseName: "RecommendationAppointments")
             .Options;

            using (var context = new HospitalDbContext(options))
            {
                Doctor doctor1 = new Doctor(1, "Nikola", "Nikolic", "male", new System.DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com", "nikola", "nikola",
                     new System.DateTime(2021, 06, 10), null, "General medicine", 1);

                Doctor doctor2 = new Doctor(2, "Marko", "Radic", "male", new System.DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com", "marko", "marko",
                     new System.DateTime(2020, 06, 07), null, "General medicine", 2);

                Doctor doctor3 = new Doctor(3, "Jozef", "Sivc", "male", new System.DateTime(1971, 06, 09), 80000.0, "Bulevar Oslobodjenja 45", "0697856665", "jozika@gmail.com", "jozef", "jozef",
                     new System.DateTime(2011, 03, 10), null, "General medicine", 3);

                Doctor doctor4 = new Doctor(4, "Dragana", "Zoric", "female", new System.DateTime(1968, 01, 08), 80000.0, "Mike Antice 5", "0697856665", "dragana@gmail.com", "dragana", "dragana",
                     new System.DateTime(2015, 09, 11), null, "Surgery", 4);

                Doctor doctor5 = new Doctor(5, "Mile", "Grandic", "male", new System.DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "mile@gmail.com", "mile", "mile",
                     new System.DateTime(2017, 08, 12), null, "Surgery", 5);

                Doctor doctor6 = new Doctor(6, "Antonije", "Trkulja", "male", new System.DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "antonije@gmail.com", "antonije", "mile",
                     new System.DateTime(2017, 08, 12), null, "Opftamology", 6);

                Doctor doctor7 = new Doctor(7, "Sava", "Peric", "male", new System.DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "sava@gmail.com", "sava", "mile",
                     new System.DateTime(2017, 08, 12), null, "Dermmatology", 7);


                context.Doctors.Add(doctor1);
                context.Doctors.Add(doctor2);
                context.Doctors.Add(doctor3);
                context.Doctors.Add(doctor4);
                context.Doctors.Add(doctor5);
                context.Doctors.Add(doctor6);
                context.Doctors.Add(doctor7);
                context.Appointments.Add(new Appointment(1, 1, 1, 1, false, false, new System.DateTime(2022, 2, 22, 7, 0, 0), 1));
                context.Appointments.Add(new Appointment(2, 2, 1, 1, false, false, new System.DateTime(2022, 2, 22, 7, 30, 0), 2));
                context.Appointments.Add(new Appointment(3, 3, 1, 1, false, false, new System.DateTime(2022, 2, 22, 8, 0, 0), 3));
                context.Appointments.Add(new Appointment(4, 4, 1, 1, false, false, new System.DateTime(2022, 2, 22, 8, 30, 0), 4));
                context.Appointments.Add(new Appointment(5, 5, 1, 1, false, false, new System.DateTime(2022, 2, 22, 9, 0, 0), 5));
                context.Appointments.Add(new Appointment(6, 6, 1, 1, false, false, new System.DateTime(2022, 2, 22, 9, 30, 0), 6));
                context.Appointments.Add(new Appointment(7, 7, 1, 1, false, false, new System.DateTime(2022, 2, 22, 10, 0, 0), 7));
                context.Appointments.Add(new Appointment(8, 8, 1, 1, false, false, new System.DateTime(2022, 2, 22, 10, 30, 0), 8));
                context.Appointments.Add(new Appointment(9, 1, 1, 1, false, false, new System.DateTime(2022, 2, 22, 11, 0, 0), 9));
                context.Appointments.Add(new Appointment(10, 1, 2, 1, false, false, new System.DateTime(2022, 2, 22, 11, 30, 0), 10));
                context.Appointments.Add(new Appointment(11, 1, 1, 1, false, false, new System.DateTime(2022, 2, 22, 12, 0, 0), 11));
                context.Appointments.Add(new Appointment(12, 1, 1, 1, false, false, new System.DateTime(2022, 2, 22, 12, 30, 0), 12));


                context.SaveChanges();
            }

            return options;
        }
    }
}
