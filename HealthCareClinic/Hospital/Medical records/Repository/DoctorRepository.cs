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

        //public List<Doctor> GetAvailableDoctors()
        //{
        //    IQueryable<Doctor> generalMedicineDoctors = dbContext.Doctors.Where(d => d.Specialty.Name.ToLower().Equals("general medicine"));
        //    var activePatientsWithDoctorId  = dbContext.Patients
        //        .Join(generalMedicineDoctors,
        //         p => p.DoctorId,
        //         d => d.Id,
        //         (p, d) => new { P = p, D = d }) // selection
        //            .Where(PiD => PiD.P.IsActive == true && PiD.P.IsBlocked == false);
        //    //var ActivePatientsByDoctors = adasd.GroupBy(x => x.D.Id).Select(x => x);
        //    var activePatientsByDoctors = activePatientsWithDoctorId.ToLookup(p => p.D.Id , p => p.D.Patients);
        //    int min = activePatientsByDoctors.Min(p => p.Count());
        //    var nonOverOccupiedDoctors = activePatientsByDoctors.Where(p => p.Count() <= min + 2);
        //    var doctorsExtendedWithKey = nonOverOccupiedDoctors
        //       .Join(generalMedicineDoctors,
        //        p => p.Key,
        //        d => d.Id,
        //        (p, d) => new {P = p, D = d });
        //    //int min = generalMedicineDoctors.Min(d => d.Patients.Where(p => p.IsActive).Count);
        //    //List<Doctor> nonOverOccupiedDoctors = generalMedicineDoctors.Where(d => d.Patients.Where(p => p.IsActive == true).Count <= min + 2).ToList();
        //    List<Doctor> doctors = doctorsExtendedWithKey.Select(d => d.D).ToList();
        //    return doctors;
        //}
        public List<Doctor> GetAvailableDoctors()
        {
            IQueryable<Doctor> generalMedicineDoctors = dbContext.Doctors.Where(d => d.Specialty.Name.ToLower().Equals("general medicine"));
            int min = generalMedicineDoctors.Min(d => d.Patients/*.Where(p => p.IsActive)*/.Count);
            List<Doctor> nonOverOccupiedDoctors = generalMedicineDoctors.Where(d => d.Patients/*.Where(p => p.IsActive == true)*/.Count <= min + 2).ToList();
            return nonOverOccupiedDoctors;
        }
    }
}
