using System;
using System.Collections.Generic;
using Pharmacy.Prescriptions.Model;

namespace Pharmacy.Tendering.Model
{
    public class Tender
    {
        public List<Medicine> Medicines { get; set; }
        public Double TotalPrice { get; set; }
        public String TenderResponseDescription {get;set;}

        public Tender(List<Medicine> medicines, double totalPrice, string tenderResponseDescription)
        {
            Medicines = medicines;
            TotalPrice = totalPrice;
            TenderResponseDescription = tenderResponseDescription;
        }

        public Tender()
        {
        }
    }
}
