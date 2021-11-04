using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy
{
    public class ApiKeyService
    {
        private readonly PharmacyDbContext _dbContext;

        public ApiKeyService(PharmacyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
