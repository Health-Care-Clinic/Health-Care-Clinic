using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.Model;

namespace Pharmacy.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(PharmacyDbContext dbContext) : base(dbContext)
        {
        }
        public PharmacyDbContext PharmacyDbContext
        {
            get { return Context as PharmacyDbContext; }
        }
    }
}
