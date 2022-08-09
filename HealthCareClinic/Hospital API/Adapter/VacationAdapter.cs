using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class VacationAdapter
    {
        public static Vacation VacationDTOToVacation(VacationDTO dto)
        {
            Vacation vacation = new Vacation();

            vacation.Id = dto.Id;
            vacation.Description = dto.Description;
            vacation.DateSpan = new DateSpan(dto.StartTime, dto.EndTime);
            vacation.DoctorId = dto.DoctorId;

            return vacation;
        }

        public static VacationDTO VacationToVacationDTO(Vacation vacation)
        {
            VacationDTO dto = new VacationDTO();

            dto.Id = vacation.Id;
            dto.Description = vacation.Description;
            dto.StartTime = vacation.DateSpan.StartTime;
            dto.EndTime = vacation.DateSpan.EndTime;
            dto.DoctorId = vacation.DoctorId;

            return dto;
        }
    }
}
