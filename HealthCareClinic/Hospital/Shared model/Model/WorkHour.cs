using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    [Owned]
    public class WorkHour
    {
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public WorkHour(DateTime start, DateTime end)
        {
            StartTime = new DateTime(2022, 2, 22) + start.TimeOfDay;
            EndTime = new DateTime(2022, 2, 22) + end.TimeOfDay;
            Validate();
        }

        public WorkHour()
        {

        }
        private void Validate()
        {
            CheckIfShiftDoesntOverlapWithOnCallShift();
            CheckIfStartTimeIsBeforeEndTime();
        }

        private void CheckIfStartTimeIsBeforeEndTime()
        {
            if (this.StartTime < this.EndTime)
                return;
            else
                throw new ArgumentException("Start can't be after end.");
        }

        private void CheckIfShiftDoesntOverlapWithOnCallShift()
        {
            DateTime earliestShiftStartTime = new DateTime(2022, 2, 22, 7, 0, 0);
            DateTime latestShiftEndTime = new DateTime(2022, 2, 22, 19, 0, 0);
            if (this.StartTime >= earliestShiftStartTime && this.EndTime <= latestShiftEndTime)
                return;
            else
                throw new ArgumentException("Shift with on call shift.");
        }
    }
}
