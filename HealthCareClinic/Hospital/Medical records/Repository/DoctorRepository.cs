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
            List<Doctor> nonOverOccupiedDoctors;
            List<Doctor> generalMedicineDoctors = dbContext.Doctors.Where(d => d.Specialty.Name.ToLower().Equals("general medicine")).ToList();

            int min = dbContext.Doctors.Where(d => d.Specialty.Name.ToLower() == "general medicine").Min(d => d.Patients.Count ); //NE RADI KADA JE PRE MINA LISTA NULL
            nonOverOccupiedDoctors = dbContext.Doctors.Where(d => d.Patients.Count <= min + 2 ).ToList();
            //System.Console.WriteLine(dbContext.Doctors.ToList());
            //nonOverOccupiedDoctors = dbContext.Doctors.Where(d => d.Specialty.Name.ToLower().Equals("general medicine")).ToList();
            return nonOverOccupiedDoctors;
        }
    }
}
