using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_API.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class RenovationController: ControllerBase
    {
        private readonly IRenovationService renovationService;

        public RenovationController(IRenovationService renovationService)
        {
            this.renovationService = renovationService;
        }

        [HttpPost("getFreeTermsForMerge")]
        public IActionResult getFreeTermsForMerge(RenovationDTO renovationDTO)
        {
            Renovation renovation = RenovationAdapter.RenovationDTOToRenovation(renovationDTO);
            return Ok(renovationService.getFreeTermsForMerge(renovation));
        }

        [HttpPost("getFreeTermsForDivide")]
        public IActionResult getFreeTermsForDivide(RenovationDTO renovationDTO)
        {
            Renovation renovation = RenovationAdapter.RenovationDTOToRenovation(renovationDTO);
            return Ok(renovationService.getFreeTermsForDivide(renovation));
        }

        [HttpGet("checkIfRenovationCancellable/{id?}")]
        public IActionResult CheckIfRenovationCancellable(int id)
        {
            bool isCancellable = renovationService.CheckIfRenovationCancellable(id);
            return Ok(isCancellable);
        }

        [HttpPost("cancelRenovation")]
        public IActionResult CancelRenovation(RenovationDTO renovationDTO)
        {
            Renovation renovation = RenovationAdapter.RenovationDTOToRenovation(renovationDTO);
            renovationService.RemoveById(renovation.Id);
            return Ok();
        }

        [HttpGet("getRoomRenovations/{id?}")]
        public IActionResult GetRoomRenovations(int id)
        {
            List<RenovationDTO> roomRenovations = new List<RenovationDTO>();
            renovationService.GetRoomRenovations(id).ToList().ForEach(Renovation
                => roomRenovations.Add(RenovationAdapter.RenovationToRenovationDTO(Renovation)));
            return Ok(roomRenovations);
        }
    }
}
