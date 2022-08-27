using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital.Shared_model.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Graphical_editor
{
    public class RenovationTests
    {
        [Fact]
        public void Check_unavailable_free_term_for_renovation()
        {
            HospitalDbContext _context = SetupDatabase();
            TransferRepository transferRepository = new TransferRepository(_context);
            RenovationRepository renovationRepository = new RenovationRepository(_context);
            AppointmentRepository appointmentRepository = new AppointmentRepository(_context);
            RenovationService renovationService = new RenovationService(renovationRepository, transferRepository, appointmentRepository);
            Renovation renovation = new Renovation(1, 1, 2, new DateTime(2021, 12, 06, 14, 30, 00), 1, Renovation.RenovationType.Merge);

            List<DateTime> freeTerms = renovationService.getFreeTermsForMerge(renovation);

            Assert.Empty(freeTerms);
        }

        private static HospitalDbContext SetupDatabase()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);
            return _context;
        }

        [Fact]
        public void Add_renovation()
        {
            HospitalDbContext _context = SetupDatabase();
            RenovationRepository renovationRepository = new RenovationRepository(_context);
            TransferRepository transferRepository = new TransferRepository(_context);
            AppointmentRepository appointmentRepository = new AppointmentRepository(_context);
            RenovationService renovationService = new RenovationService(renovationRepository, transferRepository, appointmentRepository);
            int numberOfRenovations = renovationService.GetRoomRenovations(5).ToList().Count;
            int id = renovationService.FindAvailableId();
            int year = renovationService.FindAvailableYear();
            _context.Database.BeginTransaction();

            renovationService.Add(new Renovation(id, 5, 10, new DateTime(year, 1, 1, 10, 0, 0), 3, Renovation.RenovationType.Merge));
            _context.ChangeTracker.Clear();

            int numberOfRenovationsAfterRemovedRenovation = renovationService.GetRoomRenovations(5).ToList().Count;
            Assert.Equal(numberOfRenovationsAfterRemovedRenovation, numberOfRenovations + 1);
        }
    }
}
