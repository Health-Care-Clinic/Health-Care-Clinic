using Moq;
using Pharmacy.Model;
using Pharmacy_API.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.Interfaces.Repository;
using Pharmacy.Interfaces.Service;
using Pharmacy.Prescriptions.Model;
using Pharmacy.Prescriptions.Service;
using Pharmacy.Tendering.Model;
using Xunit;

namespace PharmacyTests
{
    public class PharmacyTenderTests
    {
        [Fact]
        public void Valid_date_range()
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(1);
            DateRange dateRange = new DateRange(start, end);
            Assert.Equal(start, dateRange.Start);
            Assert.Equal(end, dateRange.End);
        }

        [Fact]
        public void Invalid_date_range()
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(-1);
            DateRange dateRange;
            Assert.Throws<ArgumentException>(() => dateRange = new DateRange(start, end));
        }

        [Fact]
        public void Valid_price()
        {
            Price price = 10.0;
            Assert.Equal(10.0, price.Amount);
        }

        [Fact]
        public void Invalid_price()
        {
            Price price;
            Assert.Throws<ArgumentException>(() => price = -10);
        }

    }
}
