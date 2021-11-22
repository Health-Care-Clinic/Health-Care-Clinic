using ClinicCore.Storages;
using Integration.Interface.Repository;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public IntegrationDbContext IntegrationDbContext
        {
            get { return Context as IntegrationDbContext; }
        }

        public List<Feedback> GetAllFeedbacksBySenderId(int id)
        {
            List<Feedback> feedbacks = new List<Feedback>();
            IntegrationDbContext.Feedbacks.Where(feedback => feedback.SenderId == id).ToList().ForEach(feedback => feedbacks.Add(feedback));
            return feedbacks;
        }

        public Feedback GetBySenderId(int id)
        {
            return IntegrationDbContext.Feedbacks.FirstOrDefault(feedback => feedback.SenderId == id);
        }
    }
}
