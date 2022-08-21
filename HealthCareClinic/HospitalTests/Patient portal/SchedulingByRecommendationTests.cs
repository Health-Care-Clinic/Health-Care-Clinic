using Hospital.Medical_records.Repository.Interface;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalUnitTests.Patient_portal
{
    public class SchedulingByRecommendationTests
    {

        [Fact]
        public void Get_all_doctors_with_specialty()
        {
            string specialtyName = "General medicine";
            DoctorService doctorService = new DoctorService(CreateStubDoctorRepository());
            
            List<Doctor> doctorsWithSpecialty = doctorService.GetDoctorsBySpecialty(specialtyName);

            Assert.Single(doctorsWithSpecialty);
            Assert.Equal(1, doctorsWithSpecialty[0].Id);
        }

        private static IDoctorRepository CreateStubDoctorRepository()
        {
            List<Doctor> doctors = new List<Doctor>();
            var stubDoctorRepository = new Mock<IDoctorRepository>();

            Doctor doctor1 = new Doctor(1, "Nikola", "Nikolic", "male", new DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com", "nikola", "nikola",
                     new DateTime(2021, 06, 10), null, "General medicine", 1);

            stubDoctorRepository.Setup(m => m.GetDoctorsBySpecialty("General medicine"))
                .Returns(new List<Doctor>() {doctor1});

            return stubDoctorRepository.Object;
        }
    }
}
