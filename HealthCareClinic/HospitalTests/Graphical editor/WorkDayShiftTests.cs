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
                context.WorkDayShift.Add(new WorkDayShift { Id = 1, Name = "First", StartTime = new DateTime(2022, 2, 22, 7, 0, 0), EndTime = new DateTime(2022, 2, 22, 13, 0, 0) });
                context.WorkDayShift.Add(new WorkDayShift { Id = 2, Name = "Second", StartTime = new DateTime(2022, 2, 22, 13, 0, 0), EndTime = new DateTime(2022, 2, 22, 19, 0, 0) });
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
                WorkDayShiftRepository roomRepository = new WorkDayShiftRepository(context);
                WorkDayShiftService roomService = new WorkDayShiftService(roomRepository);

                List<WorkDayShift> allWorkDayShifts = roomService.GetAll().ToList();
                foreach (WorkDayShift wds in context.WorkDayShift)
                {
                    context.WorkDayShift.Remove(wds);
                    context.SaveChanges();
                }

                Assert.Equal(2, allWorkDayShifts.Count);
            }
        }
    }
}
