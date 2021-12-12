using System.Linq;
using Pharmacy.ApiKeys.Model;
using Pharmacy.Repository;

namespace Pharmacy.ApiKeys.Repository
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
