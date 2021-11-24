using Hospital.Mapper;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace HospitalUnitTests.Patient_portal
{
    public class PatientAccountActivationTests
    {
        [Fact]
        public void Invalid_token_recieved()
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

                var result = patientController.ActivatePatientsAccount("lazniHashToken");

                //var result = a.Value as StatusCodeResult; NE OVO
                foreach (Patient p in context.Patients)
                {
                    context.Patients.Remove(p);
                    context.SaveChanges();
                }

                //Assert.AreEqual(HttpStatusCode.NotFound, result);
                //result.Should.BeOfType<BadRequestResult>();
                Assert.IsAssignableFrom<NotFoundResult>(result);
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public void Test_redirecting()
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

                var result = patientController.ActivatePatientsAccount("praviHashToken");

                //var result = a.Value as StatusCodeResult; NE OVO
                foreach (Patient p in context.Patients)
                {
                    context.Patients.Remove(p);
                    context.SaveChanges();
                }

                // Assert.AreEqual(HttpStatusCode.Redirect, result);
                // Assert.IsType<StatusCodeResult>(result);

                //Assert.Equal(HttpStatusCode.RedirectKeepVerb, result.StatusCode);
                //Assert.StartsWith("http://localhost/", result.RequestMessage.RequestUri.AbsoluteUri);

                //Assert.StartsWith("https://localhost:8080/",
                //    response.Headers.Location.OriginalString);

                //Assert
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
                    DoctorId = 1 ,
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

  
                context.Patients.Add(patient1);
                context.Patients.Add(patient2);
                context.Patients.Add(patient3);

                context.SaveChanges();
            }

            return options;
        }
    }
}
