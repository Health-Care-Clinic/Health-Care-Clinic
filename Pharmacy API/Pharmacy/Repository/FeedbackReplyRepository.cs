using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Repository
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
