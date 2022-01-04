using ClinicCore.Service;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public interface IWorkDayShiftService : IService<WorkDayShift>
    {
        public bool AddWorkDayShift(WorkDayShift workDayShift);
        public void RemoveWorkDayShift(int workDayShiftToRemove);
        public void RemoveById(int id);
    }
}
