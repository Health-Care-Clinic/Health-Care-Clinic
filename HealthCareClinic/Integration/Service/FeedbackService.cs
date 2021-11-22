using Integration.ApiKeys.Model;
using Integration.DTO;
using Integration.Interface.Repository;
using Integration.Interface.Service;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IFeedbackReplyRepository _feedbackReplyRepository;
        private readonly IApiKeyRepository _apiKeyRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository, IFeedbackReplyRepository feedbackReplyRepository, 
            IApiKeyRepository apiKeyRepository)
        {
            _feedbackRepository = feedbackRepository;
            _feedbackReplyRepository = feedbackReplyRepository;
            _apiKeyRepository = apiKeyRepository;
        }

        public void Add(Feedback entity)
        {
            _feedbackRepository.Add(entity);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback GetFeedbackBySenderId(int id)
        {
            return _feedbackRepository.GetBySenderId(id);
        }

        public List<FeedbackWithReplyDTO> GetFeedbacksWithReply(int id)
        {
            List<FeedbackWithReplyDTO> feedbacksWithReplies = new List<FeedbackWithReplyDTO>();
            List<Feedback> feedbacks = _feedbackRepository.GetAllFeedbacksBySenderId(id);
            foreach (Feedback f in feedbacks)
            {
                FeedbackReply feedbackReply = _feedbackReplyRepository.GetFeedbackReplyByFeedbackId(f.Id);
                FeedbackWithReplyDTO feedbackWithReply = new FeedbackWithReplyDTO();
                feedbackWithReply.FeedbackText = f.Text;
                feedbackWithReply.TimeOfSendingFeedback = f.TimeOfSending;
                feedbackWithReply.PharmacyId = f.ReceiverId;
                ApiKey pharmacy = _apiKeyRepository.GetById(f.ReceiverId);
                if (pharmacy != null)
                {
                    feedbackWithReply.PharmacyName = pharmacy.Name;
                }
                if (feedbackReply != null)
                {
                    feedbackWithReply.ReplyText = feedbackReply.Text;
                    feedbackWithReply.TimeOfSendingReply = feedbackReply.TimeOfSending;
                }

                feedbacksWithReplies.Add(feedbackWithReply);
            }
            return feedbacksWithReplies;
        }

        public Feedback GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _feedbackRepository.Save();
        }
    }
}
