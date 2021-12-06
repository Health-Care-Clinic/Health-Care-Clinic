using Hospital.Mapper;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Hospital.Schedule.Model;

namespace Hospital.Medical_records.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly HospitalDbContext dbContext;
        public PatientRepository(HospitalDbContext context) : base(context)
        {
            dbContext = context;
        }

        public void ActivatePatientsAccount(int id)
        {
            Patient patient = GetById(id);
            patient.IsActive = true;
            Save();
        }

        public void BlockPatientById(int id)
        {
            Patient patient = GetById(id);
            patient.IsBlocked = true;
            Save();
        }

        public Patient FindByToken(string token)
        {
            return dbContext.Patients.SingleOrDefault(p => p.Hashcode.Equals(token));
        }

        public List<Patient> GetAllSuspiciousPatients()
        {
            var allPatientsIds = (from patient in dbContext.Patients
                                       where patient.IsActive == true && patient.IsBlocked == false
                                       select patient.Id);

            IQueryable<CanceledAppointment> allCanceledAppsInLastMonths = dbContext.CanceledAppointments.Where(c => allPatientsIds.Contains(c.PatientId) && (DateTime.Now.Date - c.DateOfCancellation.Date).Days < 30);

            var patientIdsWithNumberOfCanceledAppointments = dbContext.CanceledAppointments.GroupBy(c => c.PatientId).Select(a => new { patientId = a.Key, count = a.Count() });

            var resultIds = (from idAndCount in patientIdsWithNumberOfCanceledAppointments
                             where idAndCount.count > 3
                             select idAndCount.patientId);

            return dbContext.Patients.Where(p => resultIds.Contains(p.Id)).ToList();
        }

        public List<string> GetAllUsernames()
        {
            return dbContext.Patients.Select(p => p.Username).ToList();
        }
    }

}
