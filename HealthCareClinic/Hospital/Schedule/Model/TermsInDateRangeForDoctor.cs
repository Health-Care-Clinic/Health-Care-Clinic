using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class TermsInDateRangeForDoctor
    {
        public Doctor Doctor { get; set; }
        public List<DateTime> Terms { get; set; }

        public TermsInDateRangeForDoctor() {}

        public TermsInDateRangeForDoctor(Doctor doctor, List<DateTime> terms)
        {
            Doctor = doctor;
            Terms = terms;
        }
    }
}
