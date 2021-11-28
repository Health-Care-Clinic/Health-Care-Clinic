using Pharmacy.Model;
using Pharmacy.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public void Add(Feedback entity)
        {
            _feedbackRepository.Add(entity);
        }

        public IEnumerable<Feedback> GetAll()
        {
            throw new NotImplementedException();
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
