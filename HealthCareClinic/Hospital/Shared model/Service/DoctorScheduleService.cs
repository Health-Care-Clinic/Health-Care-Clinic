using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;

        public DoctorScheduleService(IDoctorScheduleRepository doctorScheduleRepository)
        {
            _doctorScheduleRepository = doctorScheduleRepository;
        }

        public void Add(DoctorSchedule entity)
        {
            _doctorScheduleRepository.Add(entity);
        }

        public IEnumerable<DoctorSchedule> GetAll()
        {
            return _doctorScheduleRepository.GetAll();
        }

        public DoctorSchedule GetOneById(int id)
        {
            return _doctorScheduleRepository.GetById(id);
        }

        public void Remove(DoctorSchedule entity)
        {
            _doctorScheduleRepository.Remove(entity);
        }

        public bool CheckVacationAvailability(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            return schedule.CheckVacationAvailability(vacation);
        }

        public bool AddVacation(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            if (schedule.AddVacation(vacation))
            {
                _doctorScheduleRepository.Add(schedule);
                return true;
            }

            return false;
        }

        public bool RemoveVacation(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Vacation vacation)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            if (schedule.RemoveVacation(vacation))
            {
                _doctorScheduleRepository.Remove(schedule);
                return true;
            }

            return false;
        }

        public bool ChangeWorkDayShift(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, WorkDayShift newWorkDayShift)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            return schedule.ChangeWorkDayShift(newWorkDayShift);
        }

        public bool CheckOnCallShiftAvailability(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            return schedule.CheckOnCallShiftAvailability(onCallShift);
        }

        public bool AddOnCallShift(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            if (schedule.AddOnCallShift(onCallShift))
            {
                _doctorScheduleRepository.Add(schedule);
                return true;
            }

            return false;
        }

        public bool RemoveOnCallShift(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, OnCallShift onCallShift)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            if (schedule.RemoveOnCallShift(onCallShift))
            {
                _doctorScheduleRepository.Remove(schedule);
                return true;
            }

            return false;
        }

        public bool CheckAppointmentAvailability(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            return schedule.CheckAppointmentAvailability(appointment);
        }

        public bool AddAppointment(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            if (schedule.AddAppointment(appointment))
            {
                _doctorScheduleRepository.Add(schedule);
                return true;
            }

            return false;
        }

        public bool RemoveAppointment(Doctor doctor, WorkDayShift workDayShift, List<Vacation> vacations, List<OnCallShift> onCallShifts, List<Appointment> appointments, Appointment appointment)
        {
            DoctorSchedule schedule = new DoctorSchedule(doctor, workDayShift, vacations, onCallShifts, appointments);
            if (schedule.RemoveAppointment(appointment))
            {
                _doctorScheduleRepository.Remove(schedule);
                return true;
            }

            return false;
        }
    }
}
