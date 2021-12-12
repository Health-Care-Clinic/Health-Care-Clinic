using ClinicCore.Storages;
using Integration.Interface.Repository;
using Integration.Pharmacy.Model;
using Integration.Promotions.Model;

namespace Integration.Promotions.Repository
{
    public class PharmacyPromotionRepository : Repository<PharmacyPromotion>, IPharmacyPromotionRepository
    {
        public PharmacyPromotionRepository(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public IntegrationDbContext IntegrationDbContext
        {
            get { return Context as IntegrationDbContext; }
        }
    }
}
