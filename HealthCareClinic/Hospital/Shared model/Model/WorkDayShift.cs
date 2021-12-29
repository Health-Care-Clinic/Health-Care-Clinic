using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class WorkDayShift
    {
        public int Id { get; set; } 
        public String Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public WorkDayShift(int id, String name, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        public WorkDayShift() { }
    }
}
