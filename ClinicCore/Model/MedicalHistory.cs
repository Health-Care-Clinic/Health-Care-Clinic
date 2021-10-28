using System.Collections.Generic;

namespace Model
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public List<Prescription> Prescription { get; set; }
        public List<Test> Test { get; set; }
        public List<Report> Reports { get; set; }
        public List<Hospitalization> Hospitalization { get; set; }
        public List<Therapy> Therapies { get; set; }

        public MedicalHistory(int id)
        {
            Id = id;
            Prescription = new List<Prescription>();
            Test = new List<Test>();
            Reports = new List<Report>();
            Hospitalization = new List<Hospitalization>();
            Therapies = new List<Therapy>();
        }

    }
}
