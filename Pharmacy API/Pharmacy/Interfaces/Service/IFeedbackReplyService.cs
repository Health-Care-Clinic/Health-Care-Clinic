using Pharmacy.Feedbacks.Model;

namespace Pharmacy.Interfaces.Service
{
    public interface IFeedbackReplyService : IService<FeedbackReply>
    {
        void SaveChanges();
    }
}
