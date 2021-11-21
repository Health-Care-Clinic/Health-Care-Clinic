using Pharmacy.Model;
using Pharmacy.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Service
{
    public class MedicineService : IMedicineService
    {
        private IMedicineRepository _medicineRepository;


        public MedicineService(IMedicineRepository medicineRepository)
        {
            this._medicineRepository = medicineRepository;
        }

        public void Add(Medicine entity)
        {
            this._medicineRepository.Add(entity);
            this._medicineRepository.Save();
        }

        public IEnumerable<Medicine> GetAll()
        {
            return this._medicineRepository.GetAll();
        }

        public Medicine GetOneById(int id)
        {
            return this._medicineRepository.GetById(id);
        }

        public void Remove(Medicine entity)
        {
            this._medicineRepository.Remove(entity);
            this._medicineRepository.Save();
        }

        public IEnumerable<Medicine> SearchMedicine(string name, string manufacturer, int weight)
        {
            return this._medicineRepository.GetByNameManufacturerWeight(name, manufacturer, weight);
        }
        public bool CheckMedicineQuantity(int id, int requestedQuantity)
        {
            return this._medicineRepository.CheckMedicineQuantity(id, requestedQuantity);
        }

        public bool Update(int id, Medicine medicine)
        {
            try
            {
                Medicine updateMedicine = this._medicineRepository.GetById(id);
                updateMedicine.Manufacturer = medicine.Manufacturer;
                updateMedicine.Name = medicine.Name;
                updateMedicine.Quantity = medicine.Quantity;
                updateMedicine.Reactions = medicine.Reactions;
                updateMedicine.SideEffects = medicine.SideEffects;
                updateMedicine.Usage = medicine.Usage;
                updateMedicine.Weight = medicine.Weight;
                this._medicineRepository.Save();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
