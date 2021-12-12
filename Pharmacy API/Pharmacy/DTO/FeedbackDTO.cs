﻿using System;

namespace Pharmacy.DTO
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime TimeOfSending { get; set; }

        public FeedbackDTO()
        {

        }

        public FeedbackDTO(int id, string text, int senderId, int receiverId, DateTime timeOfSending)
        {
            Id = id;
            Text = text;
            SenderId = senderId;
            ReceiverId = receiverId;
            TimeOfSending = timeOfSending;
        }
    }
}
