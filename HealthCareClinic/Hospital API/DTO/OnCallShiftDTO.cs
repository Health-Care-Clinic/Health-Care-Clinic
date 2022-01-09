using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class OnCallShiftDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }

        public OnCallShiftDTO()
        {

        }
        public OnCallShiftDTO(int id, DateTime date, int doctorId)
        {
            Id = id;
            Date = date;
            DoctorId = doctorId;
        }
    }
}
