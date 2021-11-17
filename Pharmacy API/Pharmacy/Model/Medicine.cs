using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Usage { get; set; }
        public int Weight { get; set; }
        public List<String> SideEffects { get; set; }
        public List<String> Reactions { get; set; }
        public List<int> CompatibileMedicine { get; set; }

        public Medicine(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public Medicine(int id, string name, int quantity, string manufacturer, string usage, int weight, List<string> sideEffects, List<string> reactions, List<int> compatibileMedicine) : this(id, name, quantity)
        {
            Manufacturer = manufacturer;
            Usage = usage;
            Weight = weight;
            SideEffects = sideEffects;
            Reactions = reactions;
            CompatibileMedicine = compatibileMedicine;
        }

        public Medicine() { }
    }
}
