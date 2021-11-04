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

        public Medicine(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public Medicine() { }
    }
}
