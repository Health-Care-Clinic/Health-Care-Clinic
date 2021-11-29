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

        public AppointmentController(IAppointmentService _appointmentService)
        {
            this.appointmentService = _appointmentService;
        }

        [HttpGet("getAppointmetsByPatientId/{id?}")]
        public IActionResult getAppointmentsByPatientId(int patinetId)
        {
            //TODO PROVERA DA LI PACIJENT SA TI ID UOPSTE POSTOJI
            List<AppointmetDTO> allAppointments = new List<AppointmetDTO>();
            appointmentService.getAppointmentsByPatientId(patinetId).ForEach(Appointment
                => allAppointments.Add(AppointmentAdapter.AppointmentToAppointmentDTO(Appointment)));

            return Ok(allAppointments);
        }
    }

}