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

        public Medicine GetByName(string name)
        {
            Medicine medicine = new Medicine();
            foreach (Medicine med in _medicineRepository.GetAll())
            {
                if (med.Name.Equals(name))
                {
                    medicine = med;
                }
            }

            return medicine;
        }
    }
}
