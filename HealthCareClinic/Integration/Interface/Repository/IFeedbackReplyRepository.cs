using ClinicCore.Storages;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Interface.Repository
{
    public interface IFeedbackReplyRepository : IRepository<FeedbackReply>
    {
        FeedbackReply GetFeedbackReplyByFeedbackId(int id);
    }
}
