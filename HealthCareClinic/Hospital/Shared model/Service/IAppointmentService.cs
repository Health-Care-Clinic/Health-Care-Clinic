using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public interface IAppointmentService : IService<Appointment>
    {
        public List<Appointment> getAppointmentsByPatientId(int patinetId);
        public Appointment CancelAppointment(int appointmentId);
        public List<DateTime> GetAvailableTermsForDoctor(Doctor doctor, DateTime fromDate, DateTime toDate);
        public void AddAppointment(Appointment app);
        public List<Appointment> GetRoomAppointments(int id);
    }
}
