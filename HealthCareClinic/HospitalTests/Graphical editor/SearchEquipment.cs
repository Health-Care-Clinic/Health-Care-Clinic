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
using System.Text;
using Xunit;
using static Hospital.Rooms_and_equipment.Model.Equipment;

namespace HospitalUnitTests.Graphical_editor
{
    public class SearchEquipment
    {
        private static IEquipmentRepository CreateStubRepository()
        {
            Mock<IEquipmentRepository> stubRepository = new Mock<IEquipmentRepository>();
            var equipments = new List<Equipment>();
            var equipment1 = new Equipment(1, "Needle", EquipmentType.Dynamic, 25, 1);
            var equipment2 = new Equipment(2, "Bed", EquipmentType.Static, 5, 1);
            equipments.Add(equipment1);
            equipments.Add(equipment2);
            stubRepository.Setup(m => m.GetEquipmentByName("ed")).Returns(equipments);
            return stubRepository.Object;
           
                    
        }
        [Fact]
        public void Get_equipment_by_name()
        {
            EquipmentService equipmentService = new EquipmentService(CreateStubRepository());
            Assert.Equal(2, equipmentService.GetEquipmentByName("ed").Count);
        }

        [Fact]
        public void Get_equipment_by_nonexistable_name()
        {
            EquipmentService equipmentService = new EquipmentService(CreateStubRepository());
            equipmentService.GetEquipmentByName("lalala").ShouldBeNull();
        }

        
    }
}
