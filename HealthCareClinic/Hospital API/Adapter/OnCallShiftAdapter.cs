using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class OnCallShiftAdapter
    {
        public static OnCallShift OnCallShiftDTOToOnCallShift(OnCallShiftDTO dto)
        {
            OnCallShift onCallShift = new OnCallShift();

            onCallShift.Id = dto.Id;
            onCallShift.Date = dto.Date;
            onCallShift.DoctorId = dto.DoctorId;

            return onCallShift;
        }

        public static OnCallShiftDTO OnCallShiftToOnCallShiftDTO(OnCallShift onCallShift)
        {
            OnCallShiftDTO dto = new OnCallShiftDTO();

            dto.Id = onCallShift.Id;
            dto.Date = onCallShift.Date;
            dto.DoctorId = onCallShift.DoctorId;

            return dto;
        }
    }
}
