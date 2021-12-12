using System;
using System.Collections.Generic;
using Pharmacy.Adapter;
using Pharmacy.ApiKeys.Model;
using Pharmacy.DTO;
using Pharmacy.Repository;
using Pharmacy.Service;

namespace Pharmacy.ApiKeys.Service
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
            return _apiKeyRepository.GetById(id);
        }

        public IEnumerable<ApiKey> GetAll()
        {
            return _apiKeyRepository.GetAll();
        }

        public ApiKey CreateApiKey(ApiKeyDTO dto)
        {
            ApiKey newApiKey = ApiKeyAdapter.ApiKeyDtoToApiKey(dto);
            Guid g = Guid.NewGuid();
            newApiKey.Key = g.ToString();
            newApiKey.Category = "Hospital";
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

        public ApiKey GetByKey(string key)
        {
           return _apiKeyRepository.GetByKey(key);
        }
    }
}
