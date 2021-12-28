using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class WorkDayShiftDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public WorkDayShiftDTO(int id, String name, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        public WorkDayShiftDTO() { }
    }
}
