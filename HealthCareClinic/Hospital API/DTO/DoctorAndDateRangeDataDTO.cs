using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class DoctorAndDateRangeDataDTO
    {
        public int DoctorId { get; set; }
        public string Specialty { get; set; }
        public string BeginningDateTime { get; set; }
        public string EndingDateTime { get; set; }

        public DoctorAndDateRangeDataDTO() {}

        public DoctorAndDateRangeDataDTO(int doctorId, string specialty, string beginningDateTime, string endingDateTime)
        {
            DoctorId = doctorId;
            Specialty = specialty;
            BeginningDateTime = beginningDateTime;
            EndingDateTime = endingDateTime;
        }
    }
}
