using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Service
{
    public interface IMedicineService : IService<Medicine>
    {
        public IEnumerable<Medicine> SearchMedicine(string name, string manufacturer, int weight);
        public bool CheckMedicineQuantity(int id, int requestedQuantity);
        Medicine GetByName(string name);
    }
}
