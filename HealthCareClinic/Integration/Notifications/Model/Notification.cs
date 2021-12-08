using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Notifications.Model
{
    public class Notification
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime Date { get; set; }
        public Boolean Seen { get; set; }


        public Notification() { }

        public Notification(string title, string content)
        {
            Title = title;
            Content = content;
            Date = DateTime.Now;
            Seen = false;
        }

        public Notification(string title, string content, DateTime date, bool seen)
        {
            Title = title;
            Content = content;
            Date = date;
            Seen = seen;
        }
    }
}