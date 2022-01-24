using Pharmacy.Advertisements.Model;
using Pharmacy.Interfaces.Repository;
using Pharmacy.Interfaces.Service;
using Pharmacy.Prescriptions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Advertisements.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        private IAdvertisementRepository _advertisementRepository;
        private IMedicineService _medicineService;

        public AdvertisementService(IAdvertisementRepository advertisementRepository, IMedicineService medicineService)
        {
            this._advertisementRepository = advertisementRepository;
            this._medicineService = medicineService;
        }



        public void Add(Advertisement entity)
        {
            this._advertisementRepository.Add(entity);
            this._advertisementRepository.Save();
        }

        public void AddEntitity(Advertisement entity, List<int> medicineIds)
        {
            foreach(int id in medicineIds)
            {
                Medicine medicine = this._medicineService.GetOneById(id);
                AdvertisementMedicine advertisementMedicine = new AdvertisementMedicine();
                advertisementMedicine.Advertisement = entity;
                advertisementMedicine.Medicine = medicine;
                entity.AdvertisementMedicines.Add(advertisementMedicine);
            }

            this.Add(entity);
        }


        public IEnumerable<Advertisement> GetAll()
        {
            return this._advertisementRepository.GetAll();
        }

        public Advertisement GetOneById(int id)
        {
            return this._advertisementRepository.GetById(id);
        }

        public void Remove(Advertisement entity)
        {
            this._advertisementRepository.Remove(entity);
            this._advertisementRepository.Save();
        }

        public void RemoveEntity(int id)
        {
            Advertisement advertisement = this.GetOneById(id);
            this.Remove(advertisement);
        }


    }
}
