using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Vacation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual DateSpan DateSpan { get; set; }
        public int DoctorId { get; set; }
        public Vacation() {}
        public Vacation(int id, string description, DateTime startTime, DateTime endTime, int doctorId)
        {
            Id = id;
            Description = description;
            DateSpan = new DateSpan(startTime, endTime);
            DoctorId = doctorId;
            Validate(description);
        }

        public Vacation(int id, string description, DateSpan dateSpan, int doctorId)
        {
            Id = id;
            Description = description;
            DateSpan = dateSpan;
            DoctorId = doctorId;
            Validate(description);
        }

        private void Validate(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description can not be null", "description");
        }
        public bool GetVacationAvailability(List<Vacation> allVacations)
        {
            foreach (var v in allVacations.Select(x => x.DateSpan))
            {
                if ((this.DateSpan.StartTime.CompareTo(v.StartTime) > 0 && this.DateSpan.StartTime.CompareTo(v.EndTime) < 0)
                    || (this.DateSpan.EndTime.CompareTo(v.StartTime) > 0 && this.DateSpan.EndTime.CompareTo(v.EndTime) < 0))
                {
                    return false;
                }
            }

            return true;
        }

        public bool GetChangedVacationAvailability(List<Vacation> allVacations)
        {
            foreach (Vacation v in allVacations)
            {
                if (!this.Id.Equals(v.Id) &&
                    ((this.DateSpan.StartTime.CompareTo(v.DateSpan.StartTime) > 0 && this.DateSpan.StartTime.CompareTo(v.DateSpan.EndTime) < 0)
                    || (this.DateSpan.EndTime.CompareTo(v.DateSpan.StartTime) > 0 && this.DateSpan.EndTime.CompareTo(v.DateSpan.EndTime) < 0)))
                {
                    return false;
                }
            }

            return true;
        }


    }
}
