using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Day
    {
        [Key]
        public int DayId { get; set; }
        public DateTime Spec_Day { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
    }
}
