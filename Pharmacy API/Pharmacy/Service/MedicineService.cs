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
            Medicine updateMedicine = this._medicineRepository.GetById(id);
            if (updateMedicine != null)
            {
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
            return false;
        }

        public bool LowerMedicineQuantity(int id, int quantity)
        {
            bool isChangable = this.CheckMedicineQuantity(id, quantity);
            if (isChangable)
            {
                Medicine updateMedicine = this._medicineRepository.GetById(id);
                updateMedicine.Quantity -= quantity;
                this._medicineRepository.Save();
            }
            return isChangable;
        }

        public bool RaiseMedicineQuantity(int id, int quantity)
        {
            Medicine medicine = this._medicineRepository.GetById(id);
            bool isChangable = false;
            if (medicine != null)
            {
                medicine.Quantity += quantity;
                this._medicineRepository.Save();
                isChangable = true;
            }
            return isChangable;
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
