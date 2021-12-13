using System;

namespace DTOs
{
    public class StaticTransferAppointmentDTO
    {
        public int SourceRoomId { get; set; }
        public int DestinationRoomId { get; set; }
        public int EquipId { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Description { get; set; }

        public StaticTransferAppointmentDTO(int sourceRoomId, int destinationRoomId, int equipId, int quantity, DateTime startDate, DateTime endDate, string description)
        {
            SourceRoomId = sourceRoomId;
            DestinationRoomId = destinationRoomId;
            EquipId = equipId;
            Quantity = quantity;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }
    }
}
