using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalUnitTests.Graphical_editor
{
    public class VacationAvailabilityTests
    {
        [Fact]
        public void Get_vacation_availability()
        {
            var vacation = new Vacation(1, "Description...", new DateTime(2021, 05, 09, 00, 00, 00), new DateTime(2021, 05, 20, 23, 00, 00), 1);
            var allVacations = new List<Vacation>
            {
                new Vacation(1, "Description...", new DateTime(2021, 05, 07, 00, 00, 00), new DateTime(2021, 05, 18, 23, 00, 00), 1),
                new Vacation(2, "Description...", new DateTime(2021, 08, 21, 00, 00, 00), new DateTime(2021, 09, 12, 23, 00, 00), 1),
            };

            var isAvailable = vacation.GetVacationAvailability(allVacations);

            Assert.False(isAvailable);   
        }
    }
}
