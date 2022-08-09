using Hospital.Medical_records.Repository.Interface;
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
        private readonly IDoctorRepository _doctorRepository;

        public WorkDayShiftService(IWorkDayShiftRepository workDayShiftRepository, IDoctorRepository doctorRepository)
        {
            _workDayShiftRepository = workDayShiftRepository;
            _doctorRepository = doctorRepository;
        }

        public void Add(WorkDayShift entity)
        {
            _workDayShiftRepository.Add(entity);
        }

        public void RemoveById(int id)
        {
            _workDayShiftRepository.RemoveById(id);
        }

        public bool AddWorkDayShift(WorkDayShift workDayShift)
        {
            List<WorkDayShift> allWorkDayShifts = GetAll().ToList();
            if (workDayShift.CheckIfShiftDoesntOverlapWithOtherShifts(allWorkDayShifts))
            {
                Add(workDayShift);
                return true;
            }
            else
                return false;
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

        public void RemoveWorkDayShift(int workDayShiftToRemove)
        {
            int availableWorkDayShift = GetAvailableWorkDayShiftAfterRemove(workDayShiftToRemove);
            ChangeDoctorWorkDayShifts(workDayShiftToRemove, availableWorkDayShift);
            RemoveById(workDayShiftToRemove);
        }

        private int GetAvailableWorkDayShiftAfterRemove(int workDayShiftToRemove) 
        {
            int availableWorkDayShift = 0;
            foreach (int workDayShiftId in _workDayShiftRepository.GetAll().Select(wds => wds.Id))
            {
                if (workDayShiftId != workDayShiftToRemove)
                {
                    availableWorkDayShift = workDayShiftId;
                    break;
                }
            }

            return availableWorkDayShift;
        }

        private void ChangeDoctorWorkDayShifts(int workDayShiftToRemove, int availableWorkDayShift)
        {
            foreach (Doctor d in _doctorRepository.GetAll())
            {
                if (d.WorkShiftId == workDayShiftToRemove)
                {
                    d.WorkShiftId = availableWorkDayShift;
                    _doctorRepository.ChangeWorkDayShift(d);
                }
            }
        }

        public bool EditWorkDayShift(WorkDayShift workDayShift)
        {
            List<WorkDayShift> allWorkDayShifts = GetAll().ToList();
            if (workDayShift.CheckIfShiftDoesntOverlapWithOtherShiftsEdit(allWorkDayShifts))
            {
                Edit(workDayShift);
                return true;
            }
            else
                return false;
        }

        public void Edit(WorkDayShift workDayShift)
        {
            _workDayShiftRepository.Edit(workDayShift);
        }
    }
}
