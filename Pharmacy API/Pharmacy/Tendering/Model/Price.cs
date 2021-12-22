using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Tendering.Model
{
    [Owned]
    public class Price
    {
        public double Amount { get; }
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
    }
}
