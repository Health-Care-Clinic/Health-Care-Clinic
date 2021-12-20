using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class TermsInDateRangeDTO
    {
        public DoctorWithSpecialtyDTO InitiallyPickedDoctor { get; set; }
        public string Specialty { get; set; }
        public string BeginningDateTime { get; set; }
        public string EndingDateTime { get; set; }
        public List<TermsInDateRangeForDoctorDTO> TermsInDateRangeForDoctors { get; set; }

        public TermsInDateRangeDTO() {}

        public TermsInDateRangeDTO(DoctorWithSpecialtyDTO initiallyPickedDoctor, string specialty, string beginningDateTime, string endingDateTime, List<TermsInDateRangeForDoctorDTO> termsInDateRangeForDoctors)
        {
            InitiallyPickedDoctor = initiallyPickedDoctor;
            Specialty = specialty;
            BeginningDateTime = beginningDateTime;
            EndingDateTime = endingDateTime;
            TermsInDateRangeForDoctors = termsInDateRangeForDoctors;
        }
    }
}
