using System;

namespace DTOs
{
    public class PrescriptionDTO
    {
        public MedicineDTO Medicine { get; set; }
        public DateTime DatePrescribed { get; set; }


        public PrescriptionDTO(MedicineDTO med, DateTime datePrescribed)
        {
            Medicine = med;
            DatePrescribed = datePrescribed;
        }
    }
}
