using Hospital.Rooms_and_equipment.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class EquipmentAdapter
    {
        public static Equipment EquipmentDTOToEquipment(EquipmentDTO dto)
        {
            Equipment equipment = new Equipment();

            equipment.Id = dto.Id;
            equipment.Name = dto.Name;
            equipment.Type = dto.Type;
            equipment.Quantity = dto.Quantity;
            equipment.RoomId = dto.RoomId;

            return equipment;
        }

        public static EquipmentDTO EquipmentToEquipmentDTO(Equipment equipment)
        {
            EquipmentDTO dto = new EquipmentDTO();

            dto.Id = equipment.Id;
            dto.Name = equipment.Name;
            dto.Type = equipment.Type;
            dto.RoomId = equipment.RoomId;
            dto.Quantity = equipment.Quantity;
          
            return dto;
        }
    }
}
