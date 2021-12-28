using Hospital.Medical_records.Repository.Interface;
using Hospital.Medical_records.Service;
using Hospital.Schedule.Model;
using Hospital.Shared_model.Model;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Xunit;


namespace HospitalUnitTests.Patient_portal
{
    public class AuthorizationTests
    {
        [Fact]
        public void Failed_login()
        {
            PatientController patientController = new PatientController(null ,null, CreateStubPatientService());
            //PatientController patientController = new PatientController(alergenService, doctorService, patientService);
            UserCredentials fakeCredentials = new UserCredentials("lazni", "lazni");

            var result = patientController.Authenticate(fakeCredentials) as IActionResult;
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public void Success_login()
        {
            PatientController patientController = new PatientController(null, null, CreateStubPatientService());
            //PatientController patientController = new PatientController(alergenService, doctorService, patientService);
            UserCredentials realCredentials = new UserCredentials("miki", "miki");

            var result = patientController.Authenticate(realCredentials);
            Assert.IsType<OkObjectResult>(result);
            var responseOR = (OkObjectResult) result;
            var response = responseOR.Value;
           // Assert.Equal(response, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjciLCJyb2xlIjoicGF0aWVudCJ9.FtOrWDpyT84TL1NT8TyTzRR4zLTR4mRKkJXzL1JDv9Y");
        }


        private static IPatientService CreateStubPatientService()
        {
            Mock<IPatientService> stubService = new Mock<IPatientService>();
            Patient patient = new Patient(7, "Miki", "Nikolic", "male", "A", new System.DateTime(1960, 07, 11), "Voje Rodica 19", "0697856665", "miki@gmail.com", "miki", "miki", "miki", null, "Employed", true)
            { DoctorId = 3 };
            stubService.Setup(m => m.GenerateJwtToken(patient)).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjciLCJyb2xlIjoicGF0aWVudCJ9.FtOrWDpyT84TL1NT8TyTzRR4zLTR4mRKkJXzL1JDv9Y");
            return stubService.Object;
        }
    }
}
