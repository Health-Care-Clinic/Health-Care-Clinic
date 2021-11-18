using ClinicCore.Service;
using Hospital.Repository.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service
{
    public class PatientService : IService<Patient>
    {
        private readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public void Add(Patient entity)
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

        public bool CheckIfPasswordsMatch(Patient patient)
        { 
            if (patient.Password != patient.RePassword)
                return false;
            return true;
        }
    }
}
