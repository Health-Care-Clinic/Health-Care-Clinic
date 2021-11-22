using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class SurveyDTO
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public bool Done { get; set; }
        public List<SurveyCategoryDTO> SurveyCategories { get; set; }

        public SurveyDTO()
        {
        }
    }
}
