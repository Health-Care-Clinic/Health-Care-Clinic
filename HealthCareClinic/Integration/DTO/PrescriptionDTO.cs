namespace Integration.DTO
{
    public class PrescriptionDTO
    {
        public string Patient { get; set; }
        public string Diagnosis { get; set; }
        public string Medicine { get; set; }
        public int Amount { get; set; }
        public string Pharmacy { get; set; }
        public string Date { get; set; }

        public PrescriptionDTO() { }

        public PrescriptionDTO(string patient, string diagnosis, string medicine, int amount, string pharmacy, string date)
        {
            Patient = patient;
            Diagnosis = diagnosis;
            Medicine = medicine;
            Amount = amount;
            Pharmacy = pharmacy;
            Date = date;
        }
    }
}
