using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Tendering.Model;

namespace Hospital_API.DTO
{
    public class TenderDTO
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public bool IsWinningBidChosen { get; set; }
        public bool IsOpen { get; set; }
        public int OffersNumber { get; set; }
        public double Price { get; set; }
        public ICollection<TenderItem> TenderItems { get; set; }

        public TenderDTO() { }

        public TenderDTO(int id, string startDate, string endDate, string description, bool isWinningBidChosen, bool isOpen, int offersNumber, double price, ICollection<TenderItem> tenderItems)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            IsWinningBidChosen = isWinningBidChosen;
            IsOpen = isOpen;
            OffersNumber = offersNumber;
            Price = price;
            TenderItems = tenderItems;
        }
    }
}
