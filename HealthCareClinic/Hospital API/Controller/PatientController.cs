using Hospital.Mapper;
using Hospital.Medical_records.Model;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Medical_records.Model;
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
        private IPrescriptionService prescriptionService;
        public PatientController(IAllergenService allergenService, IDoctorService doctorService,IPrescriptionService prescriptionService, IPatientService patientService)
        {
            this.allergenService = allergenService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.prescriptionService = prescriptionService;
        }

        [AllowAnonymous]
        [HttpGet("getAllAvailableDoctors")]
        public IActionResult GetAvailableDoctors()
        {
            List<Doctor> doctors = (List<Doctor>)doctorService.GetAvailableDoctors();
            List<DoctorDTO> result = DoctorAdapter.DoctorListToDoctorDTOList(doctors);
            return Ok(result);
        }

        [Authorize(Roles = "patient")]
        [HttpGet("getAllPrescriptionsForPatient/{id?}")]
        public IActionResult GetAllPrescriptionsForPatient(int id)
        {
            List<Prescription> prescriptions = (List<Prescription>)prescriptionService.GetAllPrescriptionsForPatient(patientService.GetOneById(id));
            List<PrescriptionPatientDTO> result = new List<PrescriptionPatientDTO>();
            prescriptions.ForEach(pres => {
                PrescriptionPatientDTO dto = PrescriptionAdapter.PrescriptionToPrescriptionPatientDTO(pres);
                dto.Doctor = DoctorAdapter.DoctorToDoctorDTO(doctorService.GetOneById(pres.Appointment.DoctorId));
                result.Add(dto);});
            return Ok(result);
        }

        [Authorize(Roles = "patient")]
        [HttpGet("getPatient/{id?}")]
        public IActionResult GetPatient(int id)
        {
            PatientDTO dto = PatientAdapter.PatientToPatientDTO(patientService.GetOneById(id));
            String picture = patientService.GetProfilePicture(dto.Id);

            return Ok(new PatientWithPictureDTO(dto, picture));
        }

        [AllowAnonymous]
        [HttpGet("getAllAllergens")]       // GET /api/getAllAllergens
        public IActionResult GetAllAllergens()
        {
            List<Allergen> result = (List<Allergen>)allergenService.GetAll();

            return Ok(AllergenAdapter.AllergenListToDtoList(result));
        }

        [AllowAnonymous]
        [HttpGet("getAllUsernames")]       // GET /api/getAllUsernames
        public IActionResult GetAllUsernames()
        {
            return Ok(patientService.GetAllUsernames());
        }

        [AllowAnonymous]
        [HttpPost("submitPatientRegistrationRequest")]
        public IActionResult SubmitPatientRegistrationRequest(PatientWithPictureDTO patientWithPictureDTO)
        {
            if (patientWithPictureDTO == null) return BadRequest();

            PatientDTO patientDTO = patientWithPictureDTO.Patient;

            if (PatientRegistrationValidation.IsIncomingPatientDtoValid(patientDTO))
            {
                Patient newPatient = PatientAdapter.PatientDTOToPatient(patientDTO);
                ProfilePicture profilePicture = new ProfilePicture(0, patientWithPictureDTO.ProfilePicture);

                newPatient.Doctor = doctorService.GetOneById(patientDTO.DoctorDTO.Id);
                newPatient.Hashcode = patientService.GenerateHashcode(newPatient.Password);

                patientService.Add(newPatient);
                profilePicture.PatientId = newPatient.Id;
                patientService.AddProfilePicture(profilePicture);

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

        [Authorize(Roles = "manager")]
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
