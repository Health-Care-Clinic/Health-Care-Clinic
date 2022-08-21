using Hospital.Mapper;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Medical_records.Service;
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
    public class WorkDayShiftTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "WorkDayShifts")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.WorkDayShift.Add(new WorkDayShift { Id = 1, Name = "First", WorkHour = new WorkHour(new DateTime(2022, 2, 22, 9, 0, 0),new DateTime(2022, 2, 22, 11, 0, 0)) });
                context.WorkDayShift.Add(new WorkDayShift { Id = 2, Name = "Second", WorkHour = new WorkHour(new DateTime(2022, 2, 22, 13, 0, 0), new DateTime(2022, 2, 22, 16, 0, 0)) });
                context.Doctors.Add(new Doctor { Id = 1, Name = "Nikola", Surname = "Nikolic", Gender = "male", BirthDate = new System.DateTime(1981, 05, 06), Salary = 80000.0, Address = "Brace Radica 15", Phone = "0697856665", Email = "nikolanikolic@gmail.com", Username = "nikola", Password = "nikola", EmploymentDate = new System.DateTime(2021, 06, 10), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 1, WorkShiftId = 1 });
                context.Doctors.Add(new Doctor { Id = 2, Name = "Marko", Surname = "Markovic", Gender = "male", BirthDate = new System.DateTime(1981, 05, 07), Salary = 90000.0, Address = "Brace Radica 16", Phone = "0697856666", Email = "markomarkovic@gmail.com", Username = "marko", Password = "marko", EmploymentDate = new System.DateTime(2021, 06, 11), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 2, WorkShiftId = 2 });
                context.Doctors.Add(new Doctor { Id = 3, Name = "Pero", Surname = "Peric", Gender = "male", BirthDate = new System.DateTime(1981, 05, 08), Salary = 100000.0, Address = "Brace Radica 17", Phone = "0697856667", Email = "peroperic@gmail.com", Username = "pero", Password = "pero", EmploymentDate = new System.DateTime(2021, 06, 12), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 3, WorkShiftId = 2 });
                context.SaveChanges();
            }

            return options;
        }

        [Fact]
        public void Get_all_work_day_shifts()
        {
            var workDayShifts = new List<WorkDayShift>();
            var workDayStubRepository = new Mock<IWorkDayShiftRepository>();
            var doctorStubRepository = new Mock<IDoctorRepository>();
            workDayShifts.Add(new WorkDayShift { Id = 1, Name = "First", WorkHour = new WorkHour(new DateTime(2022, 2, 22, 9, 0, 0), new DateTime(2022, 2, 22, 11, 0, 0)) });
            workDayStubRepository.Setup(m => m.GetAll()).Returns(workDayShifts);
            WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayStubRepository.Object, doctorStubRepository.Object);

            var allWorkDayShifts = workDayShiftService.GetAll().ToList();

            Assert.Single(allWorkDayShifts);
        }

        [Fact]
        public void Remove_work_day_shift()
        {
            var workDayShifts = new List<WorkDayShift>();
            var workDayStubRepository = new Mock<IWorkDayShiftRepository>();
            var doctorStubRepository = new Mock<IDoctorRepository>();
            var workDayShiftId = 1;
            workDayShifts.Add(new WorkDayShift { Id = 1, Name = "First", WorkHour = new WorkHour(new DateTime(2022, 2, 22, 9, 0, 0), new DateTime(2022, 2, 22, 11, 0, 0)) });
            workDayStubRepository.Setup(m => m.GetAll()).Returns(workDayShifts);
            WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayStubRepository.Object, doctorStubRepository.Object);

            workDayShiftService.RemoveWorkDayShift(workDayShiftId);

            workDayStubRepository.Verify(r => r.RemoveById(workDayShiftId), Times.Once);
        }

        [Fact]
        public void Add_work_day_shift_when_overlap_with_other_shifts()
        {
            var workDayShifts = new List<WorkDayShift>();
            var workDayStubRepository = new Mock<IWorkDayShiftRepository>();
            var doctorStubRepository = new Mock<IDoctorRepository>();
            workDayShifts.Add(new WorkDayShift { Id = 1, Name = "First", WorkHour = new WorkHour(new DateTime(2022, 2, 22, 9, 0, 0), new DateTime(2022, 2, 22, 11, 0, 0)) });
            var newWorkShift = new WorkDayShift { Id = 2, Name = "First", WorkHour = new WorkHour(new DateTime(2022, 2, 22, 10, 0, 0), new DateTime(2022, 2, 22, 12, 0, 0)) };
            workDayStubRepository.Setup(m => m.GetAll()).Returns(workDayShifts);
            WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayStubRepository.Object, doctorStubRepository.Object);

            bool shiftAdded = workDayShiftService.AddWorkDayShift(newWorkShift);

            workDayStubRepository.Verify(r => r.Add(newWorkShift), Times.Never);
            Assert.False(shiftAdded);
        }

        [Fact]
        public void Add_work_day_shift_when_not_overlap_with_other_shifts()
        {
            var workDayStubRepository = new Mock<IWorkDayShiftRepository>();
            var doctorStubRepository = new Mock<IDoctorRepository>();
            var newWorkShift = new WorkDayShift { Id = 2, Name = "First", WorkHour = new WorkHour(new DateTime(2022, 2, 22, 10, 0, 0), new DateTime(2022, 2, 22, 12, 0, 0)) };
            workDayStubRepository.Setup(m => m.GetAll()).Returns(new List<WorkDayShift>());
            WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayStubRepository.Object, doctorStubRepository.Object);

            bool shiftAdded = workDayShiftService.AddWorkDayShift(newWorkShift);

            workDayStubRepository.Verify(r => r.Add(newWorkShift), Times.Once);
            Assert.True(shiftAdded);
        }

        [Theory]
        [MemberData(nameof(DataForEdit))]
        public void Edit_work_day_shift(DateTime shiftStartTime, DateTime shiftEndTime, bool edited)
        {
            var workDayShifts = new List<WorkDayShift>();
            var workDayStubRepository = new Mock<IWorkDayShiftRepository>();
            var doctorStubRepository = new Mock<IDoctorRepository>();
            workDayShifts.Add(new WorkDayShift { Id = 1, Name = "First", WorkHour = new WorkHour(new DateTime(2022, 2, 22, 9, 0, 0), new DateTime(2022, 2, 22, 11, 0, 0)) });
            var newWorkShift = new WorkDayShift { Id = 2, Name = "First", WorkHour = new WorkHour(shiftStartTime, shiftEndTime) };
            workDayStubRepository.Setup(m => m.GetAll()).Returns(workDayShifts);
            WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayStubRepository.Object, doctorStubRepository.Object);

            bool shiftEdited = workDayShiftService.EditWorkDayShift(newWorkShift);

            Assert.Equal(shiftEdited, edited);
        }

        public static IEnumerable<object[]> DataForEdit()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { new DateTime(2022, 2, 22, 9, 0, 0), new DateTime(2022, 2, 22, 11, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 12, 0, 0), new DateTime(2022, 2, 22, 13, 0, 0), true });

            return retVal;
        }
    }
}
