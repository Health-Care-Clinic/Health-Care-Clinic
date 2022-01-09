using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Medical_records.Service
{
    public interface IPatientService : IService<Patient>
    {
        public Patient FindByToken(string token);
        public void ActivatePatientsAccount(Patient patient);
        public string GenerateHashcode(string password);
        public Task SendMail(MailRequest mailRequest);
        public List<string> GetAllUsernames();
        public void BlockPatientById(int id);
        public List<Patient> GetAllSuspiciousPatients();
        public Patient FindByUsernameAndPassword(string username, string password);
        public string GenerateJwtToken(Patient patient);
    }
}
