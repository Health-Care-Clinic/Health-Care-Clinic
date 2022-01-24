using Hospital.Mapper;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Hospital_API.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService patientService;
        private IAllergenService allergenService;
        private IDoctorService doctorService;

        public PatientController(IAllergenService allergenService, IDoctorService doctorService, IPatientService patientService)
        {
            this.allergenService = allergenService;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }

        [Authorize(Roles = "patient")]
        [HttpGet("getAllAvailableDoctors")]
        public IActionResult GetAvailableDoctors()
        {
            List<Doctor> doctors = (List<Doctor>)doctorService.GetAvailableDoctors();
            List<DoctorDTO> result = DoctorAdapter.DoctorListToDoctorDTOList(doctors);
            return Ok(result);
        }

        [Authorize(Roles = "patient")]
        [HttpGet("getPatient/{id?}")]
        public IActionResult GetPatient(int id)
        {
            return Ok(PatientAdapter.PatientToPatientDTO(patientService.GetOneById(id)));
        }

        [Authorize(Roles = "patient")]
        [HttpGet("getAllAllergens")]       // GET /api/getAllAllergens
        public IActionResult GetAllAllergens()
        {
            List<Allergen> result = (List<Allergen>)allergenService.GetAll();

            return Ok(AllergenAdapter.AllergenListToDtoList(result));
        }

        [Authorize(Roles = "patient")]
        [HttpGet("getAllUsernames")]       // GET /api/getAllUsernames
        public IActionResult GetAllUsernames()
        {
            return Ok(patientService.GetAllUsernames());
        }

        [Authorize(Roles = "patient")]
        [HttpPost("submitPatientRegistrationRequest")]
        public IActionResult SubmitPatientRegistrationRequest(PatientDTO patientDTO)
        {
            if (PatientRegistrationValidation.IsIncomingPatientDtoValid(patientDTO))
            {
                Patient newPatient = PatientAdapter.PatientDTOToPatient(patientDTO);
                newPatient.Doctor = doctorService.GetOneById(patientDTO.DoctorDTO.Id);

                newPatient.Hashcode = patientService.GenerateHashcode(newPatient.AccountInfo.Password);

                patientService.Add(newPatient);

                var confirmationLink = "http://localhost:4200/api/patient/activate?token=" + newPatient.Hashcode;
                patientService.SendMail(new MailRequest(confirmationLink, 
                    newPatient.MedicalRecord.PersonalInfo.Name, newPatient.ContactInfo.Email));

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("activate")]
        public IActionResult ActivatePatientsAccount([FromQuery] string token)
        {
            Patient patient = patientService.FindByToken(token);

            if (patient == null || patient.AccountInfo.IsActive)
            {
                return NotFound();
            }
            patientService.ActivatePatientsAccount(patient);

            return Redirect("http://localhost:4200/login");
        }

        [Authorize(Roles = "manager")]
        [HttpPut("{id?}")]
        public IActionResult BlockPatientById(int id)
        {
            Patient patient = patientService.GetOneById(id);
            if (patient == null || patient.AccountInfo.IsBlocked)
            {
                return NotFound();
            }
            else
            {
                patientService.BlockPatientById(id);
                return Ok(PatientAdapter.PatientToPatientDTO(patient));
            }
        }

        [Authorize(Roles = "manager")]
        [HttpGet("allSuspiciousPatients")]
        public IActionResult GetAllSuspiciousPatients()
        {
            List<Patient> patients = patientService.GetAllSuspiciousPatients();

            List<PatientDTO> patientsDto = new List<PatientDTO>();
            foreach (Patient patient in patients)
                patientsDto.Add(PatientAdapter.PatientToPatientDTO(patient));

            return Ok(patientsDto);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserCredentials credentials)
        {
            Patient patient = patientService.FindByUsernameAndPassword(credentials.Username, credentials.Password);
            if (patient != null)
            {
                string token = patientService.GenerateJwtToken(patient);
                return Ok(token);
            }
            else
                return Unauthorized();
        }
    }
}
