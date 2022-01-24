using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public interface IDoctorScheduleService : IService<DoctorSchedule>
    {
        public bool CheckVacationAvailability(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation);

        public bool AddVacation(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation);

        public bool RemoveVacation(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation);

        public bool ChangeWorkDayShift(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, WorkDayShift newWorkDayShift);

        public bool CheckOnCallShiftAvailability(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift);

        public bool AddOnCallShift(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift);

        public bool RemoveOnCallShift(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift);

        public bool CheckAppointmentAvailability(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment);

        public bool AddAppointment(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment);

        public bool RemoveAppointment(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment);
    }
}
