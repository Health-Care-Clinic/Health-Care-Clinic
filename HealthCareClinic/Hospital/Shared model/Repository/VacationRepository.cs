using Hospital.Mapper;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public class VacationRepository : Repository<Vacation>, IVacationRepository
    {
        public VacationRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return (HospitalDbContext) Context; }
        }

        public void Change(Vacation entity)
        {
            Context.Set<Vacation>().Find(entity.Id).Description = entity.Description;
            Context.Set<Vacation>().Find(entity.Id).DateSpan = new DateSpan(entity.DateSpan.StartTime, entity.DateSpan.EndTime);

            Save();
        }

        public void RemoveById(int id)
        {
            Context.Set<Vacation>().Remove(Context.Set<Vacation>().Find(id));
            Context.SaveChanges();
        }

        public List<Vacation> GetVacationsByDoctorId(int id)
        {
            return Context.Set<Vacation>().Where(c => c.DoctorId == id).ToList();
        }
    }
}
