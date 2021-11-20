﻿using Hospital.Mapper;
using Hospital.Repository.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace Hospital.Repository
{
    class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext dbContext;

        public DoctorRepository(HospitalDbContext context)
        {
            dbContext = context;
        }
        public void Add(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> Find(Expression<Func<Doctor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Doctor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetNonOverOcuipedDoctors()
        {
            List<Doctor> nonOverOccupiedDoctors = new List<Doctor>();
            int min = dbContext.Doctors.Min(d => d.patient.Count);
            nonOverOccupiedDoctors = dbContext.Doctors.Where(d => d.patient.Count <= min + 2).ToList();
            return nonOverOccupiedDoctors;
        }
    }
}
