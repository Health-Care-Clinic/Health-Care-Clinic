using Hospital.Mapper;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Options;

namespace HospitalIntegrationTests.Patient_portal
{
    public class SubmitRegistrationTests
    {
        [Fact]
        public void SubmitRegistrationForm()
        {
            var options = CreateStubDatabase();

            using (var context = new HospitalDbContext(options))
            {
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                AllergenRepository allergenRepository = new AllergenRepository(context);
                AllergenService alergenService = new AllergenService(allergenRepository);

                PatientRepository patientRepository = new PatientRepository(context);
                PatientService patientService = new PatientService(patientRepository);

                PatientRegistrationController patientController = new PatientRegistrationController(alergenService, doctorService, patientService);

                List<AllergenDTO> alergens = new List<AllergenDTO>();
                alergens.Add(new AllergenDTO(1, "Polen ambrozije"));
                alergens.Add(new AllergenDTO(2, "Ibuprofen"));
                DoctorDTO doctor = new DoctorDTO(4, "Dragana", "Zoric");

                PatientDTO patientDTO = new PatientDTO()
                {
                    Id = 100,
                    Name = "Andrija",
                    Surname = "Bosnjakovic",
                    BirthDate = "1999-10-10T00:00:00.000Z",
                    ParentName = "Lazar",
                    Address = "Filipa Filipovica 8",
                    Phone = "064298983",
                    EmploymentStatus = "Student",
                    BloodType = "A",
                    Gender = "Male",
                    Email = "nikmarko555@gmail.com",
                    Username = "nebitno",
                    Password = "andrija123",
                    DoctorDTO = doctor,
                    Allergens = alergens,
                    DateOfRegistration = "2019-10-10T00:00:00.000Z",
                    IsBlocked = false,
                    IsActive = false
                };


                OkObjectResult res = patientController.SubmitPatientRegistrationRequest(patientDTO) as OkObjectResult;

                OkObjectResult patientResult = patientController.GetPatient(patientDTO.Id) as OkObjectResult;
                PatientDTO patient = patientResult.Value as PatientDTO;
                foreach (Patient patientFor in context.Patients)
                {
                    context.Patients.Remove(patientFor);
                    context.SaveChanges();
                }

                foreach (Allergen allergen in context.Allergens)
                {
                    context.Allergens.Remove(allergen);
                    context.SaveChanges();
                }

                foreach (Doctor doc in context.Doctors)
                {
                    context.Doctors.Remove(doc);
                    context.SaveChanges();
                }

                Assert.Equal(patientDTO.Id, patient.Id);
                Assert.IsType<PatientDTO>(patient);
            }

        }

        private DbContextOptions<HospitalDbContext> CreateStubDatabase()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Patients")
            .Options;

            using (var context = new HospitalDbContext(options))
            {


                Patient patient1 = new Patient(1, "Petar", "Petrovic", "male", "A", new System.DateTime(2005, 09, 11), "Bogoboja Atanackovica 15", "0634556665", "petar@gmail.com", "petar", "petar", "miki", null, "Employed", false)
                {
                    DoctorId = 1,
                    Hashcode = "praviHashToken"
                };
                Patient patient2 = new Patient(2, "Jovan", "Zoric", "male", "A", new System.DateTime(1985, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", false)
                {
                    DoctorId = 2,
                    Hashcode = ""
                };
                Patient patient3 = new Patient(3, "Zorana", "Bilic", "male", "A", new System.DateTime(1978, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", false)
                {
                    DoctorId = 2,
                    Hashcode = ""
                };
                Doctor doctor4 = new Doctor(4, "Dragana", "Zoric", "female", new System.DateTime(1968, 01, 08), 80000.0, "Mike Antice 5", "0697856665", "dragana@gmail.com", "dragana", "dragana",
                    new System.DateTime(2015, 09, 11), null, "Surgery", 4);

                Doctor doctor5 = new Doctor(5, "Mile", "Grandic", "male", new System.DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "mile@gmail.com", "mile", "mile",
                     new System.DateTime(2017, 08, 12), null, "Surgery", 4);


                context.Doctors.Add(doctor4);
                context.Doctors.Add(doctor5);

                context.Allergens.Add(new Allergen { Id = 1, Name = "Polen ambrozije" });
                context.Allergens.Add(new Allergen { Id = 2, Name = "Ibuprofen" });

                context.Patients.Add(patient1);
                context.Patients.Add(patient2);
                context.Patients.Add(patient3);

                context.SaveChanges();
            }

            return options;
        }
    }
}
