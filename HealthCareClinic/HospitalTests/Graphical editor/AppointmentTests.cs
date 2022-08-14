
using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalUnitTests.Graphical_editor
{
    public class AppointmentTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Appointment")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Appointments.Add(new Appointment { Id = 1, PatientId = 1, DoctorId = 1, RoomId = 1, isCancelled = false, isDone = false, Date = new System.DateTime(2022, 2, 22, 7, 0, 0), SurveyId = 1 });
                context.Appointments.Add(new Appointment { Id = 2, PatientId = 2, DoctorId = 1, RoomId = 1, isCancelled = false, isDone = false, Date = new System.DateTime(2022, 2, 22, 18, 0, 0), SurveyId = 2 });
//                context.Appointments.Add(new Appointment { Id = 3, PatientId = 3, DoctorId = 2, RoomId = 2, isCancelled = false, isDone = false, Date = new System.DateTime(2022, 2, 25, 10, 0, 0), SurveyId = 3 });
                context.SaveChanges();
            }

            return options;
        }

        private void ClearStubRepository(HospitalDbContext context)
        {
            foreach (Appointment a in context.Appointments)
            {
                context.Appointments.Remove(a);
                context.SaveChanges();
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Get_room_appointments(int roomId, int roomAppointmentsCount)
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);

                List<Appointment> roomAppointments = appointmentService.GetRoomAppointments(roomId);
                ClearStubRepository(context);

                Assert.Equal(roomAppointmentsCount, roomAppointments.Count);
            }
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
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);

                int allAppointments = appointmentService.GetNumOfAppointments(1, 2, 2022);

                ClearStubRepository(context);

                Assert.Equal(2, allAppointments);
            }
        }

        [Fact]
        public void Get_doctor_patients_by_month()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                AppointmentRepository appointmentRepository = new AppointmentRepository(context);
                AppointmentService appointmentService = new AppointmentService(appointmentRepository);

                int allAppointments = appointmentService.GetNumOfPatients(1, 2, 2022);

                ClearStubRepository(context);

                Assert.Equal(2, allAppointments);
            }
        }
    }
}
