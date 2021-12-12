using Hospital.Mapper;
using Hospital.Medicines.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medicines.Repository
{
    public class MedicineRepository : Repository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }
    }
}
