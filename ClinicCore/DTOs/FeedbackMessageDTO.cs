﻿using System;

namespace ClinicCore.DTOs
{
    public class FeedbackMessageDTO
    {
        public long Id { get; set; }
        public String DateAsString { get; set; }
        public String Text { get; set; }
        public bool IsAnonymous { get; set; }
        public String Identity { get; set; }
        public bool CanBePublished { get; set; }
        public bool IsPublished { get; set; }

        public FeedbackMessageDTO() { }

        public FeedbackMessageDTO(long id, String dateAsString, string text, bool isAnonymous, String identity, 
            bool canBePublished, bool isPublished)
        {
            Id = id;
            DateAsString = dateAsString;
            Text = text;
            IsAnonymous = isAnonymous;
            Identity = identity;
            CanBePublished = canBePublished;
            IsPublished = isPublished;
        }
    }
}
