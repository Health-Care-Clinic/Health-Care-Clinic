
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    public class Room
    {

        public enum RoomType
        {
            RoomForAppointments,
            OperationRoom,
            WC 
        }
        public int Id
        {
            get; set;
        }

        public RoomType Type
        {
            get; set;
        }
        public String Name
        {
            get; set;
        }
        public String Description
        {
            get; set;
        }
        public int FloorId
        {
            get; set;
        }

        public float X
        {
            get; set;
        }
        public float Y
        {
            get; set;
        }
        public float Width
        {
            get; set;
        }
        public float Height
        {
            get; set;
        }


        public Room(int id, RoomType type, string name, string description, float x, float y, float width, float height, int floorId)
        {
            Id = id;
            Type = type;
            Name = name;
            Description = description;
            FloorId = floorId;
            X = x;
            Y = y;
            Width = width;
            Height = height;

        }

        public Room()
        {
            
        }
        
    }
}
