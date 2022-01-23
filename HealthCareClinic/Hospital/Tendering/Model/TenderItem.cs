using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Model
{
    public class TenderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public TenderItem()
        {
        }

        public TenderItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
