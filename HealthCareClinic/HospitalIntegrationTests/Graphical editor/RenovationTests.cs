using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
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
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            TransferRepository transferRepository = new TransferRepository(_context);
            RenovationRepository renovationRepository = new RenovationRepository(_context);
            RenovationService renovationService = new RenovationService(renovationRepository,transferRepository);

            Renovation renovation = new Renovation(4, 1, 2, new DateTime(2021, 12, 06, 14, 30, 00), 1, Renovation.RenovationType.Merge);
            List<DateTime> freeTerms = renovationService.getFreeTermsForMerge(renovation);

            Assert.Equal(0, freeTerms.Count);
        }

        [Fact]
        public void Cancel_renovation()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            RenovationRepository renovationRepository = new RenovationRepository(_context);
            TransferRepository transferRepository = new TransferRepository(_context);
            RenovationService renovationService = new RenovationService(renovationRepository,transferRepository);

            renovationService.Add(new Renovation(121,8,12,new DateTime(2023, 03, 12, 9, 0, 0),3,Renovation.RenovationType.Merge));
            int numberOfRenovations = renovationService.GetRoomRenovations(8).ToList().Count;
            renovationService.RemoveById(121);
            int numberOfRenovationsAfterRemovedRenovation = renovationService.GetRoomRenovations(1221).ToList().Count;

            Assert.Equal(numberOfRenovationsAfterRemovedRenovation, numberOfRenovations - 1);
        }
    }
}
