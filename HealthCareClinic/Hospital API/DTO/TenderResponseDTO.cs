using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Tendering.Model;

namespace Hospital_API.DTO
{
    public class TenderResponseDTO
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public string PharmacyName { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }
        public bool IsWinningBid { get; set; }
        public virtual ICollection<TenderItem> TenderItems { get; set; }

        public TenderResponseDTO()
        {
        }

        public TenderResponseDTO(int id, int tenderId, string pharmacyName, double totalPrice, string description, bool isWinningBid, ICollection<TenderItem> tenderItems)
        {
            Id = id;
            TenderId = tenderId;
            PharmacyName = pharmacyName;
            TotalPrice = totalPrice;
            Description = description;
            IsWinningBid = isWinningBid;
            TenderItems = tenderItems;
        }
    }
}
