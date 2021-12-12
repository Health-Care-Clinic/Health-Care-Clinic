﻿using Hospital.Schedule.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class FeedbackMessageAdapter
    {
        public static FeedbackMessage FeedbackMessageDTOToFeedbackMessage(FeedbackMessageDTO dto)
        {
            FeedbackMessage feedbackMessage = new FeedbackMessage();

            feedbackMessage.Id = dto.Id;
            feedbackMessage.Date = ConvertToDate(dto.Date);
            feedbackMessage.Text = dto.Text;
            feedbackMessage.IsAnonymous = dto.IsAnonymous;
            feedbackMessage.Identity = dto.Identity;
            feedbackMessage.CanBePublished = dto.CanBePublished;
            feedbackMessage.IsPublished = dto.IsPublished;

            return feedbackMessage;
        }

        public static FeedbackMessageDTO FeedbackMessageToFeedbackMessageDTO(FeedbackMessage feedbackMessage)
        {
            FeedbackMessageDTO dto = new FeedbackMessageDTO();

            dto.Id = feedbackMessage.Id;
            dto.Date = ConvertToString(feedbackMessage.Date);
            dto.Text = feedbackMessage.Text;
            dto.IsAnonymous = feedbackMessage.IsAnonymous;
            dto.Identity = feedbackMessage.Identity;
            dto.CanBePublished = feedbackMessage.CanBePublished;
            dto.IsPublished = feedbackMessage.IsPublished;

            return dto;
        }
        public static List<FeedbackMessageDTO> FeedbackMessageListToFeedbackMessageDTOList(List<FeedbackMessage> feedbacks)
        {
            List<FeedbackMessageDTO> feedbacksDTO = new List<FeedbackMessageDTO>();
            foreach (FeedbackMessage feedback in feedbacks)
                feedbacksDTO.Add(FeedbackMessageToFeedbackMessageDTO(feedback));

            return feedbacksDTO;
        }

        private static DateTime ConvertToDate(String feedbackDateAsString)
        {
            String[] mainParts = feedbackDateAsString.Split('T');

            String[] dateParts = mainParts[0].Split('-');
            int year = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int day = int.Parse(dateParts[2]);

            String[] timeParts = mainParts[1].Split(':');
            int hour = int.Parse(timeParts[0]);
            int minute = int.Parse(timeParts[1]);
            int second = int.Parse(timeParts[2].Substring(0, 2));

            DateTime feedbackDate = new DateTime(year, month, day, hour, minute, second);

            return feedbackDate;
        }

        private static String ConvertToString(DateTime feedbackDate)
        {
            String feedbackDateAsString = feedbackDate.ToString();

            return feedbackDateAsString;
        }
    }
}