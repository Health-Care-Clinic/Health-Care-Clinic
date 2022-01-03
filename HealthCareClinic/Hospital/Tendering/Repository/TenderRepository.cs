using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Repository
{
    public class TenderRepository : Repository<Tender>, ITenderRepository
    {
        public TenderRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext PharmacyDbContext
        {
            get { return Context as HospitalDbContext; }
        }
    }
}
