using Enums;
using System;

namespace ClinicCore.DTOs
{
    public class EquipmentDTO
    {
        public EquiptType EquipType { get; set; }
        public int EquiptId { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String ProducerName { get; set; }
        public String EquipTypeText { get; set; }

        public EquipmentDTO(EquiptType equipType, int equiptId, string name, int quantity, string producerName)
        {
            EquipType = equipType;
            EquiptId = equiptId;
            Name = name;
            Quantity = quantity;
            ProducerName = producerName;

            if (equipType.Equals(EquiptType.Dynamic))
                EquipTypeText = "Dinamička";
            else if (equipType.Equals(EquiptType.Stationary))
                EquipTypeText = "Statička";
        }
    }
}
