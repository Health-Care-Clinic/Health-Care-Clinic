using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTO
{
    public class MedicineDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public MedicineDTO(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public MedicineDTO() { }
    }
}
