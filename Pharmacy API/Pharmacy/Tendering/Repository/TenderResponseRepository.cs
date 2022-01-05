using Pharmacy.Interfaces.Repository;
using Pharmacy.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Tendering.Repository
{
    public class TenderResponseRepository : Repository<TenderResponse>, ITenderResponseRepository
    {
        public TenderResponseRepository(PharmacyDbContext context) : base(context)
        {
        }

        public PharmacyDbContext PharmacyDbContext
        {
            get { return Context as PharmacyDbContext; }
        }
    }
}
