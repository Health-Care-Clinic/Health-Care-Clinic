using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Medical_records.Model
{
    public class ProfilePicture
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public String Picture { get; set; }

        public ProfilePicture() { }

        public ProfilePicture(int patientId, String picture)
        {
            PatientId = patientId;
            Picture = picture;
        }
    }
}
