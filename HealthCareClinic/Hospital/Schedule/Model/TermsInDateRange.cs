using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Model
{
    public class TermsInDateRange
    {
        public Doctor InitiallyPickedDoctor { get; set; }
        public string Specialty { get; set; }
        public DateTime BeginningDateTime { get; set; }
        public DateTime EndingDateTime { get; set; }
        public List<TermsInDateRangeForDoctor> TermsInDateRangeForDoctors { get; set; }

        public TermsInDateRange() {}

        public TermsInDateRange(Doctor initiallyPickedDoctor, string specialty, DateTime beginningDateTime, DateTime endingDateTime, List<TermsInDateRangeForDoctor> termsInDateRangeForDoctors)
        {
            InitiallyPickedDoctor = initiallyPickedDoctor;
            Specialty = specialty;
            BeginningDateTime = beginningDateTime;
            EndingDateTime = endingDateTime;
            TermsInDateRangeForDoctors = termsInDateRangeForDoctors;
        }

        public TermsInDateRange(TermsInDateRange termsInDateRange)
        {
            InitiallyPickedDoctor = termsInDateRange.InitiallyPickedDoctor;
            Specialty = termsInDateRange.Specialty;
            BeginningDateTime = termsInDateRange.BeginningDateTime;
            EndingDateTime = termsInDateRange.EndingDateTime;
            TermsInDateRangeForDoctors = termsInDateRange.TermsInDateRangeForDoctors;
        }
    }
}
