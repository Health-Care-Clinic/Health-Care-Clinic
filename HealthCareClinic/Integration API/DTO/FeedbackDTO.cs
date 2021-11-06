using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTO
{
    public class FeedbackDTO
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime TimeOfSending { get; set; }

        public FeedbackDTO()
        {

        }

        public FeedbackDTO(string text, int senderId, int receiverId, DateTime timeOfSending)
        {
            Text = text;
            SenderId = senderId;
            ReceiverId = receiverId;
            TimeOfSending = timeOfSending;
        }
    }
}
