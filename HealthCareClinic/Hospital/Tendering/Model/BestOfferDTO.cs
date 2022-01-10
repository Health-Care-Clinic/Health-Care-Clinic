using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Tendering.Model
{
    public class BestOfferDto
    {
        public int TenderId { get; set; }
        public double Offer { get; set; }
        public string PharmacyName { get; set; }

        public BestOfferDto()
        {
        }

        public BestOfferDto(int tenderId, double offer, string pharmacyName)
        {
            TenderId = tenderId;
            Offer = offer;
            PharmacyName = pharmacyName;
        }
    }
}
