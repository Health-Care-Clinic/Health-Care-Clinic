using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class SurveyQuestion
    {
        public string Content { get; set; }
        public int Grade { get; set; }


        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }


        public SurveyQuestion() { }

        public SurveyQuestion(string content, int grade)
        {
            Content = content;
            Grade = grade;
        }
    }
}
