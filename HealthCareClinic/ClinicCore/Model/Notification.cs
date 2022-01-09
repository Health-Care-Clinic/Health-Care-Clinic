using System;
using System.Collections.Generic;

namespace Model
{
    public class Notification
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime LastChanged { get; set; }
        public List<int> Recipients { get; set; } = new List<int>();

        public Notification(string title, string text, DateTime datePosted)
        {
            Title = title;
            Text = text;
            DatePosted = datePosted;
            LastChanged = datePosted;
            GenerateId();
        }
        public Notification(string title, string text, DateTime datePosted, DateTime lastChanged) : this(title, text, datePosted)
        {
            LastChanged = lastChanged;
            GenerateId();
        }

        public Notification(string title, string text, DateTime datePosted, DateTime lastChanged, List<int> recipients, int id) : this(title, text, datePosted)
        {
            LastChanged = lastChanged;
            Recipients = recipients;
            Id = id;
        }

        public Notification()
        {
            GenerateId();
        }

        private void GenerateId() 
        {
            Random rand = new Random();
            this.Id = rand.Next(1, 100000);
        }

    }
}
