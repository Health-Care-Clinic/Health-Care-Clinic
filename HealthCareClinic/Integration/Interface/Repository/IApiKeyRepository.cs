using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Storages;
using Integration.ApiKeys.Model;

namespace Integration.Interface.Repository
{
    public interface IApiKeyRepository : IRepository<ApiKey>
    {
        ApiKey GetByName(string name);
        ApiKey GetByUrl(string url);
    }
}
