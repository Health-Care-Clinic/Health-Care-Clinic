using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Service;
using Hospital_API.Adapter;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_API.Controller {

    [Authorize(Roles = "manager")]
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

        [HttpGet("checkIfTransferCancellable/{id?}")]
        public IActionResult CheckIfTransferCancellable(int id)
        {
            bool isCancellable = transferService.CheckIfTransferCancellable(id);
            return Ok(isCancellable);
        }

        [HttpPost("cancelTransfer")]
        public IActionResult CancelTransfer(TransferDTO transferDTO)
        {
            Transfer transfer = TransferAdapter.TransferDTOToTransfer(transferDTO);
            transferService.RemoveById(transfer.Id);
            return Ok();
        }

        [HttpGet("getAllTransfers")]
        public IActionResult GetAllTransfers()
        {
            checkTransfers();
            List<TransferDTO> allTransfers = new List<TransferDTO>();
            transferService.GetAll().ToList().ForEach(Transfer
                => allTransfers.Add(TransferAdapter.TransferToTransferDTO(Transfer)));
            return Ok(allTransfers);
        }

        [HttpGet("getRoomTransfers/{id?}")]
        public IActionResult GetRoomTransfers(int id)
        {
            checkTransfers();
            List<TransferDTO> roomTransfers = new List<TransferDTO>();
            transferService.GetRoomTransfers(id).ToList().ForEach(Transfer
                => roomTransfers.Add(TransferAdapter.TransferToTransferDTO(Transfer)));
            return Ok(roomTransfers);
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

        private void checkTransfers() {
            DateTime today = DateTime.Now;
            List<TransferDTO> allTransfers = new List<TransferDTO>();
            transferService.GetAll().ToList().ForEach(Transfer
                => allTransfers.Add(TransferAdapter.TransferToTransferDTO(Transfer)));
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
