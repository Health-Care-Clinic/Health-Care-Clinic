
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
            }

        }

        //[Theory]
        //[MemberData(nameof(Data))]
        //public void Get_all_general_medicine_doctors(int numberOfGeneralDoctors, bool shouldWork)
        //{
        //    DoctorService doctorService = new DoctorService(CreateStubRepository());

        //    List<Doctor> generalDoctors = doctorService.GetAllGeneralMedicineDoctors();

        //    if (shouldWork)
        //        Assert.Equal(numberOfGeneralDoctors, generalDoctors.Count);
        //    else
        //        Assert.NotEqual(numberOfGeneralDoctors, generalDoctors.Count);
        //}
        //public static IEnumerable<object[]> Data =>
        //    new List<object[]>
        //    {
        //        new object[] { 3, true },
        //        new object[] { 2, false }
        //    };

        //[Theory]
        //[InlineData(2, true)]
        //[InlineData(3, false)]
        //public void Get_all_general_medicine_doctors_who_are_not_over_ocupied(int numberOfAvailableDoctors, bool shouldWork)
        //{
        //    DoctorService doctorService = new DoctorService(CreateStubRepository());

        //    List<Doctor> availableDoctors = doctorService.GetAvailableDoctors();

        //    if (shouldWork)
        //        Assert.Equal(numberOfAvailableDoctors, availableDoctors.Count);
        //    else
        //        Assert.NotEqual(numberOfAvailableDoctors, availableDoctors.Count);
        //}


        private static IDoctorRepository CreateStubRepository()
        {
            List<Doctor> doctors = new List<Doctor>();
            var stubRepository = new Mock<IDoctorRepository>();

            Patient patient1 = new Patient(1, "Petar", "Petrovic", "male", new System.DateTime(2005, 09, 11), "Bogoboja Atanackovica 15", "0634556665", "petar@gmail.com", "", EducationCategory.HighSchool, "petar", "", null, false);
            Patient patient2 = new Patient(2, "Jovan", "Zoric", "male", new System.DateTime(1985, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
            Patient patient3 = new Patient(2, "Zorana", "Bilic", "male", new System.DateTime(1978, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
            Patient patient4 = new Patient(2, "Milica", "Maric", "male", new System.DateTime(1969, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
            Patient patient5 = new Patient(2, "Igor", "Caric", "male", new System.DateTime(1936, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
            Patient patient6 = new Patient(2, "Predrag", "Zaric", "male", new System.DateTime(1975, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
            Patient patient7 = new Patient(2, "Miki", "Nikolic", "male", new System.DateTime(1960, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);

            List<Patient> patients1 = new List<Patient>();
            patients1.Add(patient1);
            List<Patient> patients2 = new List<Patient>();
            patients2.Add(patient2);
            patients2.Add(patient3);
            List<Patient> patients3 = new List<Patient>();
            patients3.Add(patient4);
            patients3.Add(patient5);
            patients3.Add(patient6);
            patients3.Add(patient7);

            Doctor doctor1 = new Doctor(1, "Nikola", "Nikolic", new System.DateTime(1981, 05, 06), "nikolanikolic@gmail.com", "nikola", "Brace Radica 15",
                80000.0, new System.DateTime(2021, 06, 10), null, new Specialty("General medicine"), 1);
            doctor1.Patients = patients1;
            doctors.Add(doctor1);

            Doctor doctor2 = new Doctor(2, "Marko", "Radic", new System.DateTime(1986, 04, 06), "markoradic@gmail.com", "marko", "Bogoboja Atanackovica 5",
                80000.0, new System.DateTime(2020, 06, 07), null, new Specialty("General medicine"), 2);
            doctor2.Patients = patients2;
            doctors.Add(doctor2);

            Doctor doctor3 = new Doctor(3, "Jozef", "Sivc", new System.DateTime(1971, 06, 09), "jozika@gmail.com", "jozef", "Bulevar Oslobodjenja 45",
                85000.0, new System.DateTime(2011, 03, 10), null, new Specialty("General medicine"), 3);
            doctor3.Patients = patients3;
            doctors.Add(doctor3);

            Doctor doctor4 = new Doctor(4, "Dragana", "Zoric", new System.DateTime(1968, 01, 08), "dragana@gmail.com", "dragana", "Mike Antice 5",
                89000.0, new System.DateTime(2015, 09, 11), null, new Specialty("Surgery"), 4);
            doctors.Add(doctor4);
            Doctor doctor5 = new Doctor(5, "Mile", "Grandic", new System.DateTime(1978, 11, 07), "mile@gmail.com", "mile", "Pariske Komune 35",
                86000.0, new System.DateTime(2017, 08, 12), null, new Specialty("Surgery"), 4);
            doctors.Add(doctor5);


            stubRepository.Setup(m => m.GetAll()).Returns(doctors);

            return stubRepository.Object;
        }

        private DbContextOptions<HospitalDbContext> CreateStubDatabase()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Buildings")
            .Options;

            using (var context = new HospitalDbContext(options))
            {

                List<Doctor> doctors = new List<Doctor>();

                Patient patient1 = new Patient(1, "Petar", "Petrovic", "male", new System.DateTime(2005, 09, 11), "Bogoboja Atanackovica 15", "0634556665", "petar@gmail.com", "", EducationCategory.HighSchool, "petar", "", null, false);
                Patient patient2 = new Patient(2, "Jovan", "Zoric", "male", new System.DateTime(1985, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
                Patient patient3 = new Patient(2, "Zorana", "Bilic", "male", new System.DateTime(1978, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
                Patient patient4 = new Patient(2, "Milica", "Maric", "male", new System.DateTime(1969, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
                Patient patient5 = new Patient(2, "Igor", "Caric", "male", new System.DateTime(1936, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
                Patient patient6 = new Patient(2, "Predrag", "Zaric", "male", new System.DateTime(1975, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);
                Patient patient7 = new Patient(2, "Miki", "Nikolic", "male", new System.DateTime(1960, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "", EducationCategory.Graduate, "miki", "", null, false);

                List<Patient> patients1 = new List<Patient>();
                patients1.Add(patient1);
                List<Patient> patients2 = new List<Patient>();
                patients2.Add(patient2);
                patients2.Add(patient3);
                List<Patient> patients3 = new List<Patient>();
                patients3.Add(patient4);
                patients3.Add(patient5);
                patients3.Add(patient6);
                patients3.Add(patient7);

                Doctor doctor1 = new Doctor(1, "Nikola", "Nikolic", new System.DateTime(1981, 05, 06), "nikolanikolic@gmail.com", "nikola", "Brace Radica 15",
                    80000.0, new System.DateTime(2021, 06, 10), null, new Specialty("General medicine"), 1);
                doctor1.Patients = patients1;

                Doctor doctor2 = new Doctor(2, "Marko", "Radic", new System.DateTime(1986, 04, 06), "markoradic@gmail.com", "marko", "Bogoboja Atanackovica 5",
                    80000.0, new System.DateTime(2020, 06, 07), null, new Specialty("General medicine"), 2);
                doctor2.Patients = patients2;

                Doctor doctor3 = new Doctor(3, "Jozef", "Sivc", new System.DateTime(1971, 06, 09), "jozika@gmail.com", "jozef", "Bulevar Oslobodjenja 45",
                    85000.0, new System.DateTime(2011, 03, 10), null, new Specialty("General medicine"), 3);
                doctor3.Patients = patients3;

                Doctor doctor4 = new Doctor(4, "Dragana", "Zoric", new System.DateTime(1968, 01, 08), "dragana@gmail.com", "dragana", "Mike Antice 5",
                    89000.0, new System.DateTime(2015, 09, 11), null, new Specialty("Surgery"), 4);

                Doctor doctor5 = new Doctor(5, "Mile", "Grandic", new System.DateTime(1978, 11, 07), "mile@gmail.com", "mile", "Pariske Komune 35",
                    86000.0, new System.DateTime(2017, 08, 12), null, new Specialty("Surgery"), 4);


                context.Doctors.Add(doctor1);
                context.Doctors.Add(doctor2);
                context.Doctors.Add(doctor3);
                context.Doctors.Add(doctor4);
                context.Doctors.Add(doctor5);
                context.SaveChanges();
            }

            return options;
        }
    }
}
