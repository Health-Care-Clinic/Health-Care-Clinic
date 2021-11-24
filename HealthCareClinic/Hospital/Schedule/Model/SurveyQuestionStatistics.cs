using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class SurveyQuestionStatistics
    {
        public string Content { get; set; }
        public List<int> NumberOfAssignsForEachGrade { get; set; }
        public double AverageGrade { get; set; }
        public string SurveyCategoryName { get; set; }

        public SurveyQuestionStatistics() {}

        public SurveyQuestionStatistics(string content, List<int> numberOfAssignsForEachGrade, double averageGrade, 
            string surveyCategoryName)
        {
            Content = content;
            NumberOfAssignsForEachGrade = numberOfAssignsForEachGrade;
            AverageGrade = averageGrade;
            SurveyCategoryName = surveyCategoryName;
        }
    }
}
