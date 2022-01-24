using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Hospital.Medical_records.Model
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        public string BloodType { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }

        public MedicalRecord() { }
        
        public MedicalRecord(int id, string bloodType, PersonalInfo personalInfo)
        {
            Id = id;
            BloodType = bloodType;
            PersonalInfo = personalInfo;

            Validate();
        }

        private void Validate()
        {
            CheckIfBloodTypeMatchesPresetPattern();
        }

        private void CheckIfBloodTypeMatchesPresetPattern()
        {
            if (Regex.IsMatch(BloodType, @"^A[-\+]?$") || Regex.IsMatch(BloodType, @"^B[-\+]?$") 
                || Regex.IsMatch(BloodType, @"^AB[-\+]?$") || Regex.IsMatch(BloodType, @"^0[-\+]?$"))
                return;
            else
                throw new ArgumentException("Blood type must be one of the following: 'A+'; 'A-'; 'B+'; 'B-'; 'AB+'; 'AB-'; " +
                    "'0+'; '0-'.");
        }
    }
}
