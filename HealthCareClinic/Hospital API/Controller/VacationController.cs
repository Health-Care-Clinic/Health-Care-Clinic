using Hospital.Shared_model.Model;
using Hospital.Shared_model.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService vacationService;
        public VacationController(IVacationService vacationService)
        {
            this.vacationService = vacationService;
        }

        [HttpGet("getAllVacations")]
        public IActionResult GetAllVacations()
        {
            List<VacationDTO> allVacations = new List<VacationDTO>();
            vacationService.GetAll().ToList().ForEach(Vacation
                => allVacations.Add(VacationAdapter.VacationToVacationDTO(Vacation)));
            return Ok(allVacations);
        }

        [HttpGet("getVacationsByDoctorId/{id?}")]
        public IActionResult GetVacationsByDoctorId(int id)
        {
            List<VacationDTO> allVacations = new List<VacationDTO>();
            vacationService.GetVacationsByDoctorId(id).ForEach(Vacation
                => allVacations.Add(VacationAdapter.VacationToVacationDTO(Vacation)));
            return Ok(allVacations);
        }

        [HttpGet("getPastVacationsByDoctorId/{id?}")]
        public IActionResult GetPastVacationsByDoctorId(int id)
        {
            List<VacationDTO> allVacations = new List<VacationDTO>();
            vacationService.GetPastVacationsByDoctorId(id).ForEach(Vacation
                => allVacations.Add(VacationAdapter.VacationToVacationDTO(Vacation)));
            return Ok(allVacations);
        }

        [HttpGet("getCurrentVacationsByDoctorId/{id?}")]
        public IActionResult GetCurrentVacationsByDoctorId(int id)
        {
            List<VacationDTO> allVacations = new List<VacationDTO>();
            vacationService.GetCurrentVacationsByDoctorId(id).ForEach(Vacation
                => allVacations.Add(VacationAdapter.VacationToVacationDTO(Vacation)));
            return Ok(allVacations);
        }

        [HttpGet("getFutureVacationsByDoctorId/{id?}")]
        public IActionResult GetFutureVacationsByDoctorId(int id)
        {
            List<VacationDTO> allVacations = new List<VacationDTO>();
            vacationService.GetFutureVacationsByDoctorId(id).ForEach(Vacation
                => allVacations.Add(VacationAdapter.VacationToVacationDTO(Vacation)));
            return Ok(allVacations);
        }

        [HttpPost("addNewVacation")]
        public IActionResult AddNewVacation(VacationDTO vacationDTO)
        {
            Vacation vacation = VacationAdapter.VacationDTOToVacation(vacationDTO);
            vacationService.Add(vacation);
            return Ok();
        }

        [HttpPut("changeVacation")]
        public IActionResult ChangeVacation(VacationDTO vacationDTO)
        {
            Vacation vacation = VacationAdapter.VacationDTOToVacation(vacationDTO);
            vacationService.Change(vacation);
            return Ok();
        }

        [HttpPost("deleteVacation")]
        public IActionResult DeleteVacation(VacationDTO vacationDTO)
        {
            Vacation vacation = VacationAdapter.VacationDTOToVacation(vacationDTO);
            vacationService.RemoveById(vacation.Id);
            return Ok();
        }

        [HttpPost("getVacationAvailability")]
        public IActionResult GetVacationAvailability(VacationDTO vacationDTO)
        {
            Vacation vacation = VacationAdapter.VacationDTOToVacation(vacationDTO);
            bool available = vacationService.GetVacationAvailability(vacation.DoctorId, vacation.StartTime, vacation.EndTime);
            return Ok(available);
        }


    }
}
