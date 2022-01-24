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

        [HttpPost("checkVacationAvailabilityDoctorSchedule")]
        public IActionResult CheckVacationAvailability(DoctorSchedule doctorSchedule)
        {
            bool available = doctorScheduleService.CheckVacationAvailability(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new Vacation());
            return Ok(available);
        }

        [HttpPost("addVacationDoctorSchedule")]
        public IActionResult AddVacation(DoctorSchedule doctorSchedule)
        {
            bool canAdd = doctorScheduleService.AddVacation(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new Vacation());
            return Ok(canAdd);
        }

        [HttpPost("removeVacationDoctorSchedule")]
        public IActionResult RemoveVacation(DoctorSchedule doctorSchedule)
        {
            bool canRemove = doctorScheduleService.RemoveVacation(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new Vacation());
            return Ok(canRemove);
        }

        [HttpPost("checkOnCallShiftAvailabilityDoctorSchedule")]
        public IActionResult CheckOnCallShiftAvailability(DoctorSchedule doctorSchedule)
        {
            bool available = doctorScheduleService.CheckOnCallShiftAvailability(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new OnCallShift());
            return Ok(available);
        }

        [HttpPost("addOnCallShiftDoctorSchedule")]
        public IActionResult AddOnCallShift(DoctorSchedule doctorSchedule)
        {
            bool canAdd = doctorScheduleService.AddOnCallShift(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new OnCallShift());
            return Ok(canAdd);
        }

        [HttpPost("removeOnCallShiftDoctorSchedule")]
        public IActionResult RemoveOnCallShift(DoctorSchedule doctorSchedule)
        {
            bool canRemove = doctorScheduleService.RemoveOnCallShift(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new OnCallShift());
            return Ok(canRemove);
        }

        [HttpPost("checkAppointmentAvailabilityDoctorSchedule")]
        public IActionResult CheckAppointmentAvailability(DoctorSchedule doctorSchedule)
        {
            bool available = doctorScheduleService.CheckAppointmentAvailability(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new Appointment());
            return Ok(available);
        }

        [HttpPost("addAppointmentDoctorSchedule")]
        public IActionResult AddAppointment(DoctorSchedule doctorSchedule)
        {
            bool canAdd = doctorScheduleService.AddAppointment(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new Appointment());
            return Ok(canAdd);
        }

        [HttpPost("removeAppointmentDoctorSchedule")]
        public IActionResult RemoveAppointment(DoctorSchedule doctorSchedule)
        {
            bool canRemove = doctorScheduleService.RemoveAppointment(doctorSchedule.Id, doctorSchedule.Doctor, doctorSchedule.WorkDayShift, doctorSchedule.Vacations, doctorSchedule.OnCallShifts, doctorSchedule.Appointments, new Appointment());
            return Ok(canRemove);
        }
    }
}
