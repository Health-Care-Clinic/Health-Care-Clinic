using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Tendering.Model
{
    public class TenderResponse
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public string PharmacyName { get; set; }
        public Price TotalPrice { get; set; }
        public string Description { get; set; }
        public bool IsWinningBid { get; set; }
        public virtual ICollection<TenderItem> TenderItems { get; set; }
        public TenderResponse()
        {
        }
        public TenderResponse(int tenderId, string pharmacyName, Price totalPrice, string description, bool isWinningBid, ICollection<TenderItem> tenderItems)
        {
            TenderId = tenderId;
            PharmacyName = pharmacyName;
            TotalPrice = totalPrice;
            Description = description;
            IsWinningBid = isWinningBid;
            TenderItems = tenderItems;
        }
    }
}
