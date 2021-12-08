using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository _appointmentRepository)
        {
            this.appointmentRepository = _appointmentRepository;
        }
        public void Add(Appointment entity)
        {            
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetOneById(int id)
        {
            return appointmentRepository.GetById(id);
        }

        public void Remove(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> getAppointmentsByPatientId(int patinetId)
        {
            return appointmentRepository.getAppointmentsByPatientId(patinetId);
        }

        public Appointment CancelAppointment(int appointmentId)
        {
           return appointmentRepository.CancelAppointment(appointmentId);
        }

        public List<DateTime> GetAvailableTermsForDoctor(Doctor doctor, DateTime fromDate, DateTime toDate)
        {
            return appointmentRepository.GetAvailableTermsForDoctor(doctor, fromDate, toDate);
        }

        public void AddAppointment(Appointment app)
        {
            appointmentRepository.AddAppointment(app);
        }
    }
}
