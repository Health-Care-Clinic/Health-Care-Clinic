using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class AllergenForPatients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }


        public AllergenForPatients() {}

        public AllergenForPatients(int id, string name, int pid)
        {
            Id = id;
            Name = name;
            PatientId = pid;
        }
    }
}
