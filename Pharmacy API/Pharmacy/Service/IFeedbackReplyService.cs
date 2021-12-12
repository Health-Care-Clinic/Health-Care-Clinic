using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.Feedbacks.Model;

namespace Pharmacy.Service
{
    public interface IFeedbackReplyService : IService<FeedbackReply>
    {
        void SaveChanges();
    }
}
