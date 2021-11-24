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
        private IPatientService patientService;
        private IAllergenService allergenService;
        private IDoctorService doctorService;

        public PatientRegistrationController(IAllergenService allergenService,IDoctorService doctorService,IPatientService patientService)
        {
            this.allergenService = allergenService;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }


        [HttpGet("getAllAvailableDoctors")]
        public IActionResult GetAvailableDoctors()
        {
            List<Doctor> doctors = (List<Doctor>)doctorService.GetAvailableDoctors();
            List<DoctorDTO> result = DoctorAdapter.DoctorListToDoctorDTOList(doctors);
            return Ok(result);
        }


        [HttpGet("getAllAllergens")]       // GET /api/getAllAllergens
        public IActionResult GetAllAllergens()
        {
            List<Allergen> result = (List<Allergen>)allergenService.GetAll();

            return Ok(AllergenAdapter.AllergenListToDtoList(result));
        }

        [HttpGet("getAllUsernames")]       // GET /api/getAllUsernames
        public IActionResult GetAllUsernames()
        {
            return Ok(patientService.GetAllUsernames());
        }

        [HttpPost("submitPatientRegistrationRequest")]
        public IActionResult SubmitPatientRegistrationRequest(PatientDTO patientDTO)
        {
            Patient newPatient = PatientAdapter.PatientDTOToPatient(patientDTO);            
            newPatient.Doctor = doctorService.GetOneById(patientDTO.DoctorDTO.Id);

            newPatient.Hashcode = patientService.GenerateHashcode(newPatient.Password);

            patientService.Add(newPatient);

            //var confirmationLink = Url.Action("activate", "api", new { token = newPatient.Hashcode }, Request.Scheme);
            var confirmationLink = "http://localhost:4200/api/patientRegistration/activate?token=" + newPatient.Hashcode;
            patientService.SendMail(new MailRequest(confirmationLink, newPatient.Name, newPatient.Email));           

            return Ok();
        }

        [HttpGet("activate")]
        public IActionResult ActivatePatientsAccount([FromQuery] string token)
        {
            Patient patient = patientService.FindByToken(token);

            if (patient == null || patient.IsActive)
            {
                return NotFound();
            }
            patientService.ActivatePatientsAccount(patient);

            return Redirect("http://localhost:4200/login");
        }

        //[HttpGet("getAllPatients")]
        //public IActionResult GetAllPatients()
        //{
        //    List<Patient> result = (List<Patient>)_patientService.GetAll();

        //    return Ok(PatientAdapter.PatientsToPatientDTOs(result));
        //}
    }
}
