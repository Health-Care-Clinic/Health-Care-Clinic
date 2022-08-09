using Pharmacy.ApiKeys.Model;

namespace Pharmacy.Interfaces.Repository
{
    public interface IApiKeyRepository : IRepository<ApiKey>
    {
        ApiKey GetByKey(string key);
    }
}
