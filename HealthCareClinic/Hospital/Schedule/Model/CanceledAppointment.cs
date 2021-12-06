using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class CanceledAppointment
    {
        public DateTime DateOfCancellation { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }

        public CanceledAppointment()
        {
        }

        public CanceledAppointment(int id, DateTime dateOfcancellation, int patientId, int appointmentId)
        {
            DateOfCancellation = dateOfcancellation;
            PatientId = patientId;
            AppointmentId = appointmentId;
        }
    }
}
