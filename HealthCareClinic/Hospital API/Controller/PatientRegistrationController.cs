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
    public class PatientRegistrationController : ControllerBase
    {
        private IAllergenService _allergenService;
        private IDoctorService _doctorService;

        public PatientRegistrationController(IAllergenService allergenService,IDoctorService doctorService)
        {
            this._allergenService = allergenService;
            this._doctorService = doctorService;
        }


        [HttpGet("getAllAvailableDoctors")]
        public IActionResult GetAvailableDoctors()
        {
            List<Doctor> doctors = (List<Doctor>)_doctorService.GetAvailableDoctors();
            List<DoctorDTO> result = DoctorAdapter.DoctorListToDoctorDTOList(doctors);
            return Ok(result);
        }

        [HttpGet("getAllAllergens")]       // GET /api/allergen
        public IActionResult GetAllAllergens()
        {
            List<Allergen> result = (List<Allergen>) _allergenService.GetAll();

            return Ok(result);
        }

        [HttpPost("submitPatientRegistrationRequest")]
        public IActionResult SubmitPatientRegistrationRequest(PatientDTO patientDTO)
        {
            if (patientDTO.Id < 0)
            {
                return BadRequest();
            }

            //Patient newPatient = PatientAdapter.PatientDTOToPatient(patientDTO);
            //patientService.Add(newPatient);

            return Ok();
        }
    }
}
