

using Hospital.Rooms_and_equipment.Model;
using Hospital_API.DTO;
using System;

namespace Hospital_API.Adapter
{
    public class TransferAdapter
    {

        public static Transfer TransferDTOToTransfer(TransferDTO dto)
        {
            Transfer transfer = new Transfer();

            transfer.Id = dto.Id;
            transfer.Equipment = new EquipmentForTransfer(dto.Equipment, dto.Quantity);
            transfer.RoomsForTransfer = new RoomsForTransfer(dto.SourceRoomId, dto.DestinationRoomId);
            transfer.DateAndDuration = new DateAndDuration(dto.Date, dto.Duration);

            return transfer;
        }

        public static TransferDTO TransferToTransferDTO(Transfer transfer)
        {
            TransferDTO dto = new TransferDTO();
            
            dto.Id = transfer.Id;
            dto.Equipment = transfer.Equipment.Name;
            dto.Quantity = transfer.Equipment.Quantity;
            dto.SourceRoomId = transfer.RoomsForTransfer.SourceRoomId;
            dto.DestinationRoomId = transfer.RoomsForTransfer.DestinationRoomId;
            dto.Date = transfer.DateAndDuration.Date;
            dto.Duration = transfer.DateAndDuration.Duration;
            
            return dto;
        }
    }

}
