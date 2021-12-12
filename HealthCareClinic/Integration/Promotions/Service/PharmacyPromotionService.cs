using System.Collections.Generic;
using Integration.Interface.Repository;
using Integration.Interface.Service;
using Integration.Pharmacy.Model;
using Integration.Promotions.Model;

namespace Integration.Promotions.Service
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
            _pharmacyPromotionRepository.Add(entity);
        }

        public IEnumerable<PharmacyPromotion> GetAll()
        {
            return _pharmacyPromotionRepository.GetAll();
        }

        public PharmacyPromotion GetOneById(int id)
        {
            return _pharmacyPromotionRepository.GetById(id);
        }

        public void Remove(PharmacyPromotion entity)
        {
            _pharmacyPromotionRepository.Remove(entity);
        }

        public void SaveChanges()
        {
            _pharmacyPromotionRepository.Save();
        }
    }
}
