using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
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
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService equipmentService;
        private readonly ITransferService transferService;
        public EquipmentController(IEquipmentService equipmentService, ITransferService transferService)
        {
            this.equipmentService = equipmentService;
            this.transferService = transferService;
        }

        [HttpGet("getAllEquipment")]
        public IActionResult GetAllEquipment()
        {
            List<EquipmentDTO> allEquipment = new List<EquipmentDTO>();
            equipmentService.GetAll().ToList().ForEach(Equipment
                => allEquipment.Add(EquipmentAdapter.EquipmentToEquipmentDTO(Equipment)));
            checkTransfers();
            return Ok(allEquipment);
        }

        [HttpGet("getEquipmentByRoomId/{id?}")]
        public IActionResult GetEquipmentByRoomId(int id)
        {
            List<EquipmentDTO> allEquipment = new List<EquipmentDTO>();
            equipmentService.GetEquipmentByRoomId(id).ForEach(Equipment
                => allEquipment.Add(EquipmentAdapter.EquipmentToEquipmentDTO(Equipment)));
            checkTransfers();
            return Ok(allEquipment);
        }

        [HttpGet("getEquipmentByName/{name?}")]
        public IActionResult GetEquipmentByName(string name)
        {
            List<EquipmentDTO> allEquipment = new List<EquipmentDTO>();
            equipmentService.GetEquipmentByName(name).ForEach(Equipment
                => allEquipment.Add(EquipmentAdapter.EquipmentToEquipmentDTO(Equipment)));
            checkTransfers();
            return Ok(allEquipment);
        }

        private void checkTransfers()
        {
            DateTime today = DateTime.Now;
            List<TransferDTO> allTransfers = new List<TransferDTO>();
            transferService.GetAll().ToList().ForEach(Transfer
                => allTransfers.Add(TransferAdapter.TransferToTransferDTO(Transfer)));
            foreach (TransferDTO transfer in allTransfers)
            {
                DateTime dateFromBase = transfer.Date;

                if (DateTime.Compare(dateFromBase, today) < 0)
                {
                    equipmentService.Change(transfer.Equipment, transfer.SourceRoomId, transfer.DestinationRoomId, transfer.Quantity);
                    Transfer entity = TransferAdapter.TransferDTOToTransfer(transfer);
                    transferService.RemoveById(entity.Id);
                }
            }
        }
    }

}
