using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pharmacy.Model;

namespace Pharmacy.Repository
{
    public class ApiKeyRepository : Repository<ApiKey>, IApiKeyRepository
    {
        public ApiKeyRepository(PharmacyDbContext dbContext) : base(dbContext)
        {
        }

        public PharmacyDbContext PharmacyDbContext
        {
            get { return Context as PharmacyDbContext; }
        }

        public ApiKey GetByKey(string key)
        {
            return PharmacyDbContext.ApiKeys.FirstOrDefault(k => k.Key.Equals(key));
        }
    }
}
