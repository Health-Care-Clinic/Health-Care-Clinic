using Hospital.Rooms_and_equipment.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class FloorAdapter
    {
        public static Floor FloorDTOToFloor(FloorDTO dto)
        {
            Floor floor = new Floor();

            floor.Id = dto.Id;
            floor.Name = dto.Name;
            floor.BuildingId = dto.BuildingId;
            floor.Width = dto.Width;
            floor.Height = dto.Height;
            floor.X = dto.X;
            floor.Y = dto.Y;

            return floor;
        }

        public static FloorDTO FloorToFloorDTO(Floor floor)
        {
            FloorDTO dto = new FloorDTO();

            dto.Id = floor.Id;
            dto.Name = floor.Name;
            dto.BuildingId = floor.BuildingId;
            dto.Width = floor.Width;
            dto.Height = floor.Height;
            dto.X = floor.X;
            dto.Y = floor.Y;

            return dto;
        }
    }
}
