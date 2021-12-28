using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HospitalUnitTests.Graphical_editor
{
    public class VacationTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Vacations")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Doctors.Add(new Doctor(1, "Nikola", "Nikola", "male", new DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com"
                    , "nikola", "nikola", new DateTime(2021, 06, 10), null, "General medicine", 1));
                context.Doctors.Add(new Doctor(2, "Marko", "Radic", "male", new DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com"
                    , "marko", "marko", new DateTime(2020, 06, 07), null, "General medicine", 2));
                context.Vacations.Add(new Vacation(1, "Description...", new DateTime(2021, 05, 07, 00, 00, 00), new DateTime(2021, 05, 18, 23, 00, 00), 1));
                context.Vacations.Add(new Vacation(2, "Description...", new DateTime(2021, 08, 21, 00, 00, 00), new DateTime(2021, 09, 12, 23, 00, 00), 1));
                context.Vacations.Add(new Vacation(3, "Description...", new DateTime(2022, 02, 05, 00, 00, 00), new DateTime(2021, 02, 21, 23, 00, 00), 1));
                context.Vacations.Add(new Vacation(4, "Description...", new DateTime(2021, 03, 17, 00, 00, 00), new DateTime(2021, 03, 24, 23, 00, 00), 2));
                context.Vacations.Add(new Vacation(5, "Description...", new DateTime(2022, 08, 01, 00, 00, 00), new DateTime(2021, 08, 14, 23, 00, 00), 2));
                context.Vacations.Add(new Vacation(6, "Description...", new DateTime(2021, 12, 27, 00, 00, 00), new DateTime(2022, 01, 10, 23, 00, 00), 2));
                context.SaveChanges();
            }

            return options;
        }

        private void ClearStubRepository(HospitalDbContext context)
        {
            foreach (Doctor r in context.Doctors)
            {
                context.Doctors.Remove(r);
                context.SaveChanges();
            }
            foreach (Vacation t in context.Vacations)
            {
                context.Vacations.Remove(t);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Get_all_doctor_vacations()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                VacationRepository vacationRepository = new VacationRepository(context);
                VacationService vacationService = new VacationService(vacationRepository);

                List<Vacation> allVacations = vacationService.GetVacationsByDoctorId(1);

                ClearStubRepository(context);

                Assert.Equal(3, allVacations.Count);
            }
        }

        [Fact]
        public void Add_doctor_vacation()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                VacationRepository vacationRepository = new VacationRepository(context);
                VacationService vacationService = new VacationService(vacationRepository);

                Vacation vacation = new Vacation(7, "Description...", new DateTime(2021, 10, 12, 00, 00, 00), new DateTime(2021, 11, 01, 23, 00, 00), 1);
                vacationService.Add(vacation);
                Vacation addedVacation = vacationService.GetOneById(7);

                ClearStubRepository(context);

                Assert.NotNull(addedVacation);
            }
        }

        [Fact]
        public void Change_doctor_vacation()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                VacationRepository vacationRepository = new VacationRepository(context);
                VacationService vacationService = new VacationService(vacationRepository);

                Vacation vacation = new Vacation(1, "New description", new DateTime(2021, 05, 07, 00, 00, 00), new DateTime(2021, 05, 18, 23, 00, 00), 1);
                vacationService.Change(vacation);
                Vacation changedVacation = vacationService.GetOneById(1);

                ClearStubRepository(context);

                Assert.Equal("New description", changedVacation.Description);
            }
        }

        [Fact]
        public void Delete_doctor_vacation()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                VacationRepository vacationRepository = new VacationRepository(context);
                VacationService vacationService = new VacationService(vacationRepository);

                vacationService.RemoveById(1);
                Vacation vacation = vacationService.GetOneById(1);

                ClearStubRepository(context);

                Assert.Null(vacation);
            }
        }
    }
}
