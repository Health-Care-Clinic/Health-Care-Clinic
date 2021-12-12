using Hospital.Mapper;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public class AllergenRepository : Repository<Allergen>, IAllergenRepository
    {
        private readonly HospitalDbContext dbContext;

        public AllergenRepository(HospitalDbContext context) : base(context)
        {
            dbContext = context;
        }
    }
}
