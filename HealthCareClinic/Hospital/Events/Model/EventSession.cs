using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Events.Model
{
    public class EventSession
    {
        [Key]
        public int Id { get; set; }

        public bool ResultedInSucces { get; set; }

        public int UserId { get; set; }

        public EventSession() { }

        public EventSession(bool succes, int userId)
        {
            ResultedInSucces = succes;
            UserId = userId;
        }
    }
}
