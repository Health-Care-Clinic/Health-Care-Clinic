using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.ApiKeys.Model;

namespace Integration_API.Service.TestServices
{
    public interface IMyDbContext
    {
        List<ApiKey> GetApiKeys();
    }
}
