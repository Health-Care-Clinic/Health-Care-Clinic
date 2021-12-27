using Hospital.Mapper;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public class OnCallShiftRepository : Repository<OnCallShift>, IOnCallShiftRepository
    {
        public OnCallShiftRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public List<OnCallShift> GetOnCallShiftByDoctorId(int id)
        {
            return Context.Set<OnCallShift>().Where(c => c.DoctorId == id).ToList();
        }
    }
}
