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
        Patient FindByToken(string token);
        void ActivatePatientsAccount(Patient patient);
        string GenerateHashcode(string password);
        public Task SendMail(MailRequest mailRequest);
        public List<string> GetAllUsernames();
        public void BlockPatientById(int id);
    }
}
