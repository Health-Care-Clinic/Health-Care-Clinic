using ClinicCore.Storages;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public interface IOnCallShiftRepository : IRepository<OnCallShift>
    {
        public List<OnCallShift> GetOnCallShiftByDoctorId(int id);
    }
}
