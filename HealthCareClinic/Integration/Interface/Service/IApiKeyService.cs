using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Service;
using Integration.ApiKeys.Model;
using Integration.DTO;

namespace Integration.Interface.Service
{
    public interface IApiKeyService : IService<ApiKey>
    {
        ApiKey CreateApiKey(ApiKeyDTO dto);
        void ReceiveApiKey(ApiKeyDTO dto);
        ApiKey GetMyApiKey(string url);
        ApiKey GetApiKeyByName(string name);
    }
}
