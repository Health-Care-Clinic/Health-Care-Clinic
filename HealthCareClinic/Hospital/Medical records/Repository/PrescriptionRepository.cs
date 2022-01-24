using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Medical_records.Model;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Model;

namespace Hospital.Medical_records.Repository
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        private readonly HospitalDbContext _dbContext;

        public PrescriptionRepository(HospitalDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public List<Prescription> GetAllPrescriptionsForPatient(Patient patient)
        {
            return _dbContext.Prescriptions.Where(pres => pres.PatientId == patient.Id).ToList();
        }
    }
}
