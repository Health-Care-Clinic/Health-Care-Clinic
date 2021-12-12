using System;
using System.Collections.Generic;
using Pharmacy.Feedbacks.Model;
using Pharmacy.Model;
using Pharmacy.Repository;
using Pharmacy.Service;

namespace Pharmacy.Feedbacks.Service
{
    public class FeedbackReplyService : IFeedbackReplyService
    {
        private readonly IFeedbackReplyRepository _feedbackReplyRepository;

        public FeedbackReplyService(IFeedbackReplyRepository feedbackReplyRepository)
        {
            _feedbackReplyRepository = feedbackReplyRepository;
        }

        public void Add(FeedbackReply entity)
        {
            _feedbackReplyRepository.Add(entity);
        }

        public IEnumerable<FeedbackReply> GetAll()
        {
            throw new NotImplementedException();
        }

        public FeedbackReply GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(FeedbackReply entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _feedbackReplyRepository.Save();
        }
    }
}
