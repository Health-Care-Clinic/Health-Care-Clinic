using Integration.Interface.Repository;
using Integration.Interface.Service;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Service
{
    public class PharmacyPromotionService : IPharmacyPromotionService
    {
        private readonly IPharmacyPromotionRepository _pharmacyPromotionRepository;

        public PharmacyPromotionService(IPharmacyPromotionRepository pharmacyPromotionRepository)
        {
            _pharmacyPromotionRepository = pharmacyPromotionRepository;
        }
        public void Add(PharmacyPromotion entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PharmacyPromotion> GetAll()
        {
            return _pharmacyPromotionRepository.GetAll();
        }

        public PharmacyPromotion GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(PharmacyPromotion entity)
        {
            throw new NotImplementedException();
        }
    }
}
