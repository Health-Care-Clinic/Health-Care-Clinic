using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pharmacy.Repository
{
    public class MedicineRepository : Repository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(PharmacyDbContext context) : base(context)
        {
        }

        public PharmacyDbContext PharmacyDbContext
        {
            get { return Context as PharmacyDbContext; }
        }

        public IEnumerable<Medicine> GetByNameManufacturerWeight(string name, string manufacturer, int weight)
        {
            Expression<Func<Medicine, bool>> exp = medicine => medicine.Name.ToLower().Contains(name) &&
                                                               medicine.Manufacturer.ToLower().Contains(manufacturer) &&
                                                               medicine.Weight >= weight;
            IEnumerable<Medicine> medicines = Find(exp);

            return medicines;
        }

        public bool CheckMedicineQuantity(int id, int requestedQuantity)
        {
            Expression<Func<Medicine, bool>> exp = medicine => medicine.Id == id &&
                                                               medicine.Quantity >= requestedQuantity;
            IEnumerable<Medicine> medicines = Find(exp);

            return medicines.Count<Medicine>() != 0;
        }
    }
}
