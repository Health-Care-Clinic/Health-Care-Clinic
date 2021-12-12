using System;
using System.Collections.Generic;
using System.Linq;
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
            _apiKeyRepository.Add(entity);
        }

        public void Remove(ApiKey entity)
        {
            _apiKeyRepository.Remove(entity);
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
            newApiKey.Category = "Pharmacy";
            newApiKey.City = "";
            newApiKey.ImagePath = "";
            newApiKey.Note = "";
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

        public ApiKey GetByKey(string key)
        {
            return _apiKeyRepository.GetByKey(key);
        }

        public ApiKey EditPharmacyProfile(ApiKey ak)
        {
            ApiKey apikey = GetOneById(ak.Id);
            Remove(apikey);
            apikey.City = ak.City;
            apikey.ImagePath = ak.ImagePath;
            apikey.Note = ak.Note;
            Add(apikey);
            return apikey;
        }

        public void EditPharmacyPicturePath(int id, string fileName)
        {
            ApiKey apikey = GetOneById(id);
            Remove(apikey);
            apikey.ImagePath = fileName;
            Add(apikey);
            return;
        }

        public List<PharmacyDTO> GetPharmacies()
        {
            List<PharmacyDTO> pharmacies = new List<PharmacyDTO>();
            _apiKeyRepository.GetAll().Where(apiKey => apiKey.Category.Equals("Pharmacy")).ToList().ForEach(apiKey => pharmacies.Add(ApiKeyAdapter.ApiKeyToPharmacyDto(apiKey)));
            return pharmacies;

        }
    }
}
