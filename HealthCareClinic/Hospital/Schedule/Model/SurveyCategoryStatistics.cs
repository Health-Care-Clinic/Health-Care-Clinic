using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class SurveyCategoryStatistics
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }
        public List<SurveyQuestionStatistics> SurveyQuestionsStatistics { get; set; }

        public SurveyCategoryStatistics() {}

        public SurveyCategoryStatistics(string name, double averageGrade, 
            List<SurveyQuestionStatistics> surveyQuestionsStatistics)
        {
            Name = name;
            AverageGrade = averageGrade;
            SurveyQuestionsStatistics = surveyQuestionsStatistics;
        }
    }
}
