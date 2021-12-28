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
            IEnumerable<OnCallShift> onCallShifts = _onCallShiftRepository.GetAll();
            foreach (OnCallShift ocshift in onCallShifts)
            {
                if (!isDateFree(ocshift.Date, freeDates))
                    freeDates.Remove(new DateTime(ocshift.Date.Year, ocshift.Date.Month, ocshift.Date.Day));
            }

            return freeDates;
        }

        private Boolean isDateFree(DateTime busyDate, List<DateTime> freeDates)
        {
            foreach (DateTime d in freeDates)
            {
                if (d.Year == busyDate.Year && d.Month == busyDate.Month && d.Day == busyDate.Day)
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
                    dates.Add(new DateTime(DateTime.Now.Year, month, i));
                }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
                for (int i = 1; i <= 30; i++)
                {
                    dates.Add(new DateTime(DateTime.Now.Year, month, i));
                }
            else
            {
                if (DateTime.Now.Year % 4 == 0)
                {
                    for (int i = 1; i <= 29; i++)
                    {
                        dates.Add(new DateTime(DateTime.Now.Year, month, i));
                    }
                }
                else
                {
                    for (int i = 1; i <= 28; i++)
                    {
                        dates.Add(new DateTime(DateTime.Now.Year, month, i));
                    }
                }
            }

            return dates;
        }
    }
}
