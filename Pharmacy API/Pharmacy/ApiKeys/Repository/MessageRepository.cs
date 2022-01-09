using Pharmacy.ApiKeys.Model;
using Pharmacy.Interfaces.Repository;

namespace Pharmacy.ApiKeys.Repository
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
