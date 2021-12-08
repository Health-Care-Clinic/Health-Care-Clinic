using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Medical_records.Model;
using Hospital.Medical_records.Repository.Interface;

namespace Hospital.Medical_records.Repository
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        private readonly HospitalDbContext _dbContext;

        public PrescriptionRepository(HospitalDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
