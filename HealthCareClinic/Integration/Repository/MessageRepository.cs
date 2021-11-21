using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Storages;
using Integration.ApiKeys.Model;
using Integration.Interface.Repository;

namespace Integration.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public IntegrationDbContext IntegrationDbContext
        {
            get { return Context as IntegrationDbContext; }
        }
    }
}
