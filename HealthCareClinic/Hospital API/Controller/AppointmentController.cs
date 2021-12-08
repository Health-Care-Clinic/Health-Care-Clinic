using Hospital.Mapper;
using Hospital.Medical_records.Service;
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
        private readonly IDoctorService doctorService;

        public AppointmentController(IAppointmentService _appointmentService)
        {
            this.appointmentService = _appointmentService;
        }
        public AppointmentController(IAppointmentService _appointmentService, IDoctorService _doctorService)
        {
            this.appointmentService = _appointmentService;
            this.doctorService = _doctorService;
        }

        [HttpGet("getAppointmetsByPatientId/{id?}")]
        public IActionResult GetAppointmentsByPatientId(int patinetId)
        {
            if (patinetId < 0)
                return BadRequest();
            //TODO PROVERA DA LI PACIJENT SA TI ID UOPSTE POSTOJI
            List<AppointmentDTO> allAppointments = new List<AppointmentDTO>();
            appointmentService.getAppointmentsByPatientId(patinetId).ForEach(Appointment
                => allAppointments.Add(AppointmentAdapter.AppointmentToAppointmentDTO(Appointment)));

            return Ok(allAppointments);
        }
        
        [HttpGet("cancelAppointment/{id?}")]
        public IActionResult CancelAppointment(int appointmentId)
        {
            if (appointmentId < 0)
                return BadRequest();   
            
            if (appointmentService.GetOneById(appointmentId) == null)
                return NotFound();

            Appointment Appointment =  appointmentService.CancelAppointment(appointmentId);
            return Ok(AppointmentAdapter.AppointmentToAppointmentDTO(Appointment));
        }

        [HttpPost("freeTermsForDoctor")]
        public IActionResult GetAvailableTermsForDoctor(int doctorId, string from, string to)
        {
            DateTime fromDate = PatientAdapter.ConvertToDate(from);
            DateTime toDate = PatientAdapter.ConvertToDate(to);
            if (doctorId < 0)
                return BadRequest();
            if (toDate < fromDate)
                return BadRequest();

            List<string> availableTerms = new List<string>();
            foreach (DateTime term in appointmentService.GetAvailableTermsForDoctor(doctorService.GetOneById(doctorId), fromDate, toDate))
                availableTerms.Add(PatientAdapter.ConvertToString(term));

            return Ok(availableTerms);
        }

        [HttpPost("createAppointment")]
        public IActionResult CreateAppointment(AppointmentDTO appDto)
        {
            Appointment app = AppointmentAdapter.AppointmentDtoToAppointment(appDto);

            appointmentService.AddAppointment(app);

            return Ok();
        }
    }

}