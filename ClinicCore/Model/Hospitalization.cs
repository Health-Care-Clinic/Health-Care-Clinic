using Newtonsoft.Json;
using System;

namespace Model
{
    public class Hospitalization
    {
        public DateTime AdmissionDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Detail { get; set; }
        public Room Room { get; set; }
        public Bed Bed { get; set; }
        public string Doctor { get; set; }
        public bool IsReleased { get; set; }

        [JsonConstructor]
        public Hospitalization(DateTime admissionDate, DateTime releaseDate, string doctor, Room room, Bed bed, string details)
        {
            IsReleased = false;
            Doctor = doctor;
            AdmissionDate = admissionDate;
            ReleaseDate = releaseDate;
            Detail = details;
            Room = room;
            this.Bed = bed;
        }

        public Hospitalization(DateTime admissionDate, DateTime releaseDate, string detail, string doctor, bool released, Room room, Bed bed)
        {
            IsReleased = released;
            Doctor = doctor;
            AdmissionDate = admissionDate;
            ReleaseDate = releaseDate;
            Detail = detail;
            Room = room;
            this.Bed = bed;
        }
    }
}