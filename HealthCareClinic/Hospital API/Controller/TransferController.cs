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

        private void checkTransfers(List<TransferDTO> allTransfers) {
            DateTime today = DateTime.Now;

            foreach (TransferDTO transfer in allTransfers) {
                DateTime dateFromBase = createDate(transfer.Date);

                if (DateTime.Compare(dateFromBase, today) < 0) 
                {
                    equipmentService.Change(transfer.Equipment, transfer.SourceRoomId, transfer.DestinationRoomId, transfer.Quantity);
                    Transfer entity = TransferAdapter.TransferDTOToTransfer(transfer);
                    transferService.RemoveById(entity.Id);
                }
            }
        }

        private DateTime createDate(String date) {
            int day = Convert.ToInt32(date.Split(' ')[0].Split('.')[0]);
            int month = Convert.ToInt32(date.Split(' ')[0].Split('.')[1]);
            int year = Convert.ToInt32(date.Split(' ')[0].Split('.')[2]);
            int hours = Convert.ToInt32(date.Split(' ')[1].Split(':')[0]);
            int minutes = Convert.ToInt32(date.Split(' ')[1].Split(':')[1]);

            return new DateTime(year, month, day, hours, minutes, 0);
        }

    }

}
