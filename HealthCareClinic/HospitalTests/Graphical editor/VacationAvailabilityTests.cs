using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalUnitTests.Graphical_editor
{
    public class VacationAvailabilityTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Get_vacation_availability(DateTime startDate, DateTime endDate, bool vacationAvailability)
        {
            var vacation = new Vacation(1, "Description...", startDate, endDate, 1);
            var allVacations = new List<Vacation>
            {
                new Vacation(1, "Description...", DateTime.Today.AddDays(5), DateTime.Today.AddDays(20), 1),
            };

            var isAvailable = vacation.GetVacationAvailability(allVacations);

            Assert.Equal(isAvailable, vacationAvailability);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { DateTime.Today.AddDays(10), DateTime.Today.AddDays(15), false });
            retVal.Add(new object[] { DateTime.Today.AddDays(1), DateTime.Today.AddDays(15), false });
            retVal.Add(new object[] { DateTime.Today.AddDays(1), DateTime.Today.AddDays(25), false });
            retVal.Add(new object[] { DateTime.Today.AddDays(1), DateTime.Today.AddDays(3), true });

            return retVal;
        }
    }
}
