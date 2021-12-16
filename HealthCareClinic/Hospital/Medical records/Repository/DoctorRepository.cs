using Hospital.Mapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Hospital.Shared_model.Model;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Repository;

namespace Hospital.Medical_records.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly HospitalDbContext dbContext;

        public DoctorRepository(HospitalDbContext context) : base(context)
        {
            dbContext = context;
        }
        public List<Doctor> GetAvailableDoctors()
        {
            IQueryable<Doctor> generalMedicineDoctors = dbContext.Doctors.Where(d => d.Specialty.ToLower().Equals("general medicine"));
            int min = generalMedicineDoctors.Min(d => d.Patients.Where(p => p.IsActive && !p.IsBlocked).Count());
            List<Doctor> nonOverOccupiedDoctors = generalMedicineDoctors.Where(d => d.Patients.Where(p => p.IsActive && !p.IsBlocked).Count() <= min + 2).ToList();
            return nonOverOccupiedDoctors;
        }

        public List<String> GetAllSpecialties()
        {
            IQueryable<String> specialtyNames = dbContext.Doctors.Select(d => d.Specialty).Distinct();

            return specialtyNames.ToList();
        }

        public List<Doctor> GetDoctorsBySpecialty(string specialty)
        {
            IQueryable<Doctor> doctorsWithSpecialty = dbContext.Doctors.Where(d => d.Specialty.ToLower().Equals(specialty.ToLower()));

            return doctorsWithSpecialty.ToList();
        }
    }
}
