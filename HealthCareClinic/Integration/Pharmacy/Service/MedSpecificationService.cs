using System.Linq;
using Integration.ApiKeys.Model;
using Integration.DTO;

namespace Integration.Pharmacy.Service
{
    public class MedSpecificationService
    {
        private readonly IntegrationDbContext _dbContext;

        public MedSpecificationService(IntegrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
