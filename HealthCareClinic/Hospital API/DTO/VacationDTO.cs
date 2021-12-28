using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class VacationDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DoctorId { get; set; }

        public VacationDTO() {}
        public VacationDTO(int id, string description, DateTime startTime, DateTime endTime, int doctorId)
        {
            Id = id;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            DoctorId = doctorId;
        }
    }
}
