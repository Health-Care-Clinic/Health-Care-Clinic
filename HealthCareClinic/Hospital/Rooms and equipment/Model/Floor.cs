using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    public class Floor
    {
        public int Id
        {
            get; set;
        }
        public String Name
        {
            get; set;
        }
        public int BuildingId
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

        public Floor(int id, string name, int buildingId, float x, float y, float width, float height)
        {
            Id = id;
            Name = name;
            BuildingId = buildingId;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Floor()
        {

        }
    }
}
