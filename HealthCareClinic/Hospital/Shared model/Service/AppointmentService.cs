﻿using Hospital.Schedule.Model;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return appointmentRepository.GetAll();
        }

        public Appointment GetOneById(int id)
        {
            return appointmentRepository.GetById(id);
        }

        public void Remove(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentsByPatientId(int patinetId)
        {
            return appointmentRepository.GetAppointmentsByPatientId(patinetId);
        }

        public Appointment CancelAppointment(int appointmentId)
        {
           return appointmentRepository.CancelAppointment(appointmentId);
        }

        public List<DateTime> GetAvailableTermsForDoctor(Doctor doctor, DateTime fromDate, DateTime toDate)
        {
            return appointmentRepository.GetAvailableTermsForDoctor(doctor, fromDate, toDate);
        }

        public TermsInDateRange GetAvailableTermsForDateRange(TermsInDateRange initialObjectWithoutTerms, List<Doctor> doctorsWithSpecialty)
        {
            return appointmentRepository.GetAvailableTermsForDateRange(initialObjectWithoutTerms, doctorsWithSpecialty);
        }

        public void AddAppointment(Appointment app)
        {
            appointmentRepository.AddAppointment(app);
        }

        public List<Appointment> GetRoomAppointments(int id)
        {
            List<Appointment> roomAppointments = new List<Appointment>();
            foreach (Appointment appointment in GetAll())
            {
                if (appointment.RoomId == id && !appointment.isDone)
                    roomAppointments.Add(appointment);
            }
            return roomAppointments;
        }

        public List<DateTime> GetAvailableTerms(Doctor selectedDoctor, DateTime selectedDate)
        {
            return appointmentRepository.GetAvailableTerms(selectedDoctor, selectedDate);
        }

        public int GetNumOfAppointments(int id, int month, int year)
        {
           List<Appointment> allAppointments = appointmentRepository.getAppointmentsByDoctorId(id);
            int number = 0;
           foreach(Appointment ap in allAppointments.Where(x=> (x.Date.Date.Year.Equals(year) && x.Date.Date.Month.Equals(month))))
            {
                    number = number + 1;  
            }
            return number;
        }
        public int GetNumOfPatients(int id, int month, int year)
        {
            List<Appointment> allAppointments = appointmentRepository.getAppointmentsByDoctorId(id);
            List<int> idOfPatients = new List<int>();
            int number = 0;
            foreach (Appointment ap in allAppointments.Where(x=> x.Date.Date.Year.Equals(year) && x.Date.Date.Month.Equals(month) && !idOfPatients.Contains(x.PatientId)))
            {
                    number = number + 1;
                    idOfPatients.Add(ap.PatientId);
            }
            return number;
        }
    }
}
