using System;
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

        public Prescription() { }

        public Prescription(int id, string diagnosis, string medicine, int quantity, DateTime date, int patientId, Patient patient)
        {
            Id = id;
            Diagnosis = diagnosis;
            Medicine = medicine;
            Quantity = quantity;
            Date = date;
            PatientId = patientId;
            Patient = patient;
        }
    }
}
