using Pharmacy.Advertisements.Model;
using Pharmacy.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Adapter
{
    public class AdvertisementAdapter
    {

        public static Advertisement AdvertisementDTOToAdvertisement(AdvertisementDTO advertisementDTO)
        {
            Advertisement advertisement = new Advertisement();
            advertisement.Description = advertisementDTO.Description;
            advertisement.Title = advertisementDTO.Title;
            return advertisement;
        }
    }
}
