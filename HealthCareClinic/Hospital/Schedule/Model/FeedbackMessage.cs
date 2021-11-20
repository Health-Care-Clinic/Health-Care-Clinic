using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class FeedbackMessage
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Text { get; set; }
        public bool IsAnonymous { get; set; }
        public String Identity { get; set; }
        public bool CanBePublished { get; set; }
        public bool IsPublished { get; set; }

        public FeedbackMessage() { }

        public FeedbackMessage(int id, DateTime date, string text, bool isAnonymous, String identity, bool canBePublished,
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
