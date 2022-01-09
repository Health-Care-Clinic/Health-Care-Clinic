using Hospital.Mapper;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalUnitTests
{
    public class DoctorsShiftsTests
    {
        private DbContextOptions<HospitalDbContext> CreateStubRepository()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Doctors")
            .Options;

            using (var context = new HospitalDbContext(options))
            {
                context.Doctors.Add(new Doctor { Id = 1, Name = "Nikola", Surname = "Nikolic", Gender = "male", BirthDate = new System.DateTime(1981, 05, 06), Salary = 80000.0, Address = "Brace Radica 15", Phone = "0697856665", Email = "nikolanikolic@gmail.com", Username = "nikola", Password = "nikola", EmploymentDate = new System.DateTime(2021, 06, 10), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 1, WorkShiftId = -1 });
                context.Doctors.Add(new Doctor { Id = 2, Name = "Marko", Surname = "Markovic", Gender = "male", BirthDate = new System.DateTime(1981, 05, 07), Salary = 90000.0, Address = "Brace Radica 16", Phone = "0697856666", Email = "markomarkovic@gmail.com", Username = "marko", Password = "marko", EmploymentDate = new System.DateTime(2021, 06, 11), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 2, WorkShiftId = 1 });
                context.Doctors.Add(new Doctor { Id = 3, Name = "Pero", Surname = "Peric", Gender = "male", BirthDate = new System.DateTime(1981, 05, 08), Salary = 100000.0, Address = "Brace Radica 17", Phone = "0697856667", Email = "peroperic@gmail.com", Username = "pero", Password = "pero", EmploymentDate = new System.DateTime(2021, 06, 12), WorkDay = null, Specialty = "General medicine", PrimaryRoom = 3, WorkShiftId = 2 });
                context.SaveChanges();
            }

            return options;
        }

        private void ClearStubRepository(HospitalDbContext context)
        {
            foreach (Doctor d in context.Doctors)
            {
                context.Doctors.Remove(d);
                context.SaveChanges();
            }
        }

        [Fact]
        public void Get_doctors_shift()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                Doctor doctor = doctorService.GetOneById(1);
                ClearStubRepository(context);

                Assert.Equal(-1, doctor.WorkShiftId);
            }
        }

        [Fact]
        public void Add_shift_to_doctor()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                Doctor doctor = doctorService.GetOneById(1);
                doctor.WorkShiftId = 1;
                doctorService.addShiftToDoctor(doctor);

                Doctor changedDoctor = doctorService.GetOneById(1);
                ClearStubRepository(context);

                Assert.Equal(1, changedDoctor.WorkShiftId);
            }
        }

        [Fact]
        public void Edit_doctor_shift()
        {
            var options = CreateStubRepository();

            using (var context = new HospitalDbContext(options))
            {
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                Doctor doctor = doctorService.GetOneById(2);
                doctor.WorkShiftId = 2;
                doctorService.addShiftToDoctor(doctor);

                Doctor changedDoctor = doctorService.GetOneById(2);
                ClearStubRepository(context);

                Assert.Equal(2, changedDoctor.WorkShiftId);
            }
        }
    }
}
