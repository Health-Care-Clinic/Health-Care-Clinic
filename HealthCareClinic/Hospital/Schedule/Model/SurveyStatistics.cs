using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class SurveyStatistics
    {
        public List<SurveyCategoryStatistics> SurveyCategoriesStatistics { get; set; }

        public SurveyStatistics() {}

        public SurveyStatistics(List<SurveyCategoryStatistics> surveyCategoriesStatistics)
        {
            SurveyCategoriesStatistics = surveyCategoriesStatistics;
        }
    }
}
