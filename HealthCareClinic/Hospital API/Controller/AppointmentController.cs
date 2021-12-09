using Hospital.Mapper;
using Hospital.Medical_records.Service;
using Hospital.Schedule.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService appointmentService;
        private ISurveyService surveyService;
        private IDoctorService doctorService;

        public AppointmentController(IAppointmentService _appointmentService, ISurveyService _surveyService, IDoctorService _doctorService)
        {
            this.appointmentService = _appointmentService;
            this.doctorService = _doctorService;
            this.surveyService = _surveyService;
        }

        [HttpGet("getAppointmentsByPatientId/{id?}")]
        public IActionResult GetAppointmentsByPatientId(int id)
        {
            if (id < 0)
                return BadRequest();
            //TODO PROVERA DA LI PACIJENT SA TI ID UOPSTE POSTOJI
            List<AppointmentDTO> allAppointments = new List<AppointmentDTO>();
            appointmentService.getAppointmentsByPatientId(id).ForEach(Appointment
                => allAppointments.Add(AppointmentAdapter.AppointmentToAppointmentDTO(Appointment, doctorService,surveyService)));

            return Ok(allAppointments);
        }
        
        [HttpPut("cancelAppointment/{id?}")]
        public IActionResult CancelAppointment(int id)
        {
            if (id < 0)
                return BadRequest();
            Appointment appointment = appointmentService.GetOneById(id);
            if (appointment == null)
                return NotFound();
            if (DateTime.Now > appointment.Date.AddDays(-2))
                return BadRequest("Too late to cancel");

            Appointment Appointment =  appointmentService.CancelAppointment(id);
            return Ok(AppointmentAdapter.AppointmentToAppointmentDTO(Appointment, doctorService,surveyService));
        }
    }

}