using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Tendering.Model
{
    public class Tender
    {
        public int Id { get; set; }
        public int ForeignId { get; set; }
        public DateRange DateRange { get; set; }
        //public List<Medicine> Medicines { get; set; }
        public Price TotalPrice { get; set; }
        public String TenderResponseDescription { get; set; }
        public bool IsWinningBidChosen { get; set; }

        public Tender(List<Medicine> medicines, Price totalPrice, DateRange dateRange, string tenderResponseDescription)
        {
            //Medicines = medicines;
            TotalPrice = totalPrice;
            DateRange = dateRange;
            TenderResponseDescription = tenderResponseDescription;
            IsWinningBidChosen = false;
        }

        public Tender()
        {
        }
    }
}
