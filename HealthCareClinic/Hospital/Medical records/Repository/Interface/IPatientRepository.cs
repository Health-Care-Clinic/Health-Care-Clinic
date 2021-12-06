
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System.Collections.Generic;

namespace Hospital.Medical_records.Repository.Interface
{
    public interface IPatientRepository : IRepository<Patient>
    {
        public void ActivatePatientsAccount(int id);
        public Patient FindByToken(string token);
        public List<string> GetAllUsernames();
        public void BlockPatientById(int id);
        public List<Patient> GetAllSuspiciousPatients();
    }
}
