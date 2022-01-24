using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class DoctorSchedule
    {
        public Doctor Doctor { get; set; }
        public WorkDayShift WorkDayShift { get; set; }
        public List<Vacation> Vacations { get; set; }
        public List<OnCallShift> OnCallShifts { get; set; }
        public List<Appointment> Appointments { get; set; }

        public DoctorSchedule() { }
        public DoctorSchedule(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments) 
        {
            Doctor = doctor;
            WorkDayShift = workDayShift;
            Vacations = vacations;
            OnCallShifts = onCallShifts;
            Appointments = appointments;
        }

        public bool CheckVacationAvailability(Vacation vacation)
        {
            foreach (var v in Vacations.Select(x => x.DateSpan))
            {
                if ((vacation.DateSpan.StartTime.CompareTo(v.StartTime) > 0 && vacation.DateSpan.StartTime.CompareTo(v.EndTime) < 0)
                    || (vacation.DateSpan.EndTime.CompareTo(v.StartTime) > 0 && vacation.DateSpan.EndTime.CompareTo(v.EndTime) < 0)
                    || (vacation.DateSpan.StartTime.CompareTo(v.StartTime) < 0 && vacation.DateSpan.EndTime.CompareTo(v.EndTime) > 0))
                {
                    return false;
                }
            }

            return true;
        }

        public bool AddVacation(Vacation vacation)
        {
            if (CheckVacationAvailability(vacation))
            {
                Vacations.Add(vacation);
                return true;
            }

            return false;
        }

        public bool RemoveVacation(Vacation vacation)
        {
            if (Vacations.Contains(vacation))
            {
                Vacations.Remove(vacation);
                return true;
            }

            return false;
        }

        public bool ChangeWorkDayShift(WorkDayShift workDayShift)
        {
            if (WorkDayShift.Equals(workDayShift))
            {
                return false;
            }

            WorkDayShift = workDayShift;
            return true;
        }

        public bool CheckOnCallShiftAvailability(OnCallShift onCallShift)
        {
            foreach (var v in OnCallShifts.Select(x => x.Date))
            {
                if (v.Date.CompareTo(onCallShift.Date.Date) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool AddOnCallShift(OnCallShift onCallShift)
        {
            if (CheckOnCallShiftAvailability(onCallShift))
            {
                OnCallShifts.Add(onCallShift);
                return true;
            }

            return false;
        }

        public bool RemoveOnCallShift(OnCallShift onCallShift)
        {
            if (OnCallShifts.Contains(onCallShift))
            {
                OnCallShifts.Remove(onCallShift);
                return true;
            }

            return false;
        }

        public bool CheckAppointmentAvailability(Appointment appointment)
        {
            foreach (var v in Appointments.Select(x => x.Date))
            {
                if ((appointment.Date.CompareTo(v) > 0 && appointment.Date.CompareTo(v.AddMinutes(30)) < 0)
                    || (appointment.Date.CompareTo(v) > 0 && appointment.Date.CompareTo(v.AddMinutes(30)) < 0)
                    || (appointment.Date.CompareTo(v) < 0 && appointment.Date.CompareTo(v.AddMinutes(30)) > 0))
                {
                    return false;
                }
            }

            return true;
        }

        public bool AddAppointment(Appointment appointment)
        {
            if (CheckAppointmentAvailability(appointment))
            {
                Appointments.Add(appointment);
                return true;
            }

            return false;
        }

        public bool RemoveAppointment(Appointment appointment)
        {
            if (Appointments.Contains(appointment))
            {
                Appointments.Remove(appointment);
                return true;
            }

            return false;
        }

    }
}
