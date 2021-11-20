using Hospital.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Hospital.Service;
using Model;

namespace HospitalTests
{
    public class PatientRegistrationTests
    {
        [Fact]
        public void Choose_available_doctor()
        {
            //var stubRepository = new Mock<IDoctorRepository>();
            DoctorService doctorService = new DoctorService(CreateStubRepository());


        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Get_all_general_medicine_doctors(int numberOfGeneralDoctors, bool shouldWork)
        {
            DoctorService doctorService = new DoctorService(CreateStubRepository());

            List<Doctor> generalDoctors = doctorService.GetAllGeneralMedicineDoctors();

            if (shouldWork)
                Assert.Equal(numberOfGeneralDoctors, generalDoctors.Count);
            else
                Assert.NotEqual(numberOfGeneralDoctors, generalDoctors.Count);
        }
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 3, true },
                new object[] { 2, false }
            };

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, false)]
        public void Get_all_general_medicine_doctors_who_are_not_over_ocupied(int numberOfNonOverOcupiedDoctors, bool shouldWork)
        {
            DoctorService doctorService = new DoctorService(CreateStubRepository());

            List<Doctor> notOcupiedDoctors = doctorService.GetNonOverOcuipedDoctors();

            if (shouldWork)
                Assert.Equal(numberOfNonOverOcupiedDoctors, notOcupiedDoctors.Count);
            else
                Assert.NotEqual(numberOfNonOverOcupiedDoctors, notOcupiedDoctors.Count);
        }


        private static IDoctorRepository CreateStubRepository()
        {
            List<Doctor> doctors = new List<Doctor>();
            var stubRepository = new Mock<IDoctorRepository>();

            doctors.Add(new Doctor("Marko", new Specialty("General medicine"), new System.Collections.ArrayList { new Patient("Darko"), new Patient("Parko"), new Patient("Sarko"), new Patient("Karko") }));
            doctors.Add(new Doctor("Nikola", new Specialty("General medicine"), new System.Collections.ArrayList { new Patient("Mihailo") }));
            doctors.Add(new Doctor("Petar", new Specialty("General medicine"), new System.Collections.ArrayList { new Patient("Teodora") }));
            doctors.Add(new Doctor("Maja", new Specialty("Opftamology"), new System.Collections.ArrayList { new Patient("Jana") }));

            stubRepository.Setup(m => m.GetAll()).Returns(doctors);

            return stubRepository.Object;
        }
    }
}
