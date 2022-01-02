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
    public class WorkDayShiftTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "WorkDayShifts")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.WorkDayShift.Add(new WorkDayShift { Id = 1, Name = "First", StartTime = new DateTime(2022, 2, 22, 9, 0, 0), EndTime = new DateTime(2022, 2, 22, 11, 0, 0) });
                context.WorkDayShift.Add(new WorkDayShift { Id = 2, Name = "Second", StartTime = new DateTime(2022, 2, 22, 13, 0, 0), EndTime = new DateTime(2022, 2, 22, 16, 0, 0) });
                context.SaveChanges();
            }

            return options;
        }

        [Fact]
        public void Get_all_work_day_shifts()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                WorkDayShiftRepository workDayShiftRepository = new WorkDayShiftRepository(context);
                WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayShiftRepository);

                List<WorkDayShift> allWorkDayShifts = workDayShiftService.GetAll().ToList();
                foreach (WorkDayShift wds in context.WorkDayShift)
                {
                    context.WorkDayShift.Remove(wds);
                    context.SaveChanges();
                }

                Assert.Equal(2, allWorkDayShifts.Count);
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Add_work_day_shift(DateTime shiftStartTime, DateTime shiftEndTime, bool added)
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                WorkDayShiftRepository workDayShiftRepository = new WorkDayShiftRepository(context);
                WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayShiftRepository);

                bool shiftAdded = workDayShiftService.AddWorkDayShift(new WorkDayShift { Id = 3, Name = "Third", StartTime = shiftStartTime, EndTime = shiftEndTime });
                foreach (WorkDayShift wds in context.WorkDayShift)
                {
                    context.WorkDayShift.Remove(wds);
                    context.SaveChanges();
                }

                Assert.Equal(shiftAdded, added);
            }
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { new DateTime(2022, 2, 22, 16, 0, 0), new DateTime(2022, 2, 22, 19, 0, 0), true });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 17, 0, 0), new DateTime(2022, 2, 22, 18, 0, 0), true });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 15, 0, 0), new DateTime(2022, 2, 22, 17, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 12, 0, 0), new DateTime(2022, 2, 22, 14, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 14, 0, 0), new DateTime(2022, 2, 22, 15, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 18, 0, 0), new DateTime(2022, 2, 22, 17, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 6, 0, 0), new DateTime(2022, 2, 22, 8, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 18, 0, 0), new DateTime(2022, 2, 22, 21, 0, 0), false });

            return retVal;
        }
    }
}
