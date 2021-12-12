using Pharmacy.Feedbacks.Model;
using Pharmacy.Model;
using Pharmacy.Repository;

namespace Pharmacy.Feedbacks.Repository
{
    public class FeedbackReplyRepository : Repository<FeedbackReply>, IFeedbackReplyRepository
    {
        public FeedbackReplyRepository(PharmacyDbContext dbContext) : base(dbContext)
        {
        }

        public PharmacyDbContext PharmacyDbContext
        {
            get { return Context as PharmacyDbContext; }
        }
    }
}
