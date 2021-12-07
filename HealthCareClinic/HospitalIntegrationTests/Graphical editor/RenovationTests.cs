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
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Graphical_editor
{
    public class RenovationTests
    {
        [Fact]
        public void Check_unavailable_free_term_for_transfer()
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
    }
}
