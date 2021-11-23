using Hospital.Mapper;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hospital.Medical_records.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly HospitalDbContext dbContext;
        public PatientRepository(HospitalDbContext context) : base(context)
        {
            dbContext = context;
        }
    }

}
