using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.DTO
{
    public class FeedbackWithReplyDTO
    {
        public string FeedbackText { get; set; }
        public string ReplyText { get; set; }
        public int PharmacyId { get; set; }
        public String PharmacyName { get; set; }
        public DateTime TimeOfSendingFeedback { get; set; }
        public DateTime TimeOfSendingReply { get; set; }
    }
}
