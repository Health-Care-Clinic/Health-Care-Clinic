using ClinicCore.Storages;
using Integration.Interface.Repository;
using Integration.Promotions.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration.Promotions.Repository
{
    public class PharmacyPromotionRepository : Repository<PharmacyPromotion>, IPharmacyPromotionRepository
    {
        private readonly IntegrationDbContext dbContext;
        public PharmacyPromotionRepository(IntegrationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        //public IntegrationDbContext IntegrationDbContext
        //{
        //    get { return Context as IntegrationDbContext; }
        //}

        public List<PharmacyPromotion> GetAllActivePromotions()
        {
            return dbContext.PharmacyPromotions.Where(p => p.Posted == true && p.StartTime.AddDays(1).Date < DateTime.Now.Date 
                                                            && p.EndTime.AddDays(1).Date > DateTime.Now.Date).ToList();
        }
    }
}
