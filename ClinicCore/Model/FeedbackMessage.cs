using System;

namespace ClinicCore.Model
{
    public class FeedbackMessage
    {
        public String Text { get; set; }
        public DateTime DateSent { get; set; }

        public FeedbackMessage(string text, DateTime dateSent)
        {
            Text = text;
            DateSent = dateSent;
        }
    }
}
