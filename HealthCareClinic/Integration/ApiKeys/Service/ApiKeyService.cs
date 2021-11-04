using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.ApiKeys.Service
{
    public class ApiKeyService
    {
        private readonly IntegrationDbContext _dbContext;

        public ApiKeyService(IntegrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
