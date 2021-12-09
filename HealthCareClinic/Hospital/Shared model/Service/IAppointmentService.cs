using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public interface IAppointmentService : IService<Appointment>
    {
        List<Appointment> getAppointmentsByPatientId(int patinetId);
        Appointment CancelAppointment(int appointmentId);
        List<DateTime> GetAvailableTermsForDoctor(Doctor doctor, DateTime fromDate, DateTime toDate);
        List<DateTime> GetAvailableTermsForDateRange(List<Doctor> doctorsWithGivenSpecialty, DateTime beginningDate, DateTime endingDate);
        void AddAppointment(Appointment app);
    }
}
