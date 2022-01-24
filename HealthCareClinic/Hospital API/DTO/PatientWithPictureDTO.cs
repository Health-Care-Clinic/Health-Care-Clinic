using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class PatientWithPictureDTO
    {
        public PatientDTO Patient { get; set; }

        public String ProfilePicture { get; set; }

        public PatientWithPictureDTO() { }

        public PatientWithPictureDTO(PatientDTO patient, String picture)
        {
            Patient = patient;
            ProfilePicture = picture;
        }

    }
}
