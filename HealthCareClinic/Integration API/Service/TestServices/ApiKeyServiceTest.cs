using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.Service.TestServices
{
    public class ApiKeyServiceTest
    {
        public int GetNumberOfApiKeys(IMyDbContext myDbContext)
        {
            return myDbContext.GetApiKeys().Count;
        }
    }
}
