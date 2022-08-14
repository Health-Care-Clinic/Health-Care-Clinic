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
     //   [Theory]
     //   [MemberData(nameof(SpecialtyNameData))]
     //   public void Get_all_doctors_with_specialty(string specialtyName)
     [Fact]
        public void Get_all_doctors_with_specialty()
        {
            string specialtyName = "General medicine";
            DoctorService doctorService = new DoctorService(CreateStubDoctorRepository());
            List<Doctor> doctorsWithSpecialty = doctorService.GetDoctorsBySpecialty(specialtyName);

          /*  switch (specialtyName)
            {
                case "General medicine":*/
                    Assert.Equal(3, doctorsWithSpecialty.Count);
                    Assert.Equal(1, doctorsWithSpecialty[0].Id);
                    Assert.Equal(2, doctorsWithSpecialty[1].Id);
                    Assert.Equal(3, doctorsWithSpecialty[2].Id);
        /*            break;
                case "Surgery":
                    Assert.Equal(2, doctorsWithSpecialty.Count);
                    Assert.Equal(4, doctorsWithSpecialty[0].Id);
                    Assert.Equal(5, doctorsWithSpecialty[1].Id);
                    break;
                case "Opftamology":
                    Assert.Single(doctorsWithSpecialty);
                    Assert.Equal(6, doctorsWithSpecialty[0].Id);
                    break;
                case "Dermmatology":
                    Assert.Single(doctorsWithSpecialty);
                    Assert.Equal(7, doctorsWithSpecialty[0].Id);
                    break;
            }*/
        }
/*
        public static IEnumerable<object[]> SpecialtyNameData()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { "General medicine" });
            retVal.Add(new object[] { "Surgery" });
            retVal.Add(new object[] { "Opftamology" });
            retVal.Add(new object[] { "Dermmatology" });

            return retVal;
        }
*/
        private static IDoctorRepository CreateStubDoctorRepository()
        {
            List<Doctor> doctors = new List<Doctor>();
            var stubDoctorRepository = new Mock<IDoctorRepository>();

            Doctor doctor1 = new Doctor(1, "Nikola", "Nikolic", "male", new DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com", "nikola", "nikola",
                     new DateTime(2021, 06, 10), null, "General medicine", 1);

            Doctor doctor2 = new Doctor(2, "Marko", "Radic", "male", new DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com", "marko", "marko",
                 new DateTime(2020, 06, 07), null, "General medicine", 2);

            Doctor doctor3 = new Doctor(3, "Jozef", "Sivc", "male", new DateTime(1971, 06, 09), 80000.0, "Bulevar Oslobodjenja 45", "0697856665", "jozika@gmail.com", "jozef", "jozef",
                 new DateTime(2011, 03, 10), null, "General medicine", 3);

    /*        Doctor doctor4 = new Doctor(4, "Dragana", "Zoric", "female", new DateTime(1968, 01, 08), 80000.0, "Mike Antice 5", "0697856665", "dragana@gmail.com", "dragana", "dragana",
                 new DateTime(2015, 09, 11), null, "Surgery", 4);

            Doctor doctor5 = new Doctor(5, "Mile", "Grandic", "male", new DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "mile@gmail.com", "mile", "mile",
                 new DateTime(2017, 08, 12), null, "Surgery", 5);

            Doctor doctor6 = new Doctor(6, "Antonije", "Trkulja", "male", new DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "antonije@gmail.com", "antonije", "mile",
                 new DateTime(2017, 08, 12), null, "Opftamology", 6);

            Doctor doctor7 = new Doctor(7, "Sava", "Peric", "male", new DateTime(1978, 11, 07), 80000.0, "Pariske Komune 35", "0697856665", "sava@gmail.com", "sava", "mile",
                 new DateTime(2017, 08, 12), null, "Dermmatology", 7);
    */
            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);
     /*      doctors.Add(doctor4);
            doctors.Add(doctor5);
            doctors.Add(doctor6);
            doctors.Add(doctor7);
     */
            stubDoctorRepository.Setup(m => m.GetAll()).Returns(doctors);
            stubDoctorRepository.Setup(m => m.GetById(1)).Returns(doctors[0]);

            stubDoctorRepository.Setup(m => m.GetDoctorsBySpecialty("General medicine"))
                .Returns(new List<Doctor>() {doctor1, doctor2, doctor3});
      /*      stubDoctorRepository.Setup(m => m.GetDoctorsBySpecialty("Surgery"))
                .Returns(new List<Doctor>() { doctor4, doctor5 });
            stubDoctorRepository.Setup(m => m.GetDoctorsBySpecialty("Opftamology"))
                .Returns(new List<Doctor>() { doctor6 });
            stubDoctorRepository.Setup(m => m.GetDoctorsBySpecialty("Dermmatology"))
                .Returns(new List<Doctor>() { doctor7 });
      */
            return stubDoctorRepository.Object;
        }
        /*
        private static IAppointmentRepository CreateStubAppointmentRepository()
        {
            List<Appointment> appointments = new List<Appointment>();
            var stubAppointmentRepository = new Mock<IAppointmentRepository>();

            appointments.Add(new Appointment(1, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 7, 0, 0), 1));
            appointments.Add(new Appointment(2, 2, 1, 1, false, false, new DateTime(2022, 2, 22, 7, 30, 0), 2));
            appointments.Add(new Appointment(3, 3, 1, 1, false, false, new DateTime(2022, 2, 22, 8, 0, 0), 3));
            appointments.Add(new Appointment(4, 4, 1, 1, false, false, new DateTime(2022, 2, 22, 8, 30, 0), 4));
            appointments.Add(new Appointment(5, 5, 1, 1, false, false, new DateTime(2022, 2, 22, 9, 0, 0), 5));
            appointments.Add(new Appointment(6, 6, 1, 1, false, false, new DateTime(2022, 2, 22, 9, 30, 0), 6));
            appointments.Add(new Appointment(7, 7, 1, 1, false, false, new DateTime(2022, 2, 22, 10, 0, 0), 7));
            appointments.Add(new Appointment(8, 8, 1, 1, false, false, new DateTime(2022, 2, 22, 10, 30, 0), 8));
            appointments.Add(new Appointment(9, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 11, 0, 0), 9));
            appointments.Add(new Appointment(10, 1, 2, 1, false, false, new DateTime(2022, 2, 22, 11, 30, 0), 10));
            appointments.Add(new Appointment(11, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 12, 0, 0), 11));
            appointments.Add(new Appointment(12, 1, 1, 1, false, false, new DateTime(2022, 2, 22, 12, 30, 0), 12));

            stubAppointmentRepository.Setup(m => m.GetAll()).Returns(appointments);
            stubAppointmentRepository.Setup(m => m.GetById(1)).Returns(appointments[0]);

            return stubAppointmentRepository.Object;
        }*/
    }
}
