using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class WorkDayShiftAdapter
    {
        public static WorkDayShift WorkDayShiftDTOToWorkDayShift(WorkDayShiftDTO dto)
        {
            WorkDayShift workDayShift = new WorkDayShift();

            workDayShift.Id = dto.Id;
            workDayShift.Name = dto.Name;
            workDayShift.StartTime = dto.StartTime;
            workDayShift.EndTime = dto.EndTime;

            return workDayShift;
        }

        public static WorkDayShiftDTO WorkDayShiftToWorkDayShiftDTO(WorkDayShift workDayShift)
        {
            WorkDayShiftDTO dto = new WorkDayShiftDTO();

            dto.Id = workDayShift.Id;
            dto.Name = workDayShift.Name;
            dto.StartTime = workDayShift.StartTime;
            dto.EndTime = workDayShift.EndTime;

            return dto;
        }
    }
}
