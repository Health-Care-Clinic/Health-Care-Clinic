using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
   public class Equipment
    {
        public enum EquipmentType
        {
            Static,
            Dynamic
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public EquipmentType Type { get; set; }
        public int Quantity { get; set; }
        public int RoomId { get; set; }
        public Equipment(int id, string name, EquipmentType type, int quantity, int roomId)
        {
            Id = id;
            Name = name;
            Type = type;
            Quantity = quantity;
            RoomId = roomId;
        }
        public Equipment() { }

        public override bool Equals(object obj)
        {
            return obj is Equipment equipment &&
                   Id == equipment.Id &&
                   Name == equipment.Name &&
                   Type == equipment.Type &&
                   Quantity == equipment.Quantity &&
                   RoomId == equipment.RoomId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Type, Quantity, RoomId);
        }
    }
}
