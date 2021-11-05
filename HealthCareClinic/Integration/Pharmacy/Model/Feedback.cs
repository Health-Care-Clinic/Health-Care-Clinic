using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Pharmacy.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime TimeOfSending { get; set; }

        public Feedback()
        {

        }

        public Feedback(string text, int senderId, int receiverId, DateTime timeOfSending)
        {
            Text = text;
            SenderId = senderId;
            ReceiverId = receiverId;
            TimeOfSending = timeOfSending;
        }
    }
}
