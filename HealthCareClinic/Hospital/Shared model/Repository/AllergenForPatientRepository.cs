using Hospital.Mapper;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public class AllergenForPatientRepository : Repository<AllergenForPatient>, IAllergenForPatientRepository
    {
        private readonly HospitalDbContext dbContext;

        public AllergenForPatientRepository(HospitalDbContext context) : base(context)
        {
            dbContext = context;
        }
    }
}
