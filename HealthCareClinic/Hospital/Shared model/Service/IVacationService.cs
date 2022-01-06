using ClinicCore.Service;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public interface IVacationService : IService<Vacation>
    {
        public void Change(Vacation entity);
        public void RemoveById(int id);
        public List<Vacation> GetVacationsByDoctorId(int doctorId);
        public List<Vacation> GetPastVacationsByDoctorId(int doctorId);
        public List<Vacation> GetCurrentVacationsByDoctorId(int doctorId);
        public List<Vacation> GetFutureVacationsByDoctorId(int doctorId);
        public bool GetVacationAvailability(int doctorId, DateTime vacationStart, DateTime vacationEnd);
        public bool GetChangedVacationAvailability(Vacation vacation);

    }
}
