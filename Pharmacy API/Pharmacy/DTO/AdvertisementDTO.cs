using Pharmacy.Prescriptions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.DTO
{
    public class AdvertisementDTO
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public  ICollection<int> AdvertisementMedicines { get; set; } = new List<int>();

        public AdvertisementDTO(string title, string description, ICollection<int> advertisementMedicines)
        {
        
            Title = title;
            Description = description;
            AdvertisementMedicines = advertisementMedicines;
        }

        public AdvertisementDTO()
        {
        }
    }
}
