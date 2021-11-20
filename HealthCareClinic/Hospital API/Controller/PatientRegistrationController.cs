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
        private IPatientService _patientService;
        private IAllergenService _allergenService;
        private IDoctorService _doctorService;

        public PatientRegistrationController(IAllergenService allergenService,IDoctorService doctorService,IPatientService patientService)
        {
            this._allergenService = allergenService;
            this._doctorService = doctorService;
            this._patientService = patientService;
        }


        [HttpGet("getAllAvailableDoctors")]
        public IActionResult GetAvailableDoctors()
        {
            List<Doctor> doctors = (List<Doctor>)_doctorService.GetAvailableDoctors();
            List<DoctorDTO> result = DoctorAdapter.DoctorListToDoctorDTOList(doctors);
            return Ok(result);
        }

        [HttpGet("getAllAllergens")]       // GET /api/getAllAllergens
        public IActionResult GetAllAllergens()
        {
            List<Allergen> result = (List<Allergen>) _allergenService.GetAll();

            return Ok(AllergenAdapter.AllergenListToDtoList(result));
        }

        [HttpPost("submitPatientRegistrationRequest")]
        public IActionResult SubmitPatientRegistrationRequest(PatientDTO patientDTO)
        {

            Patient newPatient = PatientAdapter.PatientDTOToPatient(patientDTO);
            newPatient.Doctor = _doctorService.GetOneById(patientDTO.DoctorDTO.Id);
            _patientService.Add(newPatient);

            return Ok();
        }
        //[HttpGet("getAllPatients")]
        //public IActionResult GetAllPatients()
        //{
        //    List<Patient> result = (List<Patient>)_patientService.GetAll();

        //    return Ok(PatientAdapter.PatientsToPatientDTOs(result));
        //}
    }
}
