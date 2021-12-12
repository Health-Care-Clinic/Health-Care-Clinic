using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicCore.Storages;
using Integration.ApiKeys.Model;
using Integration.Interface.Repository;

namespace Integration.Repository
{
    public class ApiKeyRepository : Repository<ApiKey>, IApiKeyRepository
    {
        public ApiKeyRepository(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public IntegrationDbContext IntegrationDbContext
        {
            get { return Context as IntegrationDbContext; }
        }

        public ApiKey GetByName(string name)
        {
            return IntegrationDbContext.ApiKeys.FirstOrDefault(apiKey => apiKey.Name.Equals(name));
        }

        public ApiKey GetByUrl(string url)
        {
            return IntegrationDbContext.ApiKeys.FirstOrDefault(apiKey => apiKey.BaseUrl.Equals(url));
        }

        public ApiKey GetByKey(string key)
        {
            return IntegrationDbContext.ApiKeys.FirstOrDefault(k => k.Key.Equals(key));
        }
    }
}
