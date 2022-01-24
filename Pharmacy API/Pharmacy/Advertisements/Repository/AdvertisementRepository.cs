using Pharmacy.Advertisements.Model;
using Pharmacy.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Advertisements.Repository
{
    public class AdvertisementRepository : Repository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(PharmacyDbContext context) : base(context)
        {
        }

        public PharmacyDbContext PharmacyDbContext
        {
            get { return Context as PharmacyDbContext; }
        }
    }
}
