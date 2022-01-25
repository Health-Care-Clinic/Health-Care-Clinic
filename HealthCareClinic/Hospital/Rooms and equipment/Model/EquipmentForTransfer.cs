using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    [Owned]
    public class EquipmentForTransfer
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public EquipmentForTransfer() { }
        public EquipmentForTransfer(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
