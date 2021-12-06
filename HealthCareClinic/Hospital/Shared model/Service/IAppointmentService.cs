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
    }
}
