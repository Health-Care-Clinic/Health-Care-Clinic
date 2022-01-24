using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    public class DateAndDuration
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public DateAndDuration() { }
        public DateAndDuration(DateTime date, int duration)
        {
            Date = date;
            Duration = duration;
            Validate();
        }

        private void Validate()
        {
            CheckDuration();
        }

        private void CheckDuration()
        {
            if (Duration <= 0)
                throw new ArgumentException("Duration of transfer can't be 0 or less!");
        }
    }
}
