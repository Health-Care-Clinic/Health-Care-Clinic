using Hospital.Repository.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Hospital.Service;
using Shouldly;

namespace HospitalTests
{
    public class RegistrationTests
    {

        [Fact]
        public void Check_if_passowrds_match( )
        {
            PatientService patientService = new PatientService(CreateStubRepository());

            Patient patient1 = new Patient("Marko", "Markovic", "pass123", "pass123");
            bool match = patientService.CheckIfPasswordsMatch(patient1);

            Assert.True(match);
        }
        [Fact]
        public void Check_if_passowrds_not_match()
        {
            PatientService patientService = new PatientService(CreateStubRepository());

            Patient patient1 = new Patient("Nikola", "Nikolic", "pass123", "caocao");
            bool match = patientService.CheckIfPasswordsMatch(patient1);

            Assert.False(match);
        }

        private static IPatientRepository CreateStubRepository()
        {
            List<Patient> patients = new List<Patient>();
            var stubRepository = new Mock<IPatientRepository>();

            patients.Add(new Patient("Marko","Markovic","pass123","pass123"));
            patients.Add(new Patient("Nikola","Nikolic", "pass123", "caocao"));

            stubRepository.Setup(m => m.GetAll()).Returns(patients);

            return stubRepository.Object;
        }
    }
}
