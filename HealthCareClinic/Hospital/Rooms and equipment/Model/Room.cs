
using Hospital.Graphical_editor.Model;
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

        public virtual PositionAndDimension PositionAndDimension 
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
            PositionAndDimension = new PositionAndDimension(x, y, width, height);
        }

        public Room(int id, RoomType type, string name, string description, int floorId, PositionAndDimension positionAndDimension)
        {
            Id = id;
            Type = type;
            Name = name;
            Description = description;
            FloorId = floorId;
            PositionAndDimension = positionAndDimension;
        }

        public Room()
        {
            
        }
        
    }
}
