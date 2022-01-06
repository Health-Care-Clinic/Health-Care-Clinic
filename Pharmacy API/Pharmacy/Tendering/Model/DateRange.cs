using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Tendering.Model
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
            Start = start;
            End = end;
        }

        public DateRange()
        {

        }
    }
}
