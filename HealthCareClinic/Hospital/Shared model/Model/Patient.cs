using Hospital.Medical_records.Model;
using Hospital.Shared_model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual AccountInfo AccountInfo { get; set; }

        public virtual ICollection<AllergenForPatient> Allergens { get; set; }
        public string Hashcode { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        private Doctor doctor;
        public virtual Doctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                if (doctor == null || !doctor.Equals(value))
                {
                    if (doctor != null)
                    {
                        Doctor oldDoctor = doctor;
                        doctor = null;
                        oldDoctor.RemovePatient(this);
                    }
                    if (value != null)
                    {
                        doctor = value;
                        doctor.AddPatient(this);
                    }
                }
            }
        }

        public Patient() { }

        public Patient(int id, MedicalRecord medicalRecord, ContactInfo contactInfo, AccountInfo accountInfo, 
            ICollection<AllergenForPatient> alergies)
        {
            Id = id;
            MedicalRecord = medicalRecord;
            ContactInfo = contactInfo;
            AccountInfo = accountInfo;
            Allergens = alergies;
        }

        public Patient(int id, string name, string surname, string gender, string bloodType, DateTime birthDate, 
            string address, string phone, string email, string username, string password, string parentName, 
            List<AllergenForPatient> alergies, string employmentStatus, bool isActive)
        {
            Id = id;

            PersonalInfo personalInfo = new PersonalInfo(name, surname, birthDate, gender, parentName, employmentStatus);
            ContactInfo = new ContactInfo(phone, email, address);
            MedicalRecord = new MedicalRecord(id, bloodType, personalInfo);

            Allergens = alergies;

            AccountInfo = new AccountInfo(DateTime.Now, false, isActive, username, password);
        }

        public Patient(string username, string password)
        {
            AccountInfo = new AccountInfo(username, password);
        }
    }
}
