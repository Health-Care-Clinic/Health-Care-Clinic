using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.ApiKeys.Model;
using Integration.DTO;

namespace Integration.Service
{
    public class MedSpecificationService
    {
        private readonly IntegrationDbContext _dbContext;

        public MedSpecificationService(IntegrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SendSpecificationRequest(string to, string medicine, string url)
        {
            MessageDTO toSend = new MessageDTO(medicine);
            ApiKey apiKey = _dbContext.ApiKeys.FirstOrDefault(apiKey => apiKey.Name.Equals(to));
            ApiKey myApiKey = _dbContext.ApiKeys.FirstOrDefault(apiKey => apiKey.BaseUrl.Equals(url));

        }
    }
}
