using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalUnitTests.Patient_portal
{
    public class BlockPatientTests
    {
        private static IPatientRepository CreateStubRepository()
        {
            List<Patient> patients = new List<Patient>();
            var stubRepository = new Mock<IPatientRepository>();


            patients.Add(new Patient(1, "Petar", "Petrovic", "male", "A", new System.DateTime(2005, 09, 11), "Bogoboja Atanackovica 15", "0634556665", "petar@gmail.com", "petar", "petar", "miki", null, "Employed", true));    
            patients.Add(new Patient(2, "Jovan", "Zoric", "male", "A", new System.DateTime(1985, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true));
            patients.Add(new Patient(3, "Zorana", "Bilic", "male", "A", new System.DateTime(1978, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true));

            patients[0].IsBlocked = true;

            stubRepository.Setup(m => m.GetAllSuspiciousPatients()).Returns(patients);
            stubRepository.Setup(m => m.GetById(1)).Returns(patients[0]);
            //stubRepository.Setup(m => m.GetAllByPatientId(1)).Returns(patients.GetRange(0, 2));
            //stubRepository.Setup(m => m.GetAllDoneByPatientId(1)).Returns(patients.GetRange(0, 1));
            //stubRepository.Setup(m => m.GetAllNotDoneByPatientId(1)).Returns(patients.GetRange(1, 1));           

            return stubRepository.Object;
        }
    }
}
