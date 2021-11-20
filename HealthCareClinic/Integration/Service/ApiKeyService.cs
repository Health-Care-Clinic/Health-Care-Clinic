using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Service;
using Integration.Adapter;
using Integration.ApiKeys.Model;
using Integration.DTO;
using Integration.Interface.Repository;
using Integration.Interface.Service;

namespace Integration.Service
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IApiKeyRepository _apiKeyRepository;

        public ApiKeyService(IApiKeyRepository apiKeyRepository)
        {
            _apiKeyRepository = apiKeyRepository;
        }

        public void Add(ApiKey entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ApiKey entity)
        {
            throw new NotImplementedException();
        }

        public ApiKey GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApiKey> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApiKey CreateApiKey(ApiKeyDTO dto)
        {
            ApiKey newApiKey = ApiKeyAdapter.ApiKeyDtoToApiKey(dto);
            Guid g = Guid.NewGuid();
            newApiKey.Key = g.ToString();
            newApiKey.Category = "Pharmacy";
            _apiKeyRepository.Add(newApiKey);
            _apiKeyRepository.Save();

            return newApiKey;
        }

        public void ReceiveApiKey(ApiKeyDTO dto)
        {
            ApiKey receivedApiKey = ApiKeyAdapter.ApiKeyDtoToApiKey(dto);
            _apiKeyRepository.Add(receivedApiKey);
            _apiKeyRepository.Save();
        }

        public ApiKey GetMyApiKey(string url)
        {
            return _apiKeyRepository.GetByUrl(url);
        }

        public ApiKey GetApiKeyByName(string name)
        {
            return _apiKeyRepository.GetByName(name);
        }
    }
}
