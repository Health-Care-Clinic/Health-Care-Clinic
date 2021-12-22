using System.Collections.Generic;
using Pharmacy.Prescriptions.Model;

namespace Pharmacy.Interfaces.Repository
{
    public interface IMedicineRepository: IRepository<Medicine>
    {
        public IEnumerable<Medicine> GetByNameManufacturerWeight(string name, string manufacturer, int weight);
        public bool CheckMedicineQuantity(int id, int requestedQuantity);

        Medicine GetByName(string name);
    }
}
