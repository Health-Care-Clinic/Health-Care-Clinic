using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Model
{
    [Owned]
    public class Price : ValueObject
    {
        [JsonProperty]
        public double Amount { get; private set; }

        public Price()
        {

        }

        public Price(double amount)
        {
            if (amount >= 0)
            {
                Amount = amount;
            }
            else
            {
                throw new ArgumentException("Amount can't be negative value.");
            }
        }

        public static implicit operator Price(double amount)
        {
            return new Price(amount);
        }
    }
}
