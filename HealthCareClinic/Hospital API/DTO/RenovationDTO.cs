using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Hospital.Rooms_and_equipment.Model.Renovation;

namespace Hospital_API.DTO
{
    public class RenovationDTO
    {
        public int Id
        {
            get; set;
        }

        public int FirstRoomId
        {
            get; set;
        }

        public int SecondRoomId
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
        public RenovationType Type
        {
            get; set;
        }

        public RenovationDTO(int id, int firstRoomId, int secondRoomId, DateTime date, int duration, RenovationType type)
        {
            Id = id;
            FirstRoomId = firstRoomId;
            SecondRoomId = secondRoomId;
            Date = date;
            Duration = duration;
            Type = type;
        }
        public RenovationDTO() { }


    }
}
