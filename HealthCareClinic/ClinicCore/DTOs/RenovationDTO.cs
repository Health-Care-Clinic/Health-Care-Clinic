using Enums;
using System;

namespace ClinicCore.DTOs
{
    public class RenovationDTO
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public AppointmentType AppType { get; set; }

        public RenovationDTO(DateTime dateStart, DateTime dateEnd, AppointmentType appType)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
            AppType = appType;
        }
    }
}
