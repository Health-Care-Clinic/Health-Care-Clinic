using Pharmacy.DTO;
using Pharmacy.Model;

namespace Pharmacy.Adapter
{
    public class FeedbackReplyAdapter
    {
        public static FeedbackReply FeedbackReplyDtoToFeedbackReply(FeedbackReplyDTO dto)
        {
            FeedbackReply feedbackReply = new FeedbackReply();
            feedbackReply.Text = dto.Text;
            feedbackReply.SenderId = dto.SenderId;
            feedbackReply.ReceiverId = dto.ReceiverId;
            feedbackReply.TimeOfSending = dto.TimeOfSending;
            feedbackReply.FeedbackId = dto.FeedbackId;

            return feedbackReply;
        }

        public static FeedbackReplyDTO FeedbackReplyToFeedbackReplyDto(FeedbackReply feedbackReply)
        {
            FeedbackReplyDTO dto = new FeedbackReplyDTO();
            dto.Text = feedbackReply.Text;
            dto.SenderId = feedbackReply.SenderId;
            dto.ReceiverId = feedbackReply.ReceiverId;
            dto.TimeOfSending = feedbackReply.TimeOfSending;
            dto.FeedbackId = feedbackReply.FeedbackId;

            return dto;
        }
    }
}
