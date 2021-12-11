using Integration.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.Service
{
    public class MedicineService : IMedicineService
    {
        private readonly IntegrationDbContext _dbContext;

        public MedicineService(IntegrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMedicine(string medicineName, int quantity)
        {
            foreach (var medicine in _dbContext.Medicines.ToList())
            {
                if (medicine.Name.Equals(medicineName))
                {
                    medicine.Quantity += quantity;
                    _dbContext.Medicines.Update(medicine);
                    _dbContext.SaveChanges();
                    return;
                }
            }

            _dbContext.Medicines.Add(new Integration.Model.Medicine(medicineName, quantity));
            _dbContext.SaveChanges();
        }
    }
}
