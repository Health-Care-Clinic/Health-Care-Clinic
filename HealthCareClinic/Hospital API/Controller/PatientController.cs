using Hospital.Mapper;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Hospital_API.Validation;
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

        [HttpGet("getAllAvailableDoctors")]
        public IActionResult GetAvailableDoctors()
        {
            List<Doctor> doctors = (List<Doctor>)doctorService.GetAvailableDoctors();
            List<DoctorDTO> result = DoctorAdapter.DoctorListToDoctorDTOList(doctors);
            return Ok(result);
        }

        [HttpGet("getPatient/{id?}")]
        public IActionResult GetPatient(int id)
        {
            return Ok(PatientAdapter.PatientToPatientDTO(patientService.GetOneById(id)));
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
            if (PatientRegistrationValidation.IsIncomingPatientDtoValid(patientDTO))
            {
                Patient newPatient = PatientAdapter.PatientDTOToPatient(patientDTO);
                newPatient.Doctor = doctorService.GetOneById(patientDTO.DoctorDTO.Id);

                newPatient.Hashcode = patientService.GenerateHashcode(newPatient.Password);

                patientService.Add(newPatient);

                var confirmationLink = "http://localhost:4200/api/patient/activate?token=" + newPatient.Hashcode;
                patientService.SendMail(new MailRequest(confirmationLink, newPatient.Name, newPatient.Email));

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

            if (patient == null || patient.IsActive)
            {
                return NotFound();
            }
            patientService.ActivatePatientsAccount(patient);

            return Redirect("http://localhost:4200/login");
        }

        [HttpPut("{id?}")]
        public IActionResult BlockPatientById(int id)
        {
            Patient patient = patientService.GetOneById(id);
            if (patient == null || patient.IsBlocked)
            {
                return NotFound();
            }
            else
            {
                patientService.BlockPatientById(id);
                return Ok(PatientAdapter.PatientToPatientDTO(patient));
            }
        }

        [HttpGet("allSuspiciousPatients")]
        public IActionResult GetAllSuspiciousPatients()
        {
            List<Patient> patients = patientService.GetAllSuspiciousPatients();

            List<PatientDTO> patientsDto = new List<PatientDTO>();
            foreach (Patient patient in patients)
                patientsDto.Add(PatientAdapter.PatientToPatientDTO(patient));

            return Ok(patientsDto);
        }
    }
}
