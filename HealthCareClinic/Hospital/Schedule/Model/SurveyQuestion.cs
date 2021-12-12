using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class SurveyQuestion
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int Grade { get; set; }

        public int SurveyCategoryId { get; set; }

        [ForeignKey("SurveyCategoryId")]
        public virtual SurveyCategory SurveyCategory { get; set; }


        public SurveyQuestion() { }

        public SurveyQuestion(string content, int grade)
        {
            Content = content;
            Grade = grade;
        }
    }
}
