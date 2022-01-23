using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class BestOfferDTO
    {
        public int TenderId { get; set; }
        public List<double> Offers { get; set; }
        public string PharmacyName { get; set; }

        public BestOfferDTO()
        {
        }

        public BestOfferDTO(int tenderId, List<double> offers, string pharmacyName)
        {
            TenderId = tenderId;
            Offers = offers;
            PharmacyName = pharmacyName;
        }
    }
}
