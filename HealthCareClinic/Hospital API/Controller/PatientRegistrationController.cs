using Hospital.Mapper;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRegistrationController : ControllerBase
    {
        private readonly IMailService _mailService;
        private IAllergenService _allergenService;
        private IDoctorService _doctorService;

        public PatientRegistrationController(IAllergenService allergenService, IDoctorService doctorService, IMailService mailService)
        {
            this._allergenService = allergenService;
            this._doctorService = doctorService;
            this._mailService = mailService;
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

            Patient newPatient = PatientAdapter.PatientDTOToPatient(patientDTO);
            //newPatient.HashCode = _patientService.ComputeSha256Hash(newPatient.Password);
            //_patientService.Add(newPatient);

            SendMail(newPatient.HashCode, newPatient.Name, newPatient.Email);

            return Ok();
        }

        public async Task<IActionResult> SendMail(string hash, string name, string email)
        {
            try
            {
                var confirmationLink = Url.Action("activate", "api", new { token = hash }, Request.Scheme);
                await _mailService.SendEmailAsync(new MailRequest(confirmationLink, name, email));                

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token)
        {
            //_patientService.SetToActiveAccount(token);

            return Redirect("http://localhost:4200/log-in");
        }
    }
}
