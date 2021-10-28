using System;

namespace ClinicCore.DTOs
{
    public class FeedbackMessageDTO
    {
        public String Text { get; set; }
        public DateTime DateSent { get; set; }

        public FeedbackMessageDTO(string text, DateTime dateSent)
        {
            Text = text;
            DateSent = dateSent;
        }

        public FeedbackMessageDTO()
        { 
        }
    }
}
