using System;
using System.Collections.Generic;
using Hospital.Shared_model.Model;

namespace Hospital.Medical_records.Model
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Medicine { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }

        public Prescription() { }

        public Prescription(int id, string diagnosis, string medicine, int quantity, DateTime date, int patientId)
        {
            Id = id;
            Diagnosis = diagnosis;
            Medicine = medicine;
            Quantity = quantity;
            Date = date;
            PatientId = patientId;
        }

        public Prescription(int id, string diagnosis, string medicine, int quantity, DateTime date, int patientId, int appointmentId) : this(id, diagnosis, medicine, quantity, date, patientId)
        {
            AppointmentId = appointmentId;
        }
    }
}
