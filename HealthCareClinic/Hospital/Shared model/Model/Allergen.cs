using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Allergen
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Allergen() {}

        public Allergen(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
