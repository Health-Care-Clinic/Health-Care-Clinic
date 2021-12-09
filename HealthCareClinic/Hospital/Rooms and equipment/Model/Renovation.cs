using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    public class Renovation
    {

        public enum RenovationType
        {
            Divide,
            Merge
        }
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

        public Renovation(int id, int firstRoomId, int secondRoomId, DateTime date, int duration, RenovationType type)
        {
            Id = id;
            FirstRoomId = firstRoomId;
            SecondRoomId = secondRoomId;
            Date = date;
            Duration = duration;
            Type = type;
        }

        public Renovation() { }


    }
}
