using System;
using System.Collections.Generic;
using Pharmacy.Prescriptions.Model;

namespace Pharmacy.Tendering.Model
{
    public class Tender
    {
        public int Id { get; set; }
        public DateRange DateRange { get; set; }
        public virtual ICollection<TenderItem> TenderItems { get; set; }
        public string Description { get; set; }

        public Tender()
        {
        }

        public Tender(DateRange dateRange, ICollection<TenderItem> tenderItems)
        {
            DateRange = dateRange;
            TenderItems = tenderItems;
        }
    }
}
