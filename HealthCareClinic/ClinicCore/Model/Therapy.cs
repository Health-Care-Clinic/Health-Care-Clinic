using System;

namespace Model
{
    public class Therapy
    {
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
        public int TimesADay { get; set; }
        public DateTime TherapyStart { get; set; }
        public DateTime TherapyEnd { get; set; }
        public int FirstUsageTime { get; set; }
        public DateTime LastTimeIssued { get; set; }

        public Therapy(Medicine medicine, int quantity, int timesADay, DateTime start, DateTime end)
        {
            Medicine = medicine;
            Quantity = quantity;
            TimesADay = timesADay;
            TherapyStart = start;
            TherapyEnd = end;
            LastTimeIssued = start;
        }
    }
}
