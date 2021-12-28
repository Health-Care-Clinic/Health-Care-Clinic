using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public class OnCallShiftService : IOnCallShiftService
    {
        private readonly IOnCallShiftRepository _onCallShiftRepository;

        public OnCallShiftService(IOnCallShiftRepository onCallShiftRepository)
        {
            _onCallShiftRepository = onCallShiftRepository;
        }
        public void Add(OnCallShift entity)
        {
            _onCallShiftRepository.Add(entity);
        }

        public IEnumerable<OnCallShift> GetAll()
        {
            return _onCallShiftRepository.GetAll();
        }

        public List<OnCallShift> GetOnCallShiftByDoctorId(int doctorId)
        {
            return _onCallShiftRepository.GetOnCallShiftByDoctorId(doctorId);
        }

        public OnCallShift GetOneById(int id)
        {
            return _onCallShiftRepository.GetById(id);
        }

        public void Remove(OnCallShift entity)
        {
            _onCallShiftRepository.Remove(entity);
        }

        public int returnKey() 
        {
            int id = 0;
            IEnumerable<OnCallShift> onCallShifts = _onCallShiftRepository.GetAll();
            foreach (OnCallShift s in onCallShifts) {
                id++;
            }

            return (id + 1);
        }

        public List<DateTime> GetFreeDates(int month)
        {
            List<DateTime> freeDates = returnDates(month);

            return freeDates;
        }

        private Boolean isDateFree(DateTime date)
        {
            IEnumerable<OnCallShift> onCallShifts = _onCallShiftRepository.GetAll();
            foreach (OnCallShift shift in onCallShifts)
            {
                if (shift.Date.Year == date.Year && shift.Date.Month == date.Month && shift.Date.Day == date.Day)
                    return false;
            }

            return true;
        }

        private List<DateTime> returnDates(int month)
        {
            List<DateTime> dates = new List<DateTime>();
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                for (int i = 1; i <= 31; i++)
                {
                    DateTime checkDate = new DateTime(DateTime.Now.Year, month, i);
                    if (isDateFree(checkDate))
                        dates.Add(checkDate);
                }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
                for (int i = 1; i <= 30; i++) 
                {
                    DateTime checkDate = new DateTime(DateTime.Now.Year, month, i);
                    if (isDateFree(checkDate))
                        dates.Add(checkDate);
                }         
            else
                if (DateTime.Now.Year % 4 == 0)
                for (int i = 1; i <= 29; i++)
                {
                    DateTime checkDate = new DateTime(DateTime.Now.Year, month, i);
                    if (isDateFree(checkDate))
                        dates.Add(checkDate);
                }
            else
                for (int i = 1; i <= 28; i++)
                {
                    DateTime checkDate = new DateTime(DateTime.Now.Year, month, i);
                    if (isDateFree(checkDate))
                        dates.Add(checkDate);
                }

            return dates;
        }
    }
}
