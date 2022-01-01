using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddWorkDayShift(WorkDayShift workDayShift)
        {
            AdjustStartAndEndTime(workDayShift);
            if (CheckIfStartTimeIsBeforeEndTime(workDayShift) && CheckIfShiftDoesntOverlapWithOnCallShift(workDayShift) && CheckIfShiftDoesntOverlapWithOtherShifts(workDayShift))
            {
                Add(workDayShift);
                return true;
            }
            else
                return false;
        }

        private void AdjustStartAndEndTime(WorkDayShift workDayShift)
        {
            DateTime newStartTime = new DateTime(2022, 2, 22) + workDayShift.StartTime.TimeOfDay;
            DateTime newEndTime = new DateTime(2022, 2, 22) + workDayShift.EndTime.TimeOfDay;
            workDayShift.StartTime = newStartTime;
            workDayShift.EndTime = newEndTime;
        }

        private bool CheckIfStartTimeIsBeforeEndTime(WorkDayShift workDayShift) 
        {
            if (workDayShift.StartTime < workDayShift.EndTime)
                return true;
            else
                return false;
        }

        private bool CheckIfShiftDoesntOverlapWithOnCallShift(WorkDayShift workDayShift)
        {
            DateTime earliestShiftStartTime = new DateTime(2022, 2, 22, 7, 0, 0);
            DateTime latestShiftEndTime = new DateTime(2022, 2, 22, 19, 0, 0);
            if (workDayShift.StartTime >= earliestShiftStartTime && workDayShift.EndTime <= latestShiftEndTime)
                return true;
            else
                return false;
        }

        private bool CheckIfShiftDoesntOverlapWithOtherShifts(WorkDayShift workDayShift)
        {
            List<WorkDayShift> allWorkDayShifts = GetAll().ToList();

            foreach (WorkDayShift wds in allWorkDayShifts) 
            {
                if (!(workDayShift.StartTime >= wds.EndTime || workDayShift.EndTime <= wds.StartTime))
                {
                    return false;
                }
            }

            return true;
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
