using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class WorkDay
    {
        public Day Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public WorkDay(Day day, DateTime startTime, DateTime endTime)
        {
            this.Day = day;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
