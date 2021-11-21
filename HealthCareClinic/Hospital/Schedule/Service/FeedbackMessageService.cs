using Hospital.Schedule.Repository;
using Hospital.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Shared_model.Interface;

namespace Hospital.Schedule.Service
{
    public class FeedbackMessageService : IFeedbackMessageService
    {
        private IFeedbackMessageRepository feedbackRepository;

        public FeedbackMessageService(IFeedbackMessageRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }



        public void Add(FeedbackMessage entity)
        {
            this.feedbackRepository.Add(entity);
        }

        public IEnumerable<FeedbackMessage> GetAll()
        {
            return this.feedbackRepository.GetAll();
        }

        public FeedbackMessage GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FeedbackMessage> GetPublished()
        {
            return this.feedbackRepository.GetPublished();
        }

        public void ModifyPublishable(int id)
        {
            this.feedbackRepository.ModifyPublishable(id);
        }

        public void Remove(FeedbackMessage entity)
        {
            throw new NotImplementedException();
        }
    }
}
