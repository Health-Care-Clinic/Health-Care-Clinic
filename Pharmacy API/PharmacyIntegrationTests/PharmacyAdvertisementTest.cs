using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pharmacy;
using Pharmacy.Advertisements.Model;
using Pharmacy.Advertisements.Repository;
using Pharmacy.Advertisements.Service;
using Pharmacy.Prescriptions.Model;
using Pharmacy.Prescriptions.Repository;
using Pharmacy.Prescriptions.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyIntegrationTests
{
    public class PharmacyAdvertisementTest
    {

        [Fact]
        public void Add_advertsement()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PharmacyDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PharmacyDbConnectionString"));
            var _context = new PharmacyDbContext(optionsBuilder.Options);
            MedicineRepository medicineRepository = new MedicineRepository(_context);
            MedicineService medicineService = new MedicineService(medicineRepository);
            AdvertisementRepository advertisementRepository = new AdvertisementRepository(_context);
            AdvertisementService advertisementService = new AdvertisementService(advertisementRepository, medicineService);
            List<Advertisement> advertisements = (List<Advertisement>)advertisementService.GetAll();
            Advertisement advertisement1 = advertisementService.GetOneById(1);
            Medicine medicine = medicineService.GetOneById(1);
            Advertisement advertisement = new Advertisement("Najjaca reklama", "Sve jee vrh");
            AdvertisementMedicine advertisementMedicine = new AdvertisementMedicine();
            advertisementMedicine.Medicine = medicine;
            advertisementMedicine.Advertisement = advertisement;
            advertisement.AdvertisementMedicines.Add(advertisementMedicine);
            advertisementService.Add(advertisement);
            List<Advertisement> advertisementsAfter = (List<Advertisement>)advertisementService.GetAll();
            advertisementService.Remove(advertisement);

            Assert.Equal(advertisements.Count + 1, advertisementsAfter.Count);
        }

        [Fact]
        public void Remove_advertisement()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PharmacyDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PharmacyDbConnectionString"));
            var _context = new PharmacyDbContext(optionsBuilder.Options);
            MedicineRepository medicineRepository = new MedicineRepository(_context);
            MedicineService medicineService = new MedicineService(medicineRepository);
            AdvertisementRepository advertisementRepository = new AdvertisementRepository(_context);
            AdvertisementService advertisementService = new AdvertisementService(advertisementRepository, medicineService);
            List<Advertisement> advertisements = (List<Advertisement>)advertisementService.GetAll();
            Advertisement advertisement1 = advertisementService.GetOneById(1);
            advertisementService.Remove(advertisement1);
            List<Advertisement> advertisementsAfter = (List<Advertisement>)advertisementService.GetAll();
            advertisementService.Add(advertisement1);

            Assert.Equal(advertisements.Count - 1, advertisementsAfter.Count);
        }
    }
}
