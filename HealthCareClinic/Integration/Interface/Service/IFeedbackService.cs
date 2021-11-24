using ClinicCore.Service;
using Integration.DTO;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Interface.Service
{
    public interface IFeedbackService : IService<Feedback>
    {
        Feedback GetFeedbackBySenderId(int id);
        List<FeedbackWithReplyDTO> GetFeedbacksWithReply(int id);
        void SaveChanges();
    }
}
