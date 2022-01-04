using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Graphical_editor
{
   public class VacationTests
    {
        [Fact]
        public void Get_all_doctor_vacations()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            VacationRepository vacationRepository = new VacationRepository(_context);
            VacationService vacationService = new VacationService(vacationRepository);

            int numberOfVacations = vacationService.GetVacationsByDoctorId(1).Count;

            Assert.True(numberOfVacations > 0);
        }

        [Fact]
        public void Add_doctor_vacation()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            VacationRepository vacationRepository = new VacationRepository(_context);
            VacationService vacationService = new VacationService(vacationRepository);

            Vacation vacation = new Vacation(100, "Test description", new DateTime(2021, 09, 17, 00, 00, 00), new DateTime(2021, 10, 05, 23, 00, 00), 1);
            vacationService.Add(vacation);
            Vacation addedVacation = vacationService.GetOneById(100);
            vacationService.Remove(vacation);

            Assert.NotNull(addedVacation);
        }

        [Fact]
        public void Change_doctor_vacation()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            VacationRepository vacationRepository = new VacationRepository(_context);
            VacationService vacationService = new VacationService(vacationRepository);

            Vacation vacation1 = vacationService.GetOneById(1);
            Vacation oldVacation = new Vacation(vacation1.Id, vacation1.Description, vacation1.StartTime, vacation1.EndTime, vacation1.DoctorId);
            Vacation vacation = new Vacation(1, "Test description", new DateTime(2020, 01, 15, 00, 00, 00), new DateTime(2020, 02, 01, 23, 00, 00), 1);
            vacationService.Change(vacation);
            Vacation changedVacation = new Vacation(vacation1.Id, vacation1.Description, vacation1.StartTime, vacation1.EndTime, vacation1.DoctorId);
            vacationService.Change(oldVacation);

            Assert.Equal("Test description", changedVacation.Description);
        }

        [Fact]
        public void Delete_doctor_vacation()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            VacationRepository vacationRepository = new VacationRepository(_context);
            VacationService vacationService = new VacationService(vacationRepository);

            Vacation oldVacation = vacationService.GetOneById(1);
            vacationService.RemoveById(1);
            Vacation deletedVacation = vacationService.GetOneById(1);
            vacationService.Add(oldVacation);

            Assert.Null(deletedVacation);
        }

    }
}
