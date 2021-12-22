using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Authorize(Roles = "patient")]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService _doctorService)
        {
            this.doctorService = _doctorService;
        }


        [HttpGet("allDoctors")]
        public IActionResult GetAllDoctors()
        {
            List<Doctor> doctors = (List<Doctor>)doctorService.GetAll();
            List<DoctorWithSpecialtyDTO> doctorsDto = DoctorAdapter.DoctorListToDoctorWithSpecialtyDTOList(doctors);

            return Ok(doctorsDto);
        }
    }
}
