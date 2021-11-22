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
        public bool Update(int id,Medicine medicine);
        public bool LowerMedicineQuantity(int id, int quantity);
        public bool RaiseMedicineQuantity(int id, int quantity);
        Medicine GetByName(string name);
    }
}
