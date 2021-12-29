using ClinicCore.Service;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public interface IOnCallShiftService : IService<OnCallShift>
    {
        List<OnCallShift> GetOnCallShiftByDoctorId(int doctorId);
        public List<DateTime> GetFreeDates(int month);
        public int returnKey();
    }
}
