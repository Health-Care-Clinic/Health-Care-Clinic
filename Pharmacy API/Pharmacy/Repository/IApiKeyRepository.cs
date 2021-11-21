using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.Model;

namespace Pharmacy.Repository
{
    public interface IApiKeyRepository : IRepository<ApiKey>
    {
        ApiKey GetByKey(string key);
    }
}
