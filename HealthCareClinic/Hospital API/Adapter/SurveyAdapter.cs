﻿using Hospital.Schedule.Model;
using Hospital.Schedule.Service;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class SurveyAdapter
    {
        public static SurveyDTO SurveyToDto(Survey survey)
        {
            SurveyDTO dto = new SurveyDTO();
            dto.Id = survey.Id;
            dto.Done = survey.Done;
            dto.AppointmentId = survey.AppointmentId;
            dto.SurveyCategories = new List<SurveyCategoryDTO>();

            if (survey.SurveyCategories == null)
                dto.SurveyCategories = null;
            else
            {
                List<SurveyCategory> cat = survey.SurveyCategories.ToList();
                foreach (SurveyCategory c in cat)
                    dto.SurveyCategories.Add(SurveyCategoryToDto(c));
            }           

            return dto;
        }
        public static SurveyDTOForAppointment SurveyToSurveyDtoForAppointment(Survey survey)
        {
            SurveyDTOForAppointment dto = new SurveyDTOForAppointment();
            dto.Id = survey.Id;
            dto.Done = survey.Done;
            dto.AppointmentId = survey.AppointmentId;

            return dto;

        }
            public static SurveyCategoryDTO SurveyCategoryToDto(SurveyCategory category)
        {
            SurveyCategoryDTO dto = new SurveyCategoryDTO();
            dto.Id = category.Id;
            dto.Name = category.Name;
            dto.SurveyId = category.Survey.Id;
            dto.SurveyQuestions = new List<SurveyQuestionDTO>();

            List<SurveyQuestion> ques = category.SurveyQuestions.ToList();
            foreach (SurveyQuestion q in ques)
                dto.SurveyQuestions.Add(SurveyQuestionToDto(q));

            return dto;
        }

        public static SurveyQuestionDTO SurveyQuestionToDto(SurveyQuestion question)
        {
            SurveyQuestionDTO dto = new SurveyQuestionDTO();
            dto.Id = question.Id;
            dto.Content = question.Content;
            dto.Grade = question.Grade;
            dto.SurveyCategoryId = question.SurveyCategoryId;

            return dto;
        }

        public static void DtoToSurvey(SurveyDTO dto, ISurveyService surveyService)
        {
            Survey survey = surveyService.GetOneById(dto.Id);

            foreach (var cd in survey.SurveyCategories.Zip(dto.SurveyCategories, Tuple.Create))
                foreach (var qd in cd.Item1.SurveyQuestions.Zip(cd.Item2.SurveyQuestions, Tuple.Create))
                    surveyService.ModifyGrade(qd.Item1.Id, qd.Item2.Grade);

        }
    }
}
