using Pharmacy.Model;
using Pharmacy.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Service
{
    class MedicineService : IService<Medicine>
    {
        private MedicineRepository _medicineRepository;

        public MedicineService(MedicineRepository medicineRepository)
        {
            this._medicineRepository = medicineRepository;
        }

        public void Add(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetAll()
        {
            throw new NotImplementedException();
        }

        public Medicine GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Medicine entity)
        {
            throw new NotImplementedException();
        }
    }
}
