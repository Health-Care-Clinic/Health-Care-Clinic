using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        private readonly IAppointmentService appointmentService;

        public DoctorController(IDoctorService _doctorService, IAppointmentService _appointmentService)
        {
            this.doctorService = _doctorService;
            this.appointmentService = _appointmentService;
        }


        [HttpGet("allDoctors")]
        public IActionResult GetAllDoctors()
        {
            List<Doctor> doctors = (List<Doctor>)doctorService.GetAll();
            List<DoctorWithSpecialtyDTO> doctorsDto = DoctorAdapter.DoctorListToDoctorWithSpecialtyDTOList(doctors);

            return Ok(doctorsDto);
        }

        [HttpGet("getNumOfAppointments/{id?}/{month?}/{year?}")]
        public IActionResult GetNumOfAppointments(int id, int month,int year)
        {
            return Ok(appointmentService.GetNumOfAppointments(id, month, year));
        }

        [HttpGet("getNumOfPatients/{id?}/{month?}/{year?}")]
        public IActionResult GetNumOfPatients(int id, int month, int year)
        {
            return Ok(appointmentService.GetNumOfPatients(id, month, year));
        }

        [HttpPost("addShiftToDoctor")]
        public IActionResult AddShiftToDoctor(DoctorDTO doctorDTO) 
        {
            Doctor doctor = DoctorAdapter.DoctorDTOToDoctor(doctorDTO);
            doctorService.addShiftToDoctor(doctor);
            return Ok();
        }

        [HttpGet("findById/{id?}")]
        public IActionResult FindById(int id)
        {
            return Ok(DoctorAdapter.DoctorToDoctorDTO(doctorService.findById(id)));
        }
    }
}
