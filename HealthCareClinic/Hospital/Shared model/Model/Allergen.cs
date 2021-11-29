using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Allergen
    {
        [Key]
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
