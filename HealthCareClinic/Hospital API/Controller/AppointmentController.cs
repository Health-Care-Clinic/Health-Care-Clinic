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
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<AppointmentDTOForMedicalRecord> allAppointments = new List<AppointmentDTOForMedicalRecord>();
            appointmentService.getAppointmentsByPatientId(id).ForEach(Appointment
                => allAppointments.Add(AppointmentAdapter.AppointmentToAppointmentDTOForMedicalRecord(Appointment, doctorService,surveyService)));

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
            if (appointment.isCancelled == true)
                return BadRequest("Already cancelled");

            Appointment Appointment =  appointmentService.CancelAppointment(id);
            return Ok(AppointmentAdapter.AppointmentToAppointmentDTOForMedicalRecord(Appointment, doctorService,surveyService));
        }

        [HttpPost("freeTermsForDoctor")]
        public IActionResult GetAvailableTermsForDoctor(DoctorIdDateFromDateToDTO dto)
        {
            DateTime fromDate = PatientAdapter.ConvertToDate(dto.From);
            DateTime toDate = PatientAdapter.ConvertToDate(dto.To);
            if (dto.DoctorId < 0)
                return BadRequest();
            if (toDate < fromDate)
                return BadRequest();

            List<string> availableTerms = new List<string>();
            foreach (DateTime term in appointmentService.GetAvailableTermsForDoctor(doctorService.GetOneById(dto.DoctorId), fromDate, toDate))
                availableTerms.Add(PatientAdapter.ConvertToString(term));

            return Ok(availableTerms);
        }

        [HttpPost("createAppointment")]
        public IActionResult CreateAppointment(AppointmentDTO appDto)
        {
            Appointment app = AppointmentAdapter.AppointmentDtoToAppointment(appDto);

            app.RoomId = doctorService.GetOneById(app.DoctorId).PrimaryRoom;

            appointmentService.AddAppointment(app);

            return Ok();
        }

        [HttpGet("getRoomAppointments/{id?}")]
        public IActionResult GetRoomAppointments(int id)
        {
            List<Appointment> roomAppointments = new List<Appointment>();
            appointmentService.GetRoomAppointments(id).ToList().ForEach(Appointment
                => roomAppointments.Add(Appointment));
            return Ok(roomAppointments);
        }
    }

}