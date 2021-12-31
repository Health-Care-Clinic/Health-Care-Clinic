using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Model
{
    [Owned]
    public class DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateRange()
        {

        }
    }
}
