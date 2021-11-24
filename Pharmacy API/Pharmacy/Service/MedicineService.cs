using Pharmacy.Model;
using Pharmacy.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Service
{
    public class MedicineService : IService<Medicine>
    {
        private IMedicineRepository _medicineRepository;
      


        public MedicineService(MedicineRepository medicineRepository)
        {
            this._medicineRepository = medicineRepository;
        }

        public void Add(Medicine entity)
        {
            this._medicineRepository.Add(entity);
            this._medicineRepository.Save();
        }

        public void Update(Medicine entity)
        {
            this._medicineRepository.Update(entity);
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

        public Medicine GetOneByName(string name)
        {
            foreach (Medicine medicine in GetAll())
            {
                if (medicine.Name.Equals(name))
                {
                    return medicine;
                }
            }
            return null;
        }

        public void ReduceMedicineQuantity(string medicineName, int quantity)
        {
            var medicine = GetOneByName(medicineName);
            medicine.Quantity -= quantity;
            Update(medicine);
        }

        public void Remove(Medicine entity)
        {
            this._medicineRepository.Remove(entity);
            this._medicineRepository.Save();
        }

        public bool MedicineExistInQuantity(string medicineName, int quantity)
        {
            var medicine = this.GetOneByName(medicineName);
            if (medicine == null)
            {
                return false;
            }
            return medicine.Quantity >= quantity;
        }
    }
}
