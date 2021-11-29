

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
            transfer.Equipment = dto.Equipment;
            transfer.Quantity = dto.Quantity;
            transfer.SourceRoomId = dto.SourceRoomId;
            transfer.DestinationRoomId = dto.DestinationRoomId;
            transfer.Date = dto.Date;
            transfer.Duration = dto.Duration;

            return transfer;
        }

        public static TransferDTO TransferToTransferDTO(Transfer transfer)
        {
            TransferDTO dto = new TransferDTO();
            
            dto.Id = transfer.Id;
            dto.Equipment = transfer.Equipment;
            dto.Quantity = transfer.Quantity;
            dto.SourceRoomId = transfer.SourceRoomId;
            dto.DestinationRoomId = transfer.DestinationRoomId;
            dto.Date = transfer.Date;
            dto.Duration = transfer.Duration;
            
            return dto;
        }
        /*
        private static int returnMonth(String month)
        {
            if (month == "Dec")
            {
                return 12;
            }
            else if (month == "Nov")
            {
                return 11;
            }
            else if (month == "Oct")
            {
                return 10;
            }
            else if (month == "Sep")
            {
                return 9;
            }
            else if (month == "Aug")
            {
                return 8;
            }
            else if (month == "Jul")
            {
                return 7;
            }
            else if (month == "Jun")
            {
                return 6;
            }
            else if (month == "May")
            {
                return 5;
            }
            else if (month == "Apr")
            {
                return 4;
            }
            else if (month == "Mar")
            {
                return 3;
            }
            else if (month == "Feb")
            {
                return 2;
            }
            else
            {
                return 1;
            }

        }*/
    }

}
