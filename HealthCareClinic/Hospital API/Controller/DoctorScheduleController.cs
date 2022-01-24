using Hospital.Shared_model.Model;
using Hospital.Shared_model.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleService doctorScheduleService;
        public DoctorScheduleController(IDoctorScheduleService doctorScheduleService)
        {
            this.doctorScheduleService = doctorScheduleService;
        }

        [HttpGet("getAllDoctorSchedules")]
        public IActionResult GetAllDoctorSchedules()
        {
            List<DoctorSchedule> allDoctorSchedules = new List<DoctorSchedule>();
            doctorScheduleService.GetAll().ToList().ForEach(DoctorSchedule
                => allDoctorSchedules.Add(DoctorSchedule));

            return Ok(allDoctorSchedules);
        }

        [HttpGet("checkVacationAvailabilityDoctorSchedule")]
        public IActionResult CheckVacationAvailability(DoctorSchedule doctorSchedule, Vacation vacation)
        {
            bool available = doctorScheduleService.CheckVacationAvailability(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, vacation);
            return Ok(available);
        }

        [HttpGet("addVacationDoctorSchedule")]
        public IActionResult AddVacation(DoctorSchedule doctorSchedule, Vacation vacation)
        {
            bool canAdd = doctorScheduleService.AddVacation(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, vacation);
            return Ok(canAdd);
        }

        [HttpGet("removeVacationDoctorSchedule")]
        public IActionResult RemoveVacation(DoctorSchedule doctorSchedule, Vacation vacation)
        {
            bool canRemove = doctorScheduleService.RemoveVacation(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, vacation);
            return Ok(canRemove);
        }

        [HttpGet("checkOnCallShiftAvailabilityDoctorSchedule")]
        public IActionResult CheckOnCallShiftAvailability(DoctorSchedule doctorSchedule, OnCallShift onCallShift)
        {
            bool available = doctorScheduleService.CheckOnCallShiftAvailability(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, onCallShift);
            return Ok(available);
        }

        [HttpGet("addOnCallShiftDoctorSchedule")]
        public IActionResult AddOnCallShift(DoctorSchedule doctorSchedule, OnCallShift onCallShift)
        {
            bool canAdd = doctorScheduleService.AddOnCallShift(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, onCallShift);
            return Ok(canAdd);
        }

        [HttpGet("removeOnCallShiftDoctorSchedule")]
        public IActionResult RemoveOnCallShift(DoctorSchedule doctorSchedule, OnCallShift onCallShift)
        {
            bool canRemove = doctorScheduleService.RemoveOnCallShift(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, onCallShift);
            return Ok(canRemove);
        }

        [HttpGet("checkAppointmentAvailabilityDoctorSchedule")]
        public IActionResult CheckAppointmentAvailability(DoctorSchedule doctorSchedule, Appointment appointment)
        {
            bool available = doctorScheduleService.CheckAppointmentAvailability(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, appointment);
            return Ok(available);
        }

        [HttpGet("addAppointmentDoctorSchedule")]
        public IActionResult AddAppointment(DoctorSchedule doctorSchedule, Appointment appointment)
        {
            bool canAdd = doctorScheduleService.AddAppointment(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, appointment);
            return Ok(canAdd);
        }

        [HttpGet("removeAppointmentDoctorSchedule")]
        public IActionResult RemoveAppointment(DoctorSchedule doctorSchedule, Appointment appointment)
        {
            bool canRemove = doctorScheduleService.RemoveAppointment(doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, appointment);
            return Ok(canRemove);
        }
    }
}
