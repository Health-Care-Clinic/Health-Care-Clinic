using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Graphical_editor
{
    public class EquipmentInRoomTests
    {
        [Fact]
        public void Get_equipment_from_room()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            EquipmentRepository equipmentRepository = new EquipmentRepository(_context);
            EquipmentService equipmentService = new EquipmentService(equipmentRepository);

            Assert.Equal(3, equipmentService.GetEquipmentByRoomId(4).Count);

        }
    }
}
