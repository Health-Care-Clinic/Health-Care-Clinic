﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class FeedbackMessageDTO
    {
        public int Id { get; set; }
        public String Date { get; set; }
        public String Text { get; set; }
        public bool IsAnonymous { get; set; }
        public String Identity { get; set; }
        public bool CanBePublished { get; set; }
        public bool IsPublished { get; set; }

        public FeedbackMessageDTO() { }

        public FeedbackMessageDTO(int id, String dateAsString, string text, bool isAnonymous, String identity,
            bool canBePublished, bool isPublished)
        {
            Id = id;
            Date = dateAsString;
            Text = text;
            IsAnonymous = isAnonymous;
            Identity = identity;
            CanBePublished = canBePublished;
            IsPublished = isPublished;
        }
    }
}
