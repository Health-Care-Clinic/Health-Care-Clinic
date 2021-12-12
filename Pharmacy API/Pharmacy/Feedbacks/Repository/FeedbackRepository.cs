using Pharmacy.Feedbacks.Model;
using Pharmacy.Model;
using Pharmacy.Repository;

namespace Pharmacy.Feedbacks.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(PharmacyDbContext dbContext) : base(dbContext)
        {
        }

        public PharmacyDbContext PharmacyDbContext
        {
            get { return Context as PharmacyDbContext; }
        }
    }
}
