using Pharmacy.Model;
using Pharmacy.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Service
{
    class MedicineService : IService<Medicine>
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
    }
}
