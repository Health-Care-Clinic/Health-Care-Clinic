using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HospitalUnitTests.Graphical_editor
{
    public class VacationTests
    {

        [Fact]
        public void Get_all_doctor_vacations()
        {
            var vacations = new List<Vacation>();
            var stubRepository = new Mock<IVacationRepository>();
            var doctorId = 1;
            vacations.Add(new Vacation(1, "Description...", new DateTime(2021, 05, 07, 00, 00, 00), new DateTime(2021, 05, 18, 00, 00, 00), 1));
            stubRepository.Setup(m => m.GetVacationsByDoctorId(doctorId)).Returns(vacations);
            VacationService vacationService = new VacationService(stubRepository.Object);

            var allVacations = vacationService.GetVacationsByDoctorId(doctorId);

            Assert.Single(allVacations);
        }

        [Fact]
        public void Add_doctor_vacation()
        {
            var vacations = new List<Vacation>();
            var stubRepository = new Mock<IVacationRepository>();
            var vacation = new Vacation(1, "Description...", DateTime.Now.AddDays(1), DateTime.Now.AddDays(5), 1);
            VacationService vacationService = new VacationService(stubRepository.Object);

            vacationService.Add(vacation);

            stubRepository.Verify(r => r.Add(vacation), Times.Once);
        }
    }
}
