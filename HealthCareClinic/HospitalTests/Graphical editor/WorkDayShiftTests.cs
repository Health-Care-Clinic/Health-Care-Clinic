using Hospital.Mapper;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Service;
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
                context.Doctors.Add(new Doctor { Id = 1, Name = "Nikola", Surname = "Nikolic", Gender = "male", BirthDate = new System.DateTime(1981, 05, 06), Salary = 80000.0, Address = "Brace Radica 15", Phone = "0697856665", Email = "nikolanikolic@gmail.com", Username = "nikola", Password = "nikola", EmploymentDate = new System.DateTime(2021, 06, 10), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 1, WorkShiftId = 1 });
                context.Doctors.Add(new Doctor { Id = 2, Name = "Marko", Surname = "Markovic", Gender = "male", BirthDate = new System.DateTime(1981, 05, 07), Salary = 90000.0, Address = "Brace Radica 16", Phone = "0697856666", Email = "markomarkovic@gmail.com", Username = "marko", Password = "marko", EmploymentDate = new System.DateTime(2021, 06, 11), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 2, WorkShiftId = 2 });
                context.Doctors.Add(new Doctor { Id = 3, Name = "Pero", Surname = "Peric", Gender = "male", BirthDate = new System.DateTime(1981, 05, 08), Salary = 100000.0, Address = "Brace Radica 17", Phone = "0697856667", Email = "peroperic@gmail.com", Username = "pero", Password = "pero", EmploymentDate = new System.DateTime(2021, 06, 12), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 3, WorkShiftId = 2 });
                context.SaveChanges();
            }

            return options;
        }

        private void ClearStubRepository(HospitalDbContext context) 
        {
            foreach (WorkDayShift wds in context.WorkDayShift)
            {
                context.WorkDayShift.Remove(wds);
                context.SaveChanges();
            }
            foreach (Doctor d in context.Doctors)
            {
                context.Doctors.Remove(d);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Get_all_work_day_shifts()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                WorkDayShiftRepository workDayShiftRepository = new WorkDayShiftRepository(context);
                DoctorRepository doctorRepository = new DoctorRepository(context);
                WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayShiftRepository, doctorRepository);

                List<WorkDayShift> allWorkDayShifts = workDayShiftService.GetAll().ToList();
                ClearStubRepository(context);

                Assert.Equal(2, allWorkDayShifts.Count);
            }
        }

        [Fact]
        public void Remove_work_day_shift()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                WorkDayShiftRepository workDayShiftRepository = new WorkDayShiftRepository(context);
                DoctorRepository doctorRepository = new DoctorRepository(context);
                WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayShiftRepository, doctorRepository);

                workDayShiftService.RemoveWorkDayShift(1);
                List<WorkDayShift> allWorkDayShifts = workDayShiftService.GetAll().ToList();
                ClearStubRepository(context);

                Assert.Single(allWorkDayShifts);
            }
        }

        [Fact]
        public void Remove_work_day_shift_and_check_doctor_work_day_shifts()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                WorkDayShiftRepository workDayShiftRepository = new WorkDayShiftRepository(context);
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);
                WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayShiftRepository, doctorRepository);

                List<WorkDayShift> allWorkDayShifts = workDayShiftService.GetAll().ToList();
                workDayShiftService.RemoveWorkDayShift(1);
                Doctor doctor = doctorService.GetOneById(1);
                ClearStubRepository(context);

                Assert.Equal(2, doctor.WorkShiftId);
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
                DoctorRepository doctorRepository = new DoctorRepository(context);
                WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayShiftRepository, doctorRepository);

                bool shiftAdded = workDayShiftService.AddWorkDayShift(new WorkDayShift { Id = 3, Name = "Third", StartTime = shiftStartTime, EndTime = shiftEndTime });
                ClearStubRepository(context);

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

        [Theory]
        [MemberData(nameof(DataForEdit))]
        public void Edit_work_day_shift(DateTime shiftStartTime, DateTime shiftEndTime, bool edited)
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                WorkDayShiftRepository workDayShiftRepository = new WorkDayShiftRepository(context);
                DoctorRepository doctorRepository = new DoctorRepository(context);
                WorkDayShiftService workDayShiftService = new WorkDayShiftService(workDayShiftRepository, doctorRepository);

                bool shiftEdited = workDayShiftService.EditWorkDayShift(new WorkDayShift { Id = 1, Name = "Third", StartTime = shiftStartTime, EndTime = shiftEndTime });
                ClearStubRepository(context);

                Assert.Equal(shiftEdited, edited);
            }
        }

        public static IEnumerable<object[]> DataForEdit()
        {
            var retVal = new List<object[]>();

            retVal.Add(new object[] { new DateTime(2022, 2, 22, 9, 0, 0), new DateTime(2022, 2, 22, 11, 0, 0), true });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 7, 0, 0), new DateTime(2022, 2, 22, 13, 0, 0), true });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 10, 0, 0), new DateTime(2022, 2, 22, 12, 0, 0), true });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 9, 30, 0), new DateTime(2022, 2, 22, 10, 30, 0), true });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 6, 30, 0), new DateTime(2022, 2, 22, 13, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 12, 0, 0), new DateTime(2022, 2, 22, 14, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 14, 0, 0), new DateTime(2022, 2, 22, 15, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 18, 0, 0), new DateTime(2022, 2, 22, 20, 0, 0), false });
            retVal.Add(new object[] { new DateTime(2022, 2, 22, 12, 0, 0), new DateTime(2022, 2, 22, 11, 0, 0), false });

            return retVal;
        }
    }
}
