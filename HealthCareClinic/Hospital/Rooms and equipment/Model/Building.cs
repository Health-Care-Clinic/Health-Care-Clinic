
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    public class Building
    {
        public int Id
        {
            get; set;
        }
        public enum BuildingType
        {
            Hospital,
            Parking
        }

        public String Name
        {
            get; set;
        }

        public BuildingType Type
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

        public Building(int id, string name, BuildingType type, float x, float y, float width, float height)
        {
            Id = id;
            Name = name;
            Type = type;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Building() {
        }
    }
}
