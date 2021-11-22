using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class SurveyQuestionDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Grade { get; set; }

        public int SurveyCategoryId { get; set; }

        public SurveyQuestionDTO()
        {
        }
    }
}
