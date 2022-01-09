using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Repository
{
    public class TenderResponseRepository : Repository<TenderResponse>, ITenderResponseRepository
    {
        public TenderResponseRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public void Update(TenderResponse entity)
        {
            HospitalDbContext.TenderResponses.Update(entity);
            HospitalDbContext.SaveChanges();
        }
    }
}
