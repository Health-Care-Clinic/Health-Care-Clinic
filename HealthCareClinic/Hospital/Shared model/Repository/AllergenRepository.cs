using Hospital.Mapper;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public class AllergenRepository : Repository<Allergen>, IAllergenRepository
    {
        public AllergenRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }
    }
}
