using System;

namespace Integration.DTO
{
    public class MessageDTO
    {
        public String MessageText { get; set; }
        public MessageDTO() { }
        public MessageDTO(String messageText)
        {
            this.MessageText = messageText;
        }
    }
}
