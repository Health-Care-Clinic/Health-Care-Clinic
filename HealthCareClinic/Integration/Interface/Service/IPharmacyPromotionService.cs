using ClinicCore.Service;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Integration.Promotions.Model;

namespace Integration.Interface.Service
{
    public interface IPharmacyPromotionService : IService<PharmacyPromotion>
    {
        void SaveChanges();
    }
}
