using ClinicCore.Storages;
using Integration.Interface.Repository;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Repository
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
