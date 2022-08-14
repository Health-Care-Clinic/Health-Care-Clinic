
using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HospitalUnitTests.Graphical_editor
{
    public class AppointmentTests
    {
        private static IAppointmentRepository CreateStubRepository()
        {
            List<Appointment> appointments = new List<Appointment>();
            var stubRepository = new Mock<IAppointmentRepository>();
            var doctorId = 1;

            appointments.Add(new Appointment { Id = 1, PatientId = 1, DoctorId = doctorId, RoomId = 1, isCancelled = false, isDone = false, Date = new System.DateTime(2022, 2, 22, 7, 0, 0), SurveyId = 1 });
            appointments.Add(new Appointment { Id = 2, PatientId = 2, DoctorId = doctorId, RoomId = 1, isCancelled = false, isDone = false, Date = new System.DateTime(2022, 2, 22, 18, 0, 0), SurveyId = 2 });

            stubRepository.Setup(m => m.GetAll()).Returns(appointments);
            stubRepository.Setup(m => m.getAppointmentsByDoctorId(doctorId)).Returns(appointments);

            return stubRepository.Object;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Get_room_appointments_mock(int roomId, int roomAppointmentsCount)
        {
            AppointmentService appointmentService = new AppointmentService(CreateStubRepository());

            List<Appointment> roomAppointments = appointmentService.GetRoomAppointments(roomId);

            Assert.Equal(roomAppointmentsCount, roomAppointments.Count);
            
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { 1, 2 });
            retVal.Add(new object[] { 3, 0 });

            return retVal;
        }

        [Fact]
        public void Get_doctor_appointments_by_month()
        {
            AppointmentService appointmentService = new AppointmentService(CreateStubRepository());
            var doctorId = 1;
            var month = 2;
            var year = 2022;
            int allAppointments = appointmentService.GetNumOfAppointments(doctorId, month, year);

            Assert.Equal(2, allAppointments);
        }

        [Fact]
        public void Get_doctor_patients_by_month()
        {
            AppointmentService appointmentService = new AppointmentService(CreateStubRepository());
            var doctorId = 1;
            var month = 2;
            var year = 2022;

            int allAppointments = appointmentService.GetNumOfPatients(doctorId, month, year);

            Assert.Equal(2, allAppointments);

        }
    }
}
