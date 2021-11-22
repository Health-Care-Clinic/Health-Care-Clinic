
using System.Collections.Generic;
using Hospital.Shared_model.Model;
using Xunit;
using Moq;

using Hospital.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Service;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Medical_records.Repository;
using Hospital.Shared_model.Repository;

namespace HospitalTests
{
    public class PatientRegistrationTests
    {
        //Integracioni test
        [Fact]
        public void Choose_available_doctor()
        {
            var options = CreateStubDatabase();

            using (var context = new HospitalDbContext(options))
            {
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService _doctorService = new DoctorService(doctorRepository);

                AllergenRepository allergenRepository = new AllergenRepository(context);
                AllergenService alergenService = new AllergenService(allergenRepository);

                PatientRegistrationController patientController = new PatientRegistrationController(alergenService, _doctorService);

                OkObjectResult a = patientController.GetAvailableDoctors() as OkObjectResult;
                List<DoctorDTO> doctors = a.Value as List<DoctorDTO>;
                foreach (Doctor d in context.Doctors)
                {
                    context.Doctors.Remove(d);
                    context.SaveChanges();
                }

                Assert.Equal(2, doctors.Count);
                Assert.IsType<List<DoctorDTO>>(doctors);
            }

        }
        //2 Unit testa
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 3, true },
                new object[] { 2, false }
            };

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, false)]
        public void Get_all_general_medicine_doctors_who_are_not_over_ocupied(int numberOfAvailableDoctors, bool shouldWork)
        {
            DoctorService doctorService = new DoctorService(CreateStubRepository());

            List<Doctor> availableDoctors = doctorService.GetAvailableDoctors();

            if (shouldWork)
                Assert.Equal(numberOfAvailableDoctors, availableDoctors.Count);
            else
                Assert.NotEqual(numberOfAvailableDoctors, availableDoctors.Count);
        }


        private static IDoctorRepository CreateStubRepository()
        {
            Mock<IDoctorRepository> stubRepository = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();

            var doctor1 = new Doctor(1, "Nikola", "Nikolic", "male", new System.DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com", "nikola", "nikola",
                     new System.DateTime(2021, 06, 10), null, new Specialty("General medicine"), 1);

            var doctor2 = new Doctor(2, "Marko", "Radic", "male", new System.DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com", "marko", "marko",
                 new System.DateTime(2020, 06, 07), null, new Specialty("General medicine"), 2);

            doctors.Add(doctor1);
            doctors.Add(doctor2);
            stubRepository.Setup(m => m.GetAvailableDoctors()).Returns(doctors);
            return stubRepository.Object;
        }

        private DbContextOptions<HospitalDbContext> CreateStubDatabase()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Doctors")
            .Options;

            using (var context = new HospitalDbContext(options))
            {

                List<Doctor> doctors = new List<Doctor>();

                Patient patient1 = new Patient(1, "Petar", "Petrovic", "male", "A", new System.DateTime(2005, 09, 11), "Bogoboja Atanackovica 15", "0634556665", "petar@gmail.com", "petar", "petar", "miki", null, "Employed", true)
                { DoctorId = 1 };
                Patient patient2 = new Patient(2, "Jovan", "Zoric", "male", "A", new System.DateTime(1985, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true)
                { DoctorId = 2 };
                Patient patient3 = new Patient(3, "Zorana", "Bilic", "male", "A", new System.DateTime(1978, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true)
                { DoctorId = 2 };
                Patient patient4 = new Patient(4, "Milica", "Maric", "male", "A", new System.DateTime(1969, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true)
                { DoctorId = 3 };
                Patient patient5 = new Patient(5, "Igor", "Caric", "male", "A", new System.DateTime(1936, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true)
                { DoctorId = 3 };
                Patient patient6 = new Patient(6, "Predrag", "Zaric", "male", "A", new System.DateTime(1975, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true)
                { DoctorId = 3 };
                Patient patient7 = new Patient(7, "Miki", "Nikolic", "male", "A", new System.DateTime(1960, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true)
                { DoctorId = 3 };
                //Patient patient8 = new Patient(8, "Zorka", "Djokic", "female", "B", new System.DateTime(1987, 07, 01), "Kralja Petra 19", "0697856665", "zorka@gmail.com", "zorka", "zorka", "zorka", null, "Unemployed", true)
                //{ DoctorId = 5 };

                Doctor doctor1 = new Doctor(1, "Nikola", "Nikolic", "male", new System.DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com", "nikola", "nikola",
                     new System.DateTime(2021, 06, 10), null, new Specialty("General medicine"), 1);

                Doctor doctor2 = new Doctor(2, "Marko", "Radic", "male", new System.DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com", "marko", "marko",
                     new System.DateTime(2020, 06, 07), null, new Specialty("General medicine"), 2);

                Doctor doctor3 = new Doctor(3, "Jozef", "Sivc", "male", new System.DateTime(1971, 06, 09), 80000.0, "Bulevar Oslobodjenja 45", "0697856665", "jozika@gmail.com", "jozef", "jozef",
                     new System.DateTime(2011, 03, 10), null, new Specialty("General medicine"), 3);

                Doctor doctor4 = new Doctor(4, "Dragana", "Zoric", "female", new System.DateTime(1968, 01, 08), 80000.0, "Mike Antice 5", "0697856665", "dragana@gmail.com", "dragana", "dragana",
                     new System.DateTime(2015, 09, 11), null, new Specialty("Surgery"), 4);

                Doctor doctor5 = new Doctor(5, "Mile", "Grandic", "male", new System.DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "mile@gmail.com", "mile", "mile",
                     new System.DateTime(2017, 08, 12), null, new Specialty("Surgery"), 4);


                context.Doctors.Add(doctor1);
                context.Doctors.Add(doctor2);
                context.Doctors.Add(doctor3);
                context.Doctors.Add(doctor4);
                context.Doctors.Add(doctor5);
                context.Patients.Add(patient1);
                context.Patients.Add(patient2);
                context.Patients.Add(patient3);
                context.Patients.Add(patient4);
                context.Patients.Add(patient5);
                context.Patients.Add(patient6);
                context.Patients.Add(patient7);
                //context.Patients.Add(patient8);
                context.SaveChanges();
            }

            return options;
        }
    }
}
