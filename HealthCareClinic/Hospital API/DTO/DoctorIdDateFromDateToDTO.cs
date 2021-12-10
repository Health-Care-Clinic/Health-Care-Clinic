using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class DoctorIdDateFromDateToDTO
    {
        public int DoctorId { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public DoctorIdDateFromDateToDTO(int doctorId, string from, string to)
        {
            DoctorId = doctorId;
            From = from;
            To = to;
        }

        public DoctorIdDateFromDateToDTO()
        {
        }
    }
}
