using Hospital.Mapper;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Graphical_editor
{
    public class DoctorsShiftsTests
    {
        [Fact]
        public void Get_doctors_shift()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            DoctorRepository doctorRepository = new DoctorRepository(_context);
            DoctorService doctorService = new DoctorService(doctorRepository);

            Doctor doctor = doctorRepository.GetById(3);

            Assert.NotEqual(-1, doctor.WorkShiftId);
        }

        [Fact]
        public void Add_shift_to_doctor()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            DoctorRepository doctorRepository = new DoctorRepository(_context);
            DoctorService doctorService = new DoctorService(doctorRepository);

            Doctor doctor = doctorRepository.GetById(3);
            doctor.WorkShiftId = 1;
            doctorService.addShiftToDoctor(doctor);

            Doctor d = doctorRepository.GetById(3);

            Assert.Equal(1, d.WorkShiftId);
        }

        [Fact]
        public void Edit_doctors_shift()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            DoctorRepository doctorRepository = new DoctorRepository(_context);
            DoctorService doctorService = new DoctorService(doctorRepository);

            Doctor doctor = doctorRepository.GetById(2);
            doctor.WorkShiftId = 1;
            doctorService.addShiftToDoctor(doctor);

            Doctor d = doctorRepository.GetById(2);

            Assert.Equal(1, d.WorkShiftId);
        }
    }
}
