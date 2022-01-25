using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class PrescriptionPatientDTO
    {
        public DoctorDTO Doctor { get; set; }
        public string Diagnosis { get; set; }
        public string Medicine { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }

        public int AppointmentId { get; set; }

        public PrescriptionPatientDTO()
        {
        }

        public PrescriptionPatientDTO(DoctorDTO doctor, string diagnosis, string medicine, int quantity, string date)
        {
            Doctor = doctor;
            Diagnosis = diagnosis;
            Medicine = medicine;
            Quantity = quantity;
            Date = date;
        }
    }

}
