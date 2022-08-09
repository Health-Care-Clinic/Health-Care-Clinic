using Hospital.Schedule.Model;
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public List<Appointment> GetAppointmentsByPatientId(int patinetId);
        public List<Appointment> getAppointmentsByDoctorId(int doctorId);
        public Appointment CancelAppointment(int appointmentId);
        public List<DateTime> GetAvailableTermsForDoctor(Doctor doctor, DateTime fromDate, DateTime toDate);
        public TermsInDateRange GetAvailableTermsForDateRange(TermsInDateRange initialObjectWithoutTerms, List<Doctor> doctorsWithSpecialty);
        public void AddAppointment(Appointment app);
        public List<DateTime> GetAvailableTerms(Doctor doctor, DateTime date);
    }
}
