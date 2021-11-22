using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Model
{
    public class PharmacyPromotion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public bool Posted { get; set; }
        public string PharmacyName { get; set; }

        public PharmacyPromotion() { }

        public PharmacyPromotion(int id, string title, string content, DateTime startTime, DateTime endTime, bool posted, string pharmacyName)
        {
            Id = id;
            Title = title;
            Content = content;
            StartTime = startTime;
            EndTime = endTime;
            Posted = posted;
            PharmacyName = pharmacyName;
        }
    }
}
