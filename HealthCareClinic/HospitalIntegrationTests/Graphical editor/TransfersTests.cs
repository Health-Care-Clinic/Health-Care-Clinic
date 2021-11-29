using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Graphical_editor
{
    public class TransfersTests
    {
        [Fact]
        public void Add_new_transfer()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            TransferRepository transferRepository = new TransferRepository(_context);
            TransferService transferService = new TransferService(transferRepository);
            int broj = transferService.GetAll().ToList().Count;
          
            Transfer transfer = new Transfer(20, "Bed", 5, 1, 2, new DateTime(2021, 11, 28, 9, 0, 0), 60);
            transferService.Add(transfer);
            transferService.RemoveById(transfer.Id);
            Assert.Equal(broj, transferService.GetAll().ToList().Count);

            
        }
    }
}
