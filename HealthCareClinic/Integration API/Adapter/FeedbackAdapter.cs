using Integration_API.DTO;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.Adapter
{
    public class FeedbackAdapter
    {
        public static Feedback FeedbackDtoToFeedback(FeedbackDTO dto)
        {
            Feedback feedback = new Feedback();
            feedback.Text = dto.Text;
            feedback.SenderId = dto.SenderId;
            feedback.ReceiverId = dto.ReceiverId;
            feedback.TimeOfSending = dto.TimeOfSending;

            return feedback;
        }

        public static FeedbackDTO FeedbackToFeedbackDto(Feedback feedback)
        {
            FeedbackDTO dto = new FeedbackDTO();
            dto.Text = feedback.Text;
            dto.SenderId = feedback.SenderId;
            dto.ReceiverId = feedback.ReceiverId;
            dto.TimeOfSending = feedback.TimeOfSending;

            return dto;
        }
    }
}
