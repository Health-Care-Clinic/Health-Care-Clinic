using ClinicCore.Storages;
using Integration.Interface.Repository;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.Repository
{
    public class FeedbackReplyRepository : Repository<FeedbackReply>, IFeedbackReplyRepository
    {
        public FeedbackReplyRepository(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public IntegrationDbContext IntegrationDbContext
        {
            get { return Context as IntegrationDbContext; }
        }

        public FeedbackReply GetFeedbackReplyByFeedbackId(int id)
        {
            return IntegrationDbContext.FeedbackReplies.SingleOrDefault(feedbackReply => feedbackReply.FeedbackId == id);
        }
    }
}
