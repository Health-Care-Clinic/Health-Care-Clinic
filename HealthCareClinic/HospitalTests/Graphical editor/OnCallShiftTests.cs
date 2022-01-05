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
    public class OnCallShiftTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "OnCallShifts")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Doctors.Add(new Doctor(1, "Nikola", "Nikola", "male", new System.DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com"
                    , "nikola", "nikola", new System.DateTime(2021, 06, 10), null, "General medicine", 1));
                context.Doctors.Add(new Doctor(2, "Marko", "Radic", "male", new System.DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com"
                    , "marko", "marko", new System.DateTime(2020, 06, 07), null, "General medicine", 2));
                context.OnCallShifts.Add(new OnCallShift(1,new DateTime(2022, 02, 02, 14, 00, 00),1));
                context.OnCallShifts.Add(new OnCallShift(2, new DateTime(2021, 11, 25, 9, 30, 00),2));
                context.OnCallShifts.Add(new OnCallShift(3, new DateTime(2022, 08, 22, 9, 30, 00),1));
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
            foreach (OnCallShift t in context.OnCallShifts)
            {
                context.OnCallShifts.Remove(t);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Get_all_doctor_on_call_shifts()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                OnCallShiftRepository onCallShiftRepository = new OnCallShiftRepository(context);
                OnCallShiftService onCallShiftService = new OnCallShiftService(onCallShiftRepository);

                List<OnCallShift> allCallShifts = onCallShiftService.GetOnCallShiftByDoctorId(1);

                ClearStubRepository(context);

                Assert.Equal(2, allCallShifts.Count);
            }
        }

        [Fact]
        public void Get_doctor_call_shifts_by_month()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                OnCallShiftRepository onCallShiftRepository = new OnCallShiftRepository(context);
                OnCallShiftService onCallShiftService = new OnCallShiftService(onCallShiftRepository);

                int allCallShifts = onCallShiftService.GetNumOfOnCallShift(1,2,2022);

                ClearStubRepository(context);

                Assert.Equal(1, allCallShifts);
            }
        }

    }
}
