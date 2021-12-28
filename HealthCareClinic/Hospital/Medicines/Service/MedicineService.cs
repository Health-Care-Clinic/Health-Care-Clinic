using Hospital.Medicines.Repository;
using Hospital.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medicines.Service
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
            throw new NotImplementedException();
        }

        public void AddMedicine(string medicineName, string quantityString)
        {
            int quantity = Int32.Parse(quantityString);
            foreach (var medicine in _medicineRepository.GetAll())
            {
                if (medicine.Name.Equals(medicineName))
                {
                    var newMedicine = medicine;
                    newMedicine.Quantity += quantity;

                    _medicineRepository.Remove(medicine);
                    _medicineRepository.Add(newMedicine);
                    _medicineRepository.Save();
                    return;
                }
            }
            _medicineRepository.Add(new Medicine(-1, medicineName, quantity));
            _medicineRepository.Save();
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
