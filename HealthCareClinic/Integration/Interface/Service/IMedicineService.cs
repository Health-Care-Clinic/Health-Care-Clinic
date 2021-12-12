using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Interface.Service
{
    public interface IMedicineService
    {
        void AddMedicine(string medicineName, int quantity);
    }
}
