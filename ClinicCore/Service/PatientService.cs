using ClinicCore.Model;
using ClinicCore.Service;
using ClinicCore.Storages;
using Model;
using System;
using System.Collections.Generic;

namespace Service
{
    public class PatientService 
    {
        //private PatientFileStorage pfs = new PatientFileStorage();
        public List<Patient> AllPatients { get; set; }
        public IStorageFactory<PatientFileStorage> patientFileStorageFactory;
        public PatientFileStorage PatientStorage { get; set; }

        private static PatientService instance = null;
        public static PatientService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PatientService();
                }
                return instance;
            }
        }

        private PatientService()
        {
            patientFileStorageFactory = new PatientFileStorageFactory();
            PatientStorage = patientFileStorageFactory.GetStorage();
            AllPatients = PatientStorage.GetAll();
            UpdatePatientTrollMechanism();
        }

        public void AddPatient(Patient patient)
        {
            ChartService.Instance.SaveChart(new MedicalHistory(patient.Id));
            AllPatients.Add(patient);
            PatientStorage.Add(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            for (int i = 0; i < AllPatients.Count; i++)
            {
                if (patient.Id.Equals(AllPatients[i].Id))
                {
                    AllPatients.Remove(AllPatients[i]);
                    AllPatients.Insert(i, patient);
                    PatientStorage.Update(patient);
                }
            }
            
        }

        public void DeletePatient(Patient patient)
        {
            for (int i = 0; i < AllPatients.Count; i++)
            {
                if (patient.Id.Equals(AllPatients[i].Id))
                {
                    AllPatients.Remove(AllPatients[i]);
                    ChartService.Instance.DeleteChart(patient.Id);
                    PatientStorage.Delete(patient);
                }
            }

            
        }

        public bool CheckIfAllergicToComponent(string medicineName, List<String> allergies)
        {
            bool isAllergic = false;
            List<MedicineComponent> components = MedicineService.Instance.GetByName(medicineName).Composition;
            foreach (MedicineComponent c in components)
            {
                foreach (String allergie in allergies)
                {
                    Medicine medicine = MedicineService.Instance.GetByName(allergie);
                    if (medicine != null)
                    {
                        List<MedicineComponent> allergieComponents = medicine.Composition;
                        foreach (MedicineComponent allergieComp in allergieComponents)
                        {
                            if (c.Component.ToLower().Equals(allergieComp.Component.ToLower()))
                            {
                                isAllergic = true;
                            }
                        }
                    }

                }
            }

            return isAllergic;
        }

        public bool CheckIfAllergicToMedicine(List<String> allergies, string name)
        {
            bool isAllergic = false;
            foreach (String allergie in allergies)
            {
                if (name.ToLower().Contains(allergie.ToLower()))
                {
                    isAllergic = true;
                }
            }
            return isAllergic;
        }

        public List<int> GetPatientIDs()
        {
            List<int> allPatientIDs = new List<int>();
            foreach (Patient patient in AllPatients)
            {
                allPatientIDs.Add(patient.Id);
            }
            return allPatientIDs;
        }

        public bool IsPatientTroll(Patient patient, DoctorAppointment doctorAppointment)
        {
            int timeRange = 10;
            int maxAppointmentsInTimeRange = 3;
            if (doctorAppointment.AppointmentStart < patient.TrollMechanism.TrollCheckStartDate.AddDays(timeRange))
            {
                patient.TrollMechanism.AppointmentCounterInTimeRange++;
                if (patient.TrollMechanism.AppointmentCounterInTimeRange >= maxAppointmentsInTimeRange)
                {
                    patient.TrollMechanism.IsTroll = true;
                    patient.TrollMechanism.TrollCheckStartDate = doctorAppointment.AppointmentStart.Date;
                    return patient.TrollMechanism.IsTroll;
                }
            }
            return patient.TrollMechanism.IsTroll;
        }

        private void UpdatePatientTrollMechanism()
        {
            int timeRange = 10;
            int maxAppointmentsInTimeRange = 3;
            foreach (Patient patient in AllPatients)
            {
                if (patient.TrollMechanism.TrollCheckStartDate.AddDays(timeRange) == DateTime.Today)
                {
                    patient.TrollMechanism.TrollCheckStartDate = DateTime.Today;
                    SetPatientTrollMechanism(patient, timeRange, maxAppointmentsInTimeRange);                  
                }
            }
        }

        private void SetPatientTrollMechanism(Patient patient,int timeRange, int maxAppointmentsInTimeRange)
        {
            if (DoctorAppointmentService.Instance.GetNumberOfAppointmentsInTimeRange(patient.Id, DateTime.Today, DateTime.Today.AddDays(timeRange)) > maxAppointmentsInTimeRange)
            {
                patient.TrollMechanism.IsTroll = true;
                patient.TrollMechanism.AppointmentCounterInTimeRange = DoctorAppointmentService.Instance.GetNumberOfAppointmentsInTimeRange(patient.Id, DateTime.Today, DateTime.Today.AddDays(timeRange));
            }
            else
            {
                patient.TrollMechanism.IsTroll = false;
                patient.TrollMechanism.AppointmentCounterInTimeRange = DoctorAppointmentService.Instance.GetNumberOfAppointmentsInTimeRange(patient.Id, DateTime.Today, DateTime.Today.AddDays(timeRange));
            }
        }

        public List<Patient> GetAllRegisteredPatients()
        {
            List<Patient> registeredPatients = new List<Patient>();
            foreach (Patient patient in AllPatients)
            {
                if (!patient.IsGuest)
                    registeredPatients.Add(patient);
            }
            return registeredPatients;
        }

        public List<Patient> GetAllGuests()
        {
            List<Patient> guests = new List<Patient>();
            foreach (Patient patient in AllPatients)
            {
                if (patient.IsGuest)
                    guests.Add(patient);
            }
            return guests;
        }

        public Patient GetPatientByID(int id) 
        {
            return PatientStorage.GetById(id);
        }

        public void ReloadPatients()
        {
            AllPatients = PatientStorage.GetAll();
        }

        public PatientNote GetNoteForPatientByAppointmentId(int patientId, int appointmentId)
        {
            PatientNote patientNote = null;
            Patient patient = GetPatientByID(patientId);
            foreach (PatientNote note in patient.PatientNotes)
            {
                if (note.AppointmentId.Equals(appointmentId))
                {
                    patientNote = note;
                }
            }
            return patientNote;
        }

        public void AddAppointmentNote(int patientId, PatientNote patientNote)
        {
            Patient patient = GetPatientByID(patientId);
            patient.PatientNotes.Add(patientNote);
            PatientStorage.Update(patient);
        }

       

        public List<PatientNote> GetNotesByPatient(int patientId)
        {
            Patient patient = GetPatientByID(patientId);
            return patient.PatientNotes;
        }
    }
}
