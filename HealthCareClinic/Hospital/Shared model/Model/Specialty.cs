using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Specialty
    {
        [Key]
        public int SpecialtyId { get; set; }
        public String Name { get; set; }

        public Specialty()
        {
        }
        public Specialty(string name)
        {
            this.Name = name;
        }
    }
}
