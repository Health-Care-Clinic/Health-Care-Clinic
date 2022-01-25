using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    [Owned]
    public class DateSpan
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DateSpan(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            Validate();
        }

        public DateSpan() { }

        private void Validate()
        {
            if (this.StartTime.CompareTo(this.EndTime) >= 0){
                throw new ArgumentException("Start time can't be after end.");
            }
        }
    }
}
