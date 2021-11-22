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
        public List<String> SideEffects { get; set; }
        public List<String> Reactions { get; set; }
        public List<int> CompatibileMedicine { get; set; }

        public MedicineDTO(string name, int quantity, string manufacturer, string usage, int weight, List<string> sideEffects, List<string> reactions, List<int> compatibileMedicine)
        {
         
            Name = name;
            Quantity = quantity;
            Manufacturer = manufacturer;
            Usage = usage;
            Weight = weight;
            SideEffects = sideEffects;
            Reactions = reactions;
            CompatibileMedicine = compatibileMedicine;
        }

        public MedicineDTO() { }
    }
}

