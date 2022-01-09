using Hospital.Schedule.Model;
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public interface IAppointmentService : IService<Appointment>
    {
        List<Appointment> GetAppointmentsByPatientId(int patinetId);
        Appointment CancelAppointment(int appointmentId);
        List<DateTime> GetAvailableTermsForDoctor(Doctor doctor, DateTime fromDate, DateTime toDate);
        TermsInDateRange GetAvailableTermsForDateRange(TermsInDateRange initialObjectWithoutTerms, List<Doctor> doctorsWithSpecialty);
        void AddAppointment(Appointment app);
        public List<Appointment> GetRoomAppointments(int id);
        public List<DateTime> GetAvailableTerms(Doctor selectedDoctor, DateTime selectedDate);
        public int GetNumOfAppointments(int id, int month, int year);
        public int GetNumOfPatients(int id, int month, int year);
    }
}
