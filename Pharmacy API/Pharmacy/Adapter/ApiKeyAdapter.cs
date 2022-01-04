using Pharmacy.ApiKeys.Model;
using Pharmacy.DTO;
using Pharmacy.Model;

namespace Pharmacy.Adapter
{
    public class ApiKeyAdapter
    {
        public static ApiKey ApiKeyDtoToApiKey(ApiKeyDTO dto)
        {
            ApiKey apiKey = new ApiKey();
            apiKey.Name = dto.Name;
            apiKey.Key = dto.Key;
            apiKey.BaseUrl = dto.BaseUrl;
            apiKey.Category = dto.Category;

            return apiKey;
        }

        public static ApiKeyDTO ApiKeyToApiKeyDto(ApiKey apiKey)
        {
            ApiKeyDTO dto = new ApiKeyDTO();
            dto.Name = apiKey.Name;
            dto.Key = apiKey.Key;
            dto.BaseUrl = apiKey.BaseUrl;
            dto.Category = apiKey.Category;

            return dto;
        }
    }
}
