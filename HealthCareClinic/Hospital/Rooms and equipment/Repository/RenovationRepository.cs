using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public class RenovationRepository : Repository<Renovation>, IRenovationRepository
    {
        public RenovationRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }
    }
}
