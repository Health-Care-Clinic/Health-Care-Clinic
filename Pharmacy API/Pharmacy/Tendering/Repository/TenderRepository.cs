using Pharmacy.Interfaces.Repository;
using Pharmacy.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Tendering.Repository
{
    public class TenderRepository : Repository<Tender>, ITenderRepository
    {
        public TenderRepository(PharmacyDbContext dbContext) : base(dbContext)
        {
        }

        public PharmacyDbContext PharmacyDbContext
        {
            get { return Context as PharmacyDbContext; }
        }
    }
}
