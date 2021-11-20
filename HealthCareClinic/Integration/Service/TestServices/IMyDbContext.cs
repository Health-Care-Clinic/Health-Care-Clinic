using System.Collections.Generic;
using Integration.ApiKeys.Model;

namespace Integration.Service.TestServices
{
    public interface IMyDbContext
    {
        List<ApiKey> GetApiKeys();
    }
}
