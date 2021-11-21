using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.DTO;
using Pharmacy.Model;

namespace Pharmacy.Service
{
    public interface IApiKeyService : IService<ApiKey>
    {
        ApiKey CreateApiKey(ApiKeyDTO dto);
        void ReceiveApiKey(ApiKeyDTO dto);
        ApiKey GetByKey(string key);
    }
}
