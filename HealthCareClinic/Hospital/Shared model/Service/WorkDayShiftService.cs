using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public class WorkDayShiftService : IWorkDayShiftService
    {
        private readonly IWorkDayShiftRepository _workDayShiftRepository;

        public WorkDayShiftService(IWorkDayShiftRepository workDayShiftRepository)
        {
            _workDayShiftRepository = workDayShiftRepository;
        }

        public void Add(WorkDayShift entity)
        {
            _workDayShiftRepository.Add(entity);
        }

        public IEnumerable<WorkDayShift> GetAll()
        {
            return _workDayShiftRepository.GetAll();
        }

        public WorkDayShift GetOneById(int id)
        {
            return _workDayShiftRepository.GetById(id);
        }

        public void Remove(WorkDayShift entity)
        {
            _workDayShiftRepository.Remove(entity);
        }
    }
}
