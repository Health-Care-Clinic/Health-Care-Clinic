using System;

namespace DTOs
{
    public class HospitalizationDTO
    {
        public DateTime AdmissionDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Detail { get; set; }
        public int RoomID { get; set; }
        public int BedID { get; set; }
        public string Doctor { get; set; }
        public bool IsReleased { get; set; }

        public HospitalizationDTO(DateTime admissionDate, DateTime releaseDate, string detail, int roomID, int bedID, string doctor, bool released)
        {
            AdmissionDate = admissionDate;
            ReleaseDate = releaseDate;
            Detail = detail;
            RoomID = roomID;
            BedID = bedID;
            Doctor = doctor;
            IsReleased = released;
        }
    }
}
