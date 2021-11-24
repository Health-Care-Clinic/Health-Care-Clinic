using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Model
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

        public Medicine(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public Medicine() { }
    }
}
