using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class WorkDayShift
    {
        public int Id { get; set; } 
        public String Name { get; set; }
        
        public virtual WorkHour WorkHour { get; set; }

        public WorkDayShift() { }

        public WorkDayShift(int id, String name, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Name = name;
            WorkHour = new WorkHour(startTime, endTime);
            Validate();
        }

        public WorkDayShift(int id, string name, WorkHour workHour)
        {
            Id = id;
            Name = name;
            WorkHour = workHour;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                throw new ArgumentException("Name can not be null", "name");
        }

        private void AdjustStartAndEndTime()
        {
            DateTime newStartTime = new DateTime(2022, 2, 22) + this.WorkHour.StartTime.TimeOfDay;
            DateTime newEndTime = new DateTime(2022, 2, 22) + this.WorkHour.EndTime.TimeOfDay;
            this.WorkHour = new WorkHour(newStartTime, newEndTime);
        }

        public bool CheckIfShiftDoesntOverlapWithOtherShiftsEdit(List<WorkDayShift> allWorkDayShifts)
        {
            AdjustStartAndEndTime();
            foreach (WorkDayShift wds in allWorkDayShifts)
            {
                if (wds.Id == this.Id)
                    continue;

                if (!(this.WorkHour.StartTime >= wds.WorkHour.EndTime || this.WorkHour.EndTime <= wds.WorkHour.StartTime))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckIfShiftDoesntOverlapWithOtherShifts(List<WorkDayShift> allWorkDayShifts)
        {
            AdjustStartAndEndTime();
            foreach (var wds in allWorkDayShifts.Select(x => x.WorkHour))
            {
                if (!(this.WorkHour.StartTime >= wds.EndTime || this.WorkHour.EndTime <= wds.StartTime))
                {
                    return false;
                }
            }

            return true;
        }



    }
}
