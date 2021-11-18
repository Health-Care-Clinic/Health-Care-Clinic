using Hospital.Repository.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hospital.Repository
{
    public class PatientRepository : IPatientRepository
    {
        public void Add(Patient entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> Find(Expression<Func<Patient, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
