using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Tendering.Model
{
    [Owned]
    public class Price
    {
        [JsonProperty]
        public double Amount { get; private set; }
        public Price(double amount)
        {
            if (amount >= 0)
            {
                Amount = amount;
            }
            else
            {
                throw new Exception();
            }
        }

        public static implicit operator Price(double amount)
        {
            return new Price(amount);
        }

        public Price()
        {

        }
    }
}
