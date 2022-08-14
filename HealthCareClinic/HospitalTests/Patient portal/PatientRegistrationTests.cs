using System.Collections.Generic;
using Hospital.Shared_model.Model;
using Xunit;
using Moq;

using Hospital.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Service;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Medical_records.Repository;
using Hospital.Shared_model.Repository;

namespace HospitalUnitTests.Patient_portal
{
    public class PatientRegistrationTests
    {    
        //2 Unit testa
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 3, true },
                new object[] { 2, false }
            };

     //   [Theory]
     //   [InlineData(2, true)]
      //  [InlineData(3, false)]
        [Fact]
      //  public void Get_all_general_medicine_doctors_who_are_not_over_ocupied(int numberOfAvailableDoctors, bool shouldWork)
        public void Get_all_general_medicine_doctors_who_are_not_over_ocupied()
        {
            int numberOfAvailableDoctors = 2;

            DoctorService doctorService = new DoctorService(CreateStubRepository());

            List<Doctor> availableDoctors = doctorService.GetAvailableDoctors();

       //     if (shouldWork)
            Assert.Equal(numberOfAvailableDoctors, availableDoctors.Count);
      //      else
      //          Assert.NotEqual(numberOfAvailableDoctors, availableDoctors.Count);
        }


        private static IDoctorRepository CreateStubRepository()
        {
            Mock<IDoctorRepository> stubRepository = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();

            var doctor1 = new Doctor(1, "Nikola", "Nikolic", "male", new System.DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com", "nikola", "nikola",
                     new System.DateTime(2021, 06, 10), null, "General medicine", 1);

            var doctor2 = new Doctor(2, "Marko", "Radic", "male", new System.DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com", "marko", "marko",
                 new System.DateTime(2020, 06, 07), null, "General medicine", 2);

            doctors.Add(doctor1);
            doctors.Add(doctor2);
            stubRepository.Setup(m => m.GetAvailableDoctors()).Returns(doctors);
            return stubRepository.Object;
        }      
    }
}
