using Hospital.Schedule.Model;
using Hospital.Shared_model.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Hospital.Mapper;
using System.Linq;

namespace Hospital.Schedule.Repository
{
    public class FeedbackMessageRepository : Repository<FeedbackMessage>, IFeedbackMessageRepository
    {
        public FeedbackMessageRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public List<FeedbackMessage> GetPublished()
        {
            return HospitalDbContext.FeedbackMessages.Where(feedbackMessage => feedbackMessage.IsPublished == true).ToList();
        }

        public void ModifyPublishable(int id)
        {
            FeedbackMessage feedbackMessage = GetById(id);
            feedbackMessage.IsPublished = !feedbackMessage.IsPublished;
            Save();
        }
    }
}
