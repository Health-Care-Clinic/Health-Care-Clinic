using Pharmacy.Feedbacks.Model;

namespace Pharmacy.Interfaces.Service
{
    public interface IFeedbackService : IService<Feedback>
    {
        void SaveChanges();
    }
}
