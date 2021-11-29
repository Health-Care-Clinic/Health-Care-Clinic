using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_API.Controller {

    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase 
    {
        private readonly ITransferService transferService;
        private readonly IEquipmentService equipmentService;

        public TransferController(ITransferService transferService, IEquipmentService equipmentService)
        {
            this.transferService = transferService;
            this.equipmentService = equipmentService;
        }

        [HttpGet("getAllTransfers")]
        public IActionResult GetAllTransfers()
        {
            List<TransferDTO> allTransfers = new List<TransferDTO>();
            transferService.GetAll().ToList().ForEach(Transfer
                => allTransfers.Add(TransferAdapter.TransferToTransferDTO(Transfer)));
            checkTransfers(allTransfers);
            return Ok(allTransfers);
        }

        [HttpPost("addNewTransfer")]
        public IActionResult AddNewTransfer(TransferDTO transferDTO) 
        {
            Transfer transfer = TransferAdapter.TransferDTOToTransfer(transferDTO);
            transferService.Add(transfer);
            return Ok();
        }

        [HttpPost("checkFreeTransfers")]
        public IActionResult checkFreeTransfers(TransferDTO transferDTO)
        {
            Transfer transfer = TransferAdapter.TransferDTOToTransfer(transferDTO);
            return Ok(transferService.checkFreeTransfers(transfer));
        }

        private void checkTransfers(List<TransferDTO> allTransfers) {
            DateTime today = DateTime.Now;

            foreach (TransferDTO transfer in allTransfers) {
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
