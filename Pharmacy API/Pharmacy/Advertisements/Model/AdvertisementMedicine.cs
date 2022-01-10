using Pharmacy.Prescriptions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Advertisements.Model
{
    public class AdvertisementMedicine
    {

        public int AdvertisementId { get; set; }
        public virtual Advertisement Advertisement { get; set; }

        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
