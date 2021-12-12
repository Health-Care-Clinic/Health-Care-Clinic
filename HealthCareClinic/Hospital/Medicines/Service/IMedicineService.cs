using Hospital.Medicines.Model;
using Hospital.Shared_model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medicines.Service
{
    public interface IMedicineService : IService<Medicine>
    {
        void AddMedicine(string medicineName, string quantity);
    }
}
