using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.DTO
{
    public class MedicineDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Usage { get; set; }
        public int Weight { get; set; }
        public String SideEffects { get; set; }
        public String Reactions { get; set; }
        public String CompatibileMedicine { get; set; }

        public Double Price { get; set; }

        public MedicineDTO(string name, int quantity, string manufacturer, string usage, int weight, string sideEffects, string reactions, string compatibileMedicine, double price)
        {
         
            Name = name;
            Quantity = quantity;
            Manufacturer = manufacturer;
            Usage = usage;
            Weight = weight;
            SideEffects = sideEffects;
            Reactions = reactions;
            CompatibileMedicine = compatibileMedicine;
            Price = price;
        }

        public MedicineDTO() { }
    }
}

