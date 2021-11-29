using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    public class Transfer
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

        public DateTime Date
        {
            get; set;
        }

        public int Duration
        {
            get; set;
        }

        public Transfer(int id, String equipment, int quantity, int sourceID, int destinationID, DateTime date, int duration) {
            Id = id;
            Equipment = equipment;
            Quantity = quantity;
            SourceRoomId = sourceID;
            DestinationRoomId = destinationID;
            Date = date;
            Duration = duration;
        }

        public Transfer() { }

    }
}
