using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class WorkDay
    {
        [Key]
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public WorkDay()
        { }
        public WorkDay(DayOfWeek day, DateTime startTime, DateTime endTime)
        {
            this.Day = day;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
