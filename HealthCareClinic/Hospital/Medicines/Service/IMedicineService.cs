using ClinicCore.Service;
using Hospital.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medicines.Service
{
    public interface IMedicineService : IService<Medicine>
    {
        void AddMedicine(string medicineName, string quantityString);
    }
}
