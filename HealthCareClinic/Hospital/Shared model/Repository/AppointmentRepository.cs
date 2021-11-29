using Hospital.Mapper;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hospital.Shared_model.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly HospitalDbContext dbContext;
        public AppointmentRepository(HospitalDbContext context) : base(context)
        {
            dbContext = context;
        }

        public List<Appointment> getAppointmentsByPatientId(int patinetId)
        {
            return dbContext.Appointments.Where(app => app.PatientId == patinetId).ToList();
        }
    }
}
