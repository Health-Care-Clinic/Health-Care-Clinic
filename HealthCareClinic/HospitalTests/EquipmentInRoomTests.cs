﻿using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using static Hospital.Rooms_and_equipment.Model.Equipment;

namespace HospitalTests
{
    
    public class EquipmentInRoomTests
    {    

        private static IEquipmentRepository CreateStubRepository()
        {
            Mock<IEquipmentRepository> stubRepository = new Mock<IEquipmentRepository>();
            var equipments = new List<Equipment>();
            var equipment1 = new Equipment(1, "Needle", EquipmentType.Dynamic, 25, 1);
            var equipment2 = new Equipment(2, "Bed", EquipmentType.Static, 5, 1);
            equipments.Add(equipment1);
            equipments.Add(equipment2);
            stubRepository.Setup(m => m.GetEquipmentByRoomId(1)).Returns(equipments);
            return stubRepository.Object;
        }
        [Fact]
        public void Get_equipment_in_room()
        {
            EquipmentService equipmentService = new EquipmentService(CreateStubRepository());
            Assert.Equal(2, equipmentService.GetEquipmentByRoomId(1).Count);
        }

        [Fact]
        public void Get_equipment_in_nonexistable_room()
        {
            EquipmentService equipmentService = new EquipmentService(CreateStubRepository());
            equipmentService.GetEquipmentByRoomId(3).ShouldBeNull();
        }



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
