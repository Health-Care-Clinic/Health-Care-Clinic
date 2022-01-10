using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Tendering.Model
{
    public class BestOfferDTO
    {
        public int TenderId { get; set; }
        public double Offer { get; set; }
        public string PharmacyName { get; set; }

        public BestOfferDTO()
        {
        }

        public BestOfferDTO(int tenderId, double offer, string pharmacyName)
        {
            TenderId = tenderId;
            Offer = offer;
            PharmacyName = pharmacyName;
        }
    }
}
