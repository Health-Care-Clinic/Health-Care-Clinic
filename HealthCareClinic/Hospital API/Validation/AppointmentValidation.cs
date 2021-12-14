using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Validation
{
    public class AppointmentValidation
    {
        public AppointmentValidation()
        {
        }

        public static bool ValidateInputDoctorIdDateFromDateToDTO(DoctorIdDateFromDateToDTO dto, DateTime fromDate, DateTime toDate)
        {
            if (dto.DoctorId < 0)
                return false;
            if (toDate < fromDate)
                return false;
            return true;
        }
    }
}
