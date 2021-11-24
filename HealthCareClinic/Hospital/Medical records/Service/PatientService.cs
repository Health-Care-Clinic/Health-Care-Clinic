using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medical_records.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public void Add(Patient entity)
        {
            patientRepository.Add(entity);
            
        }

        public void ActivatePatientsAccount(Patient patient) //AKTIVACIJA 
        {
            patientRepository.ActivatePatientsAccount(patient.Id); //mozda ne moze ovako ne znam da li je SAVE() iz repo dovoljna da unese izmenu u bazu
        }

        public Patient FindByToken(string token)//PRONALZAENJE PACIJENTA PO TOKENU
        {
            return patientRepository.FindByToken(token);
        }
        public string GenerateHashcode(string username) //TODO TOKENIZACIJA
        {
            throw new NotImplementedException();
        }

        public void SendMail(Patient newPatient) //TODO SLANJE MAILA
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
