using Pharmacy.ApiKeys.Model;
using Pharmacy.DTO;

namespace Pharmacy.Interfaces.Service
{
    public interface IApiKeyService : IService<ApiKey>
    {
        ApiKey CreateApiKey(ApiKeyDTO dto);
        void ReceiveApiKey(ApiKeyDTO dto);
        ApiKey GetByKey(string key);
    }
}
