
using System;
using System.Collections.Generic;
using System.Text;
using static Hospital.Rooms_and_equipment.Model.Building;

namespace Hospital_API.DTO
{
    public class BuildingDTO
    {
        public int Id
        {
            get; set;
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

        public BuildingDTO(int id, string name, BuildingType type, float x, float y, float width, float height)
        {
            Id = id;
            Name = name;
            Type = type;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public BuildingDTO() {
        }
    }
}
