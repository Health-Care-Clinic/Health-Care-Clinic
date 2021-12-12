using Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicCore.Model
{
    public class FeedbackMessage
    {
        //[Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public String Text { get; set; }
        public bool IsAnonymous { get; set; }
        public String Identity { get; set; }
        public bool CanBePublished { get; set; }
        public bool IsPublished { get; set; }

        public FeedbackMessage() { }

        public FeedbackMessage(long id, DateTime date, string text, bool isAnonymous, String identity, bool canBePublished,
            bool isPublished)
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
