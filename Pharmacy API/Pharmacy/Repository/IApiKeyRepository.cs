using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.ApiKeys.Model;
using Pharmacy.Model;

namespace Pharmacy.Repository
{
    public interface IApiKeyRepository : IRepository<ApiKey>
    {
        ApiKey GetByKey(string key);
    }
}
