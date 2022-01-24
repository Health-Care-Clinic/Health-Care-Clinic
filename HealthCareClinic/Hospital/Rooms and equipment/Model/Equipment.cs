using System;
using System.Collections.Generic;
using System.Linq;
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
            Validate();
        }

        public Equipment(string name,  int quantity)
        {
            Id = 0;
            Name = name;
            Type = EquipmentType.Dynamic;
            Quantity = quantity;
            RoomId = 0;
            Validate();
        }
        public Equipment() { }

        private void Validate()
        {
            CheckName();
            CheckQuantity();
        }

        private void CheckName()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentException("Equipment name can't be empty!");
        }

        private void CheckQuantity()
        {
            if (Quantity < 0)
                throw new ArgumentException("Equipment quantity can't be less than zero!");
        }

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

        public bool EquipmentExistsInRoom(List<Equipment> roomEquipment)
        {
            if (roomEquipment.Select(eq => eq.Name).Any(x => x.Equals(Name)))
            {
                return true;
            }

            return false;
        }

        public int GetQuantityOfEquipmentInOtherRoom(List<Equipment> roomEquipment)
        {
            int quantity = 0;
            foreach (Equipment eq in roomEquipment.Where(x => x.Name.Equals(Name)))
            {
                quantity += eq.Quantity;
            }

            return quantity;
        }
    }
}
