using System;
using System.Collections.Generic;
using System.Text;
using static Hospital.Rooms_and_equipment.Model.Equipment;

namespace Hospital_API.DTO
{
   public class EquipmentDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public EquipmentType Type { get; set; }
        public int Quantity { get; set; }
        public int RoomId { get; set; }
        public EquipmentDTO(int id, string name, EquipmentType type, int quantity, int roomId)
        {
            Id = id;
            Name = name;
            Type = type;
            Quantity = quantity;
            RoomId = roomId;
        }
        public EquipmentDTO() { }
    }
}
