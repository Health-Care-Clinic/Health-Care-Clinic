using Enums;
using System;

namespace Model
{
    public class AdvancedRenovation
    {
        public Room RoomFirst { get; set; }
        public Room RoomSecond { get; set; }
        public Room RenovationResultRoom { get; set; }

        public AdvancedRenovationType Type { get; set; }

        public Boolean IsMade { get; set; }
        public DateTime RenovationEnd { get; set; }
        public DateTime RenovationStart { get; set; }

        public AdvancedRenovation(Room roomFirst, Room roomSecond, Room renovationResultRoom, AdvancedRenovationType type, bool isMade, DateTime renovationEnd)
        {
            RoomFirst = roomFirst;
            RoomSecond = roomSecond;
            RenovationResultRoom = renovationResultRoom;
            Type = type;
            IsMade = isMade;
            RenovationEnd = renovationEnd;
        }

    }
}
