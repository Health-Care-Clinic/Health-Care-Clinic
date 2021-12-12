using Hospital.Medical_records.Repository.Interface;
using Hospital.Medical_records.Service;
using Hospital.Schedule.Model;
using Hospital.Shared_model.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalUnitTests.Patient_portal
{
    public class BlockPatientTests
    {
        [Fact]
        public void Get_all_malicious_patients()
        {
            PatientService patientService = new PatientService(CreateStubRepository());
            List<Patient> maliciousPatients = patientService.GetAllSuspiciousPatients();

            Assert.NotEmpty(maliciousPatients);
            Assert.Single(maliciousPatients);
            Assert.IsType<List<Patient>>(maliciousPatients);
            Assert.Equal(1, maliciousPatients[0].Id);
        }

        private static IPatientRepository CreateStubRepository()
        {
            List<Patient> patients = new List<Patient>();
            List<CanceledAppointment> canceledAppointments = new List<CanceledAppointment>();
            var stubRepository = new Mock<IPatientRepository>();


            patients.Add(new Patient(1, "Petar", "Petrovic", "male", "A", new System.DateTime(2005, 09, 11), "Bogoboja Atanackovica 15", "0634556665", "petar@gmail.com", "petar", "petar", "miki", null, "Employed", true));    
            patients.Add(new Patient(2, "Jovan", "Zoric", "male", "A", new System.DateTime(1985, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true));
            patients.Add(new Patient(3, "Zorana", "Bilic", "male", "A", new System.DateTime(1978, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true));

            canceledAppointments.Add(new CanceledAppointment(new System.DateTime(2021, 12, 1), 1, 123));
            canceledAppointments.Add(new CanceledAppointment(new System.DateTime(2021, 12, 3), 1, 124));
            canceledAppointments.Add(new CanceledAppointment(new System.DateTime(2021, 12, 4), 1, 125));
            canceledAppointments.Add(new CanceledAppointment(new System.DateTime(2021, 12, 1), 1, 126));

            stubRepository.Setup(m => m.GetAllSuspiciousPatients()).Returns(patients.GetRange(0, 1));           

            return stubRepository.Object;
        }
    }
}
