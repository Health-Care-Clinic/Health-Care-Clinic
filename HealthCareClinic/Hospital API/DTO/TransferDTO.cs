using System;

namespace Hospital_API.DTO
{
    public class TransferDTO
    {
        public int Id
        {
            get; set;
        }
        public String Equipment
        {
            get; set;
        }

        public int Quantity
        {
            get; set;
        }

        public int SourceRoomId
        {
            get; set;
        }

        public int DestinationRoomId
        {
            get; set;
        }

        public String Date
        {
            get; set;
        }

        public int Duration
        {
            get; set;
        }

        public TransferDTO(int id, String equipment, int quantity, int sourceID, int destinationID, String date, int duration)
        {
            Id = id;
            Equipment = equipment;
            Quantity = quantity;
            SourceRoomId = sourceID;
            DestinationRoomId = destinationID;
            Date = date;
            Duration = duration;
        }

        public TransferDTO() { }

    }
}
