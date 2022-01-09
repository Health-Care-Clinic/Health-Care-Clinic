using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public String Content { get; set; }
        public int UserId { get; set; }

        public EventDTO() { }

        public EventDTO(int id, DateTime timestamp, string content, int userId)
        {
            Id = id;
            Timestamp = timestamp;
            Content = content;
            UserId = userId;
        }
    }
}
