using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static Hospital.Rooms_and_equipment.Model.Renovation;

namespace Hospital_API.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class RenovationController: ControllerBase
    {
        private readonly IRenovationService renovationService;
        private readonly IEquipmentService equipmentService;
        private readonly IRoomService roomService;

        public RenovationController(IRenovationService renovationService, IEquipmentService equipmentService, IRoomService roomService)
        {
            this.renovationService = renovationService;
            this.equipmentService = equipmentService;
            this.roomService = roomService;
        }

        [HttpGet("getAllRenovations")]
        public IActionResult GetAllRenovations()
        {
            CheckRenovations();
            List<RenovationDTO> allRenovations = new List<RenovationDTO>();
            renovationService.GetAll().ToList().ForEach(Renovation
                => allRenovations.Add(RenovationAdapter.RenovationToRenovationDTO(Renovation)));
            return Ok(allRenovations);
        }

        private void CheckRenovations()
        {
            DateTime today = DateTime.Now;
            List<RenovationDTO> allRenovations = new List<RenovationDTO>();
            renovationService.GetAll().ToList().ForEach(Renovation
                => allRenovations.Add(RenovationAdapter.RenovationToRenovationDTO(Renovation)));
            foreach (RenovationDTO renovation in allRenovations)
            {
                DateTime renovationEndDate = renovation.Date.AddDays(renovation.Duration);

                if (DateTime.Compare(renovationEndDate, today) < 0)
                {
                    if (renovation.Type.Equals(RenovationType.Merge))
                    {
                        equipmentService.TransferEquipmentAfterReservation(renovation.FirstRoomId, renovation.SecondRoomId);
                        roomService.ChangeRoomDimensions(renovation.FirstRoomId, renovation.SecondRoomId);
                        roomService.RemoveById(renovation.SecondRoomId);
                    }
                    renovationService.RemoveById(renovation.Id);
                }
            }
        }

        [HttpPost("addNewRenovation")]
        public IActionResult AddNewRenovation(RenovationDTO renovationDTO)
        {
            Renovation renovation = RenovationAdapter.RenovationDTOToRenovation(renovationDTO);
            renovationService.Add(renovation);
            return Ok();
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
