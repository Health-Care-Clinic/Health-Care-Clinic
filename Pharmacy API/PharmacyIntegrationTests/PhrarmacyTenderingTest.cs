using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pharmacy;
using System;
using System.IO;
using Moq;
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
using Pharmacy.Tendering.Service;

namespace PharmacyIntegrationTests
{
    public class PhrarmacyTenderingTest
    {
      
        public void Valid_tender_response()
        {
            TenderResponseService tenderResponseService = GetTenderResponseService();

            ICollection<TenderItem> tenderItems = new List<TenderItem>();
            tenderItems.Add(new TenderItem("Brufen", 20));
            Tender tender = new Tender(new DateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1)), tenderItems);
            tender.Id = 1;
            TenderResponse tenderResponse = tenderResponseService.CreateResponseFromTender(tender);
            
            Assert.Equal("Cena odgovora na tender sa ID-jem 1 je 90.", tenderResponse.Description);
        }

        [Fact]
        public void Tender_not_up_to_date_response()
        {
            TenderResponseService tenderResponseService = GetTenderResponseService();

            ICollection<TenderItem> tenderItems = new List<TenderItem>();
            tenderItems.Add(new TenderItem("Brufen", 20));
            Tender tender = new Tender(new DateRange(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1)), tenderItems);
            tender.Id = 1;
            TenderResponse tenderResponse = tenderResponseService.CreateResponseFromTender(tender);

            Assert.Equal("Tender sa ID-jem 1 nije aktuelan.", tenderResponse.Description);
        }

        [Fact]
        public void No_adequate_tender_response()
        {
            TenderResponseService tenderResponseService = GetTenderResponseService();

            ICollection<TenderItem> tenderItems = new List<TenderItem>();
            tenderItems.Add(new TenderItem("Bromazepam", 20));
            Tender tender = new Tender(new DateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1)), tenderItems);
            tender.Id = 1;
            TenderResponse tenderResponse = tenderResponseService.CreateResponseFromTender(tender);

            Assert.Equal("Za tender sa ID-jem 1 ne postoji odgovarajuca ponuda.", tenderResponse.Description);
        }

        private TenderResponseService GetTenderResponseService()
        {
            return new TenderResponseService(new Mock<ITenderResponseRepository>().Object, new MedicineService(CreateStubRepository()));
        }


        private IMedicineRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicineRepository>();


            Medicine medicine = new Medicine { Id = 1, Name = "Brufen", Quantity = 400, Manufacturer = "Bayer", Usage = "Pain relief", Weight = 400, SideEffects = "Rash, Stomach pain", Reactions = "Headache", CompatibileMedicine = "Aspirin", Price = 4.50 };

            IEnumerable<Medicine> enumerable = new[] { medicine };
            stubRepository.Setup(m => m.GetByNameManufacturerWeight("Brufen", "Bayer", 400)).Returns(enumerable);
            stubRepository.Setup(m => m.GetAll()).Returns(enumerable);
            return stubRepository.Object;

        }
    }
}
