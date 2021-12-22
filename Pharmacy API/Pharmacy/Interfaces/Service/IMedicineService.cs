using System.Collections.Generic;
using Pharmacy.Prescriptions.Model;

namespace Pharmacy.Interfaces.Service
{
    public interface IMedicineService : IService<Medicine>
    {
        public IEnumerable<Medicine> SearchMedicine(string name, string manufacturer, int weight);
        public bool CheckMedicineQuantity(int id, int requestedQuantity);
        public bool Update(int id,Medicine medicine);
        public bool LowerMedicineQuantity(int id, int quantity);
        public bool RaiseMedicineQuantity(int id, int quantity);
        public bool MedicineExistsInQuantity(string medicineName, int quantity);
        public void ReduceMedicineQuantity(string medicineName, int quantity);
        Medicine GetByName(string name);
    }
}
