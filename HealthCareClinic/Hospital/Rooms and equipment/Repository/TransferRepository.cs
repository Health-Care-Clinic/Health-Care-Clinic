using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public class TransferRepository : Repository<Transfer>, ITransferRepository
    {
        public TransferRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public void RemoveById(int id) 
        {
            Context.Set<Transfer>().Remove(Context.Set<Transfer>().Find(id));
            Context.SaveChanges();
        }
    }
}
