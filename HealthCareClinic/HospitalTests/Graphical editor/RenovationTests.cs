using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Rooms_and_equipment.Service;
using Hospital.Shared_model.Repository;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalUnitTests.Graphical_editor
{
    public class RenovationTests
    {

        private static IRenovationRepository CreateRenovationsStubRepository()
        {
            List<Renovation> renovations = new List<Renovation>();
            var stubRepository = new Mock<IRenovationRepository>();
            var renovationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);

            renovations.Add(new Renovation { Id = 1, FirstRoomId = 1, SecondRoomId = 2, Duration = 4, Date = renovationDate, Type = Renovation.RenovationType.Merge });

            stubRepository.Setup(m => m.GetAll()).Returns(renovations);

            return stubRepository.Object;
        }

        [Fact]
        public void Get_available_free_term_for_renovation_when_free_terms_exist()
        {
            var renovationRepository = new Mock<IRenovationRepository>().Object;
            var transferRepository = new Mock<ITransferRepository>().Object;
            var appointmentRepository = new Mock<IAppointmentRepository>().Object;
            RenovationService renovationService = new RenovationService(renovationRepository, transferRepository, appointmentRepository);
            var renovationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(3).Day, 8, 0, 0);
            var availableDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            Renovation renovation = new Renovation(4, 1, 2, renovationDate, 1, Renovation.RenovationType.Merge);
            
            List<DateTime> freeTerms = renovationService.getFreeTermsForMerge(renovation);

            Assert.Contains(availableDate, freeTerms);
        }

        [Fact]
        public void Get_available_free_term_for_renovation_when_free_terms_not_exist()
        {
            var renovationRepository = CreateRenovationsStubRepository();
            var transferRepository = new Mock<ITransferRepository>().Object;
            var appointmentRepository = new Mock<IAppointmentRepository>().Object;
            RenovationService renovationService = new RenovationService(renovationRepository, transferRepository, appointmentRepository);
            var renovationDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(2).Day, 8, 0, 0);
            Renovation renovation = new Renovation(4, 1, 2, renovationDate, 1, Renovation.RenovationType.Merge);

            List<DateTime> freeTerms = renovationService.getFreeTermsForMerge(renovation);

            Assert.Empty(freeTerms);
        }


        [Theory]
        [MemberData(nameof(Data))]
        public void Get_room_renovations(int roomId, int roomRenovationsCount)
        {
            var renovationRepository = CreateRenovationsStubRepository();
            var transferRepository = new Mock<ITransferRepository>().Object;
            var appointmentRepository = new Mock<IAppointmentRepository>().Object;
            RenovationService renovationService = new RenovationService(renovationRepository, transferRepository, appointmentRepository);

            List<Renovation> roomRenovations = renovationService.GetRoomRenovations(roomId);

            Assert.Equal(roomRenovationsCount, roomRenovations.Count);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { 1, 1 });
            retVal.Add(new object[] { 3, 0 });

            return retVal;
        }
    }
}
