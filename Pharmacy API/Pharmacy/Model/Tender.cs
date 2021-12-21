﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Model
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
