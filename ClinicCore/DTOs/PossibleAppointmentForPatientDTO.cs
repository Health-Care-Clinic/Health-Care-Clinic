using Model;
using System;

namespace ClinicCore.DTOs
{
    public class PossibleAppointmentForPatientDTO
    {
        public String TimeSlot { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
        public Boolean Priority { get; set; }

        public PossibleAppointmentForPatientDTO(String timeSlot, Doctor doctor, Patient patient, DateTime date, bool priority)
        {
            this.TimeSlot = timeSlot;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Date = date;
            this.Priority = priority;
        }
    }
}
