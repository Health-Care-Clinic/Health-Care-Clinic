using ClinicCore.Storages;
using Model;
using System.Collections.Generic;

namespace Service
{
    public class MedicineService
    {
        private MedicineFileStorage mfs = new MedicineFileStorage();
        public List<Medicine> AllMedicines { get; set; }

        private static MedicineService instance = null;
        public static MedicineService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicineService();
                }
                return instance;
            }
        }

        private MedicineService()
        {
            AllMedicines = mfs.GetAll();
        }

        public Medicine GetByName(string medicineName)
        {
            Medicine ret = null;
            foreach(Medicine medicine in AllMedicines)
            {
                if (medicine.Name.ToLower().Contains(medicineName.ToLower()))
                {
                    ret = medicine;
                    break;
                }
            }
            return ret;
        }
        public void UpdateMedicine(Medicine medicine)
        {
            for(int i = 0; i < AllMedicines.Count; i++)
            {
                if (AllMedicines[i].Name.Equals(medicine.Name))
                {
                    AllMedicines.Remove(AllMedicines[i]);
                    AllMedicines.Insert(i, medicine);
                    mfs.Save(AllMedicines);
                }
            }
        }

        public void UpdateMedicineWithName(string oldName, Medicine medicine)
        {
            for (int i = 0; i < AllMedicines.Count; i++)
            {
                if (AllMedicines[i].Name.Equals(oldName))
                {
                    AllMedicines.Remove(AllMedicines[i]);
                    AllMedicines.Insert(i, medicine);
                    mfs.Save(AllMedicines);
                }
            }
        }

        public void DeleteMedicine(Medicine medicine)
        {
            AllMedicines.Remove(medicine);
            mfs.Save(AllMedicines);
        }

        public void AddNewMedicine(Medicine medicine)
        {
            AllMedicines.Add(medicine);
            mfs.Save(AllMedicines);
        }

        public Medicine FindMedicineByName(string name)
        {
            Medicine medicine = null;
            foreach (Medicine med in AllMedicines)
            {
                if (med.Name.ToLower().Contains(name.ToLower()))
                {
                    medicine = med;
                }
            }
            return medicine;
        }

        public bool IsNameUnique(string name)
        {
            bool isUnique = true;
           foreach (Medicine med in AllMedicines)
            {
                if (med.Name.Equals(name))
                {
                    isUnique = false;
                }
            }
            return isUnique;
        }
    }
}
