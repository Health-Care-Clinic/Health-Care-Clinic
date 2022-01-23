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

        public AccountInfo AccountInfo { get; set; }

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

        public Patient(int id, MedicalRecord medicalRecord, AccountInfo accountInfo)
        {
            Id = id;
            MedicalRecord = medicalRecord;
            AccountInfo = accountInfo;
        }

        public Patient(int id, string name, string surname, string gender, string bloodType, DateTime birthDate, 
            string address, string phone, string email, string username, string password, string ParentName, 
            List<AllergenForPatient> alergies, string employmentStatus, bool isActive)
        {
            Id = id;

            PersonalInfo personalInfo = new PersonalInfo(name, surname, birthDate, phone, email, gender, address, 
                "Test roditelj", employmentStatus);
            MedicalRecord = new MedicalRecord(id, alergies, bloodType, personalInfo);

            AccountInfo = new AccountInfo(DateTime.Now, false, isActive, username, password);
        }

        public Patient(string username, string password)
        {
            AccountInfo = new AccountInfo(username, password);
        }
    }
}
