using System;
using System.Collections.Generic;
using Integration.Interface.Repository;
using Integration.Interface.Service;
using Integration.Pharmacy.Model;

namespace Integration.Pharmacy.Service
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
