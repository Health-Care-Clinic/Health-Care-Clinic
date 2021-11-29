using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Storages;
using Integration.Interface.Repository;
using Integration.Pharmacy.Model;

namespace Integration.Repository
{
    public class MedConsumptionRepository : Repository<MedicationConsumption>, IMedConsumptionRepository
    {
        public MedConsumptionRepository(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public IntegrationDbContext IntegrationDbContext
        {
            get { return Context as IntegrationDbContext; }
        }

    }
}
