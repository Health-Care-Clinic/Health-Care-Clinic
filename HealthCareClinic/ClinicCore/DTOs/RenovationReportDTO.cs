using System;

namespace ClinicCore.DTOs
{
    public class RenovationReportDTO
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int RoomNumber { get; set; }
        public String AppCause { get; set; }

        public RenovationReportDTO(DateTime dateStart, DateTime dateEnd, int roomNumber, string appCause)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
            RoomNumber = roomNumber;
            AppCause = appCause;
        }
    }
}
