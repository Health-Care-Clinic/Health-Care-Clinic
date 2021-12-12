using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medicines.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Medicine(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public Medicine() { }
    }
}
