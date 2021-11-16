using Hospital.Rooms_and_equipment.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class BuildingAdapter
    {

        public static Building BuildingDTOToBuilding(BuildingDTO dto)
        {
            Building building = new Building();

            building.Id = dto.Id;
            building.Name = dto.Name;
            building.Type  = dto.Type;
            building.Width = dto.Width;
            building.Height = dto.Height;
            building.X = dto.X;
            building.Y = dto.Y;

            return building;
        }

        public static BuildingDTO BuildingToBuildingDTO(Building building)
        {
            BuildingDTO dto = new BuildingDTO();

            dto.Id = building.Id;
            dto.Name = building.Name;
            dto.Type = building.Type;
            dto.Width = building.Width;
            dto.Height = building.Height;
            dto.X = building.X;
            dto.Y = building.Y;

            return dto;
        }
    }

}
