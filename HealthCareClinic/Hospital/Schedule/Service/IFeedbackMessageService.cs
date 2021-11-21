using Hospital.Schedule.Model;
using Hospital.Shared_model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Service
{
    public interface IFeedbackMessageService : IService<FeedbackMessage>
    {
        List<FeedbackMessage> GetPublished();
        void ModifyPublishable(int id);
    }
}
