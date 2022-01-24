using Pharmacy.Prescriptions.Model;
using System;
using System.Collections.Generic;

namespace Pharmacy.Advertisements.Model
{
    public class Advertisement
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public virtual ICollection<AdvertisementMedicine> AdvertisementMedicines { get; set; } = new List<AdvertisementMedicine>();

        public Advertisement()
        {
            
        }

        public Advertisement(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Advertisement(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void add(AdvertisementMedicine advertisementMedicine)
        {
            this.AdvertisementMedicines.Add(advertisementMedicine);
        }
    }
}
