using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    [Owned]
    public class RoomsForTransfer
    {
        public int SourceRoomId { get; set; }
        public int DestinationRoomId { get; set; }
        public RoomsForTransfer() { }
        public RoomsForTransfer(int sourceRoomId, int destinationRoomId) {
            SourceRoomId = sourceRoomId;
            DestinationRoomId = destinationRoomId;
            Validate();
        }

        private void Validate()
        {
            CheckRoomsId();
        }

        private void CheckRoomsId()
        {
            if (SourceRoomId.Equals(DestinationRoomId))
                throw new ArgumentException("Source room and destination room in transfering equipment can't be the same!");
        }
    }
}
