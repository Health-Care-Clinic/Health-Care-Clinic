using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Repository
{
    public interface IMedicineRepository: IRepository<Medicine>
    {
        public IEnumerable<Medicine> GetByNameManufacturerWeight(string name, string manufacturer, int weight);
        public bool CheckMedicineQuantity(int id, int requestedQuantity);
    }
}
