using ClinicCore.Service;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Interface.Service
{
    public interface IFeedbackReplyService : IService<FeedbackReply>
    {
        void SaveChanges();
    }
}
