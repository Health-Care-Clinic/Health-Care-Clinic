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
            get { return (HospitalDbContext) Context; }
        }

        public List<OnCallShift> GetOnCallShiftByDoctorId(int id)
        {
            return Context.Set<OnCallShift>().Where(c => c.DoctorId == id).ToList();
        }

        public void RemoveById(int id)
        {
            Context.Set<OnCallShift>().Remove(Context.Set<OnCallShift>().Find(id));
            Context.SaveChanges();
        }
    }
}
