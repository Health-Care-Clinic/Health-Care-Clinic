using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
 
    public class AllergenForPatient
    {
        public int PatientId { get; set; }

        public int AllergenId { get; set; }

        public string Name { get; set; }
        public AllergenForPatient() {}

        public AllergenForPatient(int allergenId, int paitentId, string name)
        {
            PatientId = paitentId;
            AllergenId = allergenId;
            Name = name;
        }
    }
}
