using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Pharmacy.Model
{
    public class FeedbackReply
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime TimeOfSending { get; set; }
        public int FeedbackId { get; set; }

        public FeedbackReply()
        {

        }

        public FeedbackReply(string text, int senderId, int receiverId, DateTime timeOfSending, int feedbackId)
        {
            Text = text;
            SenderId = senderId;
            ReceiverId = receiverId;
            TimeOfSending = timeOfSending;
            FeedbackId = feedbackId;
        }
    }
}
