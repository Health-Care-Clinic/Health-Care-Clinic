using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Vacation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DoctorId { get; set; }
        public Vacation() {}
        public Vacation(int id, string description, DateTime startTime, DateTime endTime, int doctorId)
        {
            Id = id;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            DoctorId = doctorId;
        }
    }
}
