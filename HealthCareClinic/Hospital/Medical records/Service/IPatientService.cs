using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medical_records.Service
{
    public interface IPatientService : IService<Patient>
    {
        Patient FindByToken(string token);
        void ActivatePatientsAccount(Patient patient);
        string GenerateHashcode(string username);
        void SendMail(Patient newPatient);
    }
}
