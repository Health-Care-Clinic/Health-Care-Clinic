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
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Patient_portal
{
    public class AllergenTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
                .UseInMemoryDatabase(databaseName: "Allergens").Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Allergens.Add(new Allergen { Id = 1, Name = "Polen ambrozije"});
                context.Allergens.Add(new Allergen { Id = 2, Name = "Ibuprofen"});
                context.Allergens.Add(new Allergen { Id = 3, Name = "Aspirin"});
                context.Allergens.Add(new Allergen { Id = 4, Name = "Penicilin"});
                context.Allergens.Add(new Allergen { Id = 5, Name = "Mačija dlaka"});
                context.Allergens.Add(new Allergen { Id = 6, Name = "Lateks"});
                context.Allergens.Add(new Allergen { Id = 7, Name = "Kikiriki"});
                context.Allergens.Add(new Allergen { Id = 8, Name = "Kravlje mleko"});
                context.Allergens.Add(new Allergen { Id = 9, Name = "Jaja"});
                context.Allergens.Add(new Allergen { Id = 10, Name = "Školjke"});

                context.SaveChanges();
            }

            return options;
        }

        [Fact]
        public void Get_all_allergens_from_database()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                AllergenRepository allergenRepository = new AllergenRepository(context);
                AllergenService alergenService = new AllergenService(allergenRepository);

                PatientRepository patientRepository = new PatientRepository(context);
                PatientService patientService = new PatientService(patientRepository);

                PatientRegistrationController patientRegistrationController = new PatientRegistrationController(alergenService, doctorService, patientService);

                OkObjectResult a = patientRegistrationController.GetAllAllergens() as OkObjectResult;
                List<AllergenDTO> allergens = a.Value as List<AllergenDTO>;
                foreach (Allergen b in context.Allergens)
                {
                    context.Allergens.Remove(b);
                    context.SaveChanges();
                }

                Assert.Equal(10, allergens.Count());
            }
        }
    }
}
