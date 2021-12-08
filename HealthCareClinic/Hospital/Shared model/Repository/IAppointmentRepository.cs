using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public List<Appointment> getAppointmentsByPatientId(int patinetId);
        public Appointment CancelAppointment(int appointmentId);
        public List<DateTime> GetAvailableTermsForDoctor(Doctor doctor, DateTime fromDate, DateTime toDate);
    }
}
