using System;

namespace Pharmacy.ApiKeys.Model
{
    public class Message
    {
        public int Id { get; set; }
        public String Sender { get; set; }
        public String MessageText { get; set; }
        public String Receiver { get; set; }

        public Message() { }

        public Message(string sender, string messageText, string receiver)
        {
            Sender = sender;
            MessageText = messageText;
            Receiver = receiver;
        }
    }
}
