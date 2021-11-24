using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class SurveyCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SurveyQuestionDTO> SurveyQuestions { get; set; }
        public int SurveyId { get; set; }

        public SurveyCategoryDTO()
        {
        }
    }
}
