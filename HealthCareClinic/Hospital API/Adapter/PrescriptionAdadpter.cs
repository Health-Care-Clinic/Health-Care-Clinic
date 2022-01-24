using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Medical_records.Model;
using Hospital_API.DTO;

namespace Hospital_API.Adapter
{
    public class PrescriptionAdadpter
    {
        public static Prescription PrescriptionDTOToPrescription(PrescriptionDTO dto)
        {
            Prescription prescription = new Prescription();
            prescription.Diagnosis = dto.Diagnosis;
            prescription.Medicine = dto.Medicine;
            prescription.Quantity = dto.Amount;
            prescription.Date = StringToDate(dto.Date);
            prescription.PatientId = 1;
            return prescription;
        }

        public static PrescriptionPatientDTO PrescriptionToPrescriptionPatientDTO(Prescription prescription)
        {
            PrescriptionPatientDTO dto = new PrescriptionPatientDTO();
            dto.Diagnosis = prescription.Diagnosis;
            dto.Medicine = prescription.Medicine;
            dto.Quantity = prescription.Quantity;
            dto.Date = ConvertToString(prescription.Date);
            //dto.Doctor = prescription.Appointment.DoctorId
            return dto;
        }

        private static DateTime StringToDate(string date)
        {
            string[] parts = date.Split("-");
            DateTime newDate = new DateTime(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            return newDate;
        }
        private static String ConvertToString(DateTime date)
        {
            String dateAsString = date.ToString();

            return dateAsString;
        }
    }
}
