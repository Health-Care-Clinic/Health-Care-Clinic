﻿using Moq;
using Pharmacy.Model;
using Pharmacy_API.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.Interfaces.Repository;
using Pharmacy.Interfaces.Service;
using Pharmacy.Prescriptions.Model;
using Pharmacy.Prescriptions.Service;
using Pharmacy.Tendering.Model;
using Xunit;
using RabbitMQ.Client;
using Shouldly;

namespace PharmacyTests
{
    public class PharmacyTenderTests
    {

        [Fact]
        public void Tender_Logic_Check()
        { 
            MedicineService medicineService = new MedicineService(CreateStubRepository());

            TenderService tenderService = new TenderService(medicineService, new Mock<ITenderRepository>().Object);
            Tender tender = new Tender
            {
                Medicines = GetTestEntry()
            };
            Tender tenderResponse = tenderService.GetDataForTender(tender);

            Assert.Equal(1800, tenderResponse.TotalPrice);
        }

        private static IMedicineRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicineRepository>();
            

            Medicine medicine = new Medicine { Id = 1, Name = "Brufen", Quantity = 400, Manufacturer = "Bayer", Usage = "Pain relief", Weight = 400, SideEffects = "Rash, Stomach pain", Reactions = "Headache", CompatibileMedicine = "Aspirin", Price = 4.50 };
            
            IEnumerable<Medicine> enumerable = new[] { medicine };
            stubRepository.Setup(m => m.GetByNameManufacturerWeight("Brufen", "Bayer", 400)).Returns(enumerable);
            return stubRepository.Object;
        }

        private static List<Medicine> GetTestEntry()
        {
            List<Medicine> medicines = new List<Medicine>();
            Medicine medicine1 = new Medicine { Id = 1, Name = "Brufen", Quantity = 100, Manufacturer = "Bayer", Usage = "Pain relief", Weight = 400, SideEffects = "Rash, Stomach pain", Reactions = "Headache", CompatibileMedicine = "Aspirin", Price = 4.50 };
            medicines.Add(medicine1);
            return medicines;
        }

        [Fact]
        public void Opens_connection_to_message_queue()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            IConnection connection = factory.CreateConnection();

            connection.ShouldNotBeNull();
        }

        [Fact]
        public void Opens_connection_channel()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.ShouldNotBeNull();
        }
    }
}
