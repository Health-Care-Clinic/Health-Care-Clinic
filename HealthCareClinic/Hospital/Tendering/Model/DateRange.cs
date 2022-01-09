using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Model
{
    [Owned]
    public class DateRange
    {
        [JsonProperty]
        public DateTime Start { get; private set; }
        [JsonProperty]
        public DateTime End { get; private set; }
        public DateRange(DateTime start, DateTime end)
        {
            if (start <= end)
            {
                Start = start;
                End = end;
            }
            else
            {
                throw new ArgumentException("Start date can't be after end date.");
            }
            
        }

        public DateRange()
        {

        }
    }
}
