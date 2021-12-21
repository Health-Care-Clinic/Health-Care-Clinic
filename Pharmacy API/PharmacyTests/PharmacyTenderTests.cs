using Moq;
using Pharmacy.Model;
using Pharmacy.Repository;
using Pharmacy.Service;
using Pharmacy_API.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PharmacyTests
{
    public class PharmacyTenderTests
    {

        [Fact]
        public void Tender_Logic_Check()
        { 
            MedicineService medicineService = new MedicineService(CreateStubRepository());

            TenderService tenderService = new TenderService(medicineService);
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
    }
}
