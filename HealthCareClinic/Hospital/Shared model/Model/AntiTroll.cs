using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class AntiTroll
    {
        [Key]
        int AntiTrollId { get; set; }
        public DateTime TrollCheckStartDate { get; set; }
        public int AppointmentCounterInTimeRange { get; set; }
        public bool IsTroll { get; set; }

        public AntiTroll()
        {
        }
    }
}
