using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public interface IDoctorScheduleService : IService<DoctorSchedule>
    {
        public bool CheckVacationAvailability(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation);

        public bool AddVacation(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation);

        public bool RemoveVacation(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation);

        public bool ChangeWorkDayShift(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, WorkDayShift newWorkDayShift);

        public bool CheckOnCallShiftAvailability(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift);

        public bool AddOnCallShift(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift);

        public bool RemoveOnCallShift(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift);

        public bool CheckAppointmentAvailability(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment);

        public bool AddAppointment(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment);

        public bool RemoveAppointment(int id, Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment);
    }
}
