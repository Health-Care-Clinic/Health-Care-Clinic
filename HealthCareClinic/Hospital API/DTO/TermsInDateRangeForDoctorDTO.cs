using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class TermsInDateRangeForDoctorDTO
    {
        public DoctorWithSpecialtyDTO Doctor { get; set; }
        public List<string> Terms { get; set; }

        public TermsInDateRangeForDoctorDTO() { }

        public TermsInDateRangeForDoctorDTO(DoctorWithSpecialtyDTO doctor, List<string> terms)
        {
            Doctor = doctor;
            Terms = terms;
        }
    }
}
