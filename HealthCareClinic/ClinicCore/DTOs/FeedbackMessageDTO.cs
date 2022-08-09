using System;

namespace ClinicCore.DTOs
{
    public class FeedbackMessageDTO
    {
        public long Id { get; set; }
        public String Date { get; set; }
        public String Text { get; set; }
        public bool IsAnonymous { get; set; }
        public String Identity { get; set; }
        public bool CanBePublished { get; set; }
        public bool IsPublished { get; set; }

        public FeedbackMessageDTO() { }

        public FeedbackMessageDTO(long id, String date, string text, bool isAnonymous, String identity,
            bool canBePublished, bool isPublished)
        {
            Id = id;
            Date = date;
            Text = text;
            IsAnonymous = isAnonymous;
            Identity = identity;
            CanBePublished = canBePublished;
            IsPublished = isPublished;
        }
    }
}
