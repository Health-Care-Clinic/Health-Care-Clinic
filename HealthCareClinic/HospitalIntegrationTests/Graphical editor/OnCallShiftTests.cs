using Hospital.Mapper;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Graphical_editor
{
   public class OnCallShiftTests
    {
        [Fact]
        public void Get_all_doctor_on_call_shifts()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);
            OnCallShiftRepository onCallShiftRepository = new OnCallShiftRepository(_context);
            OnCallShiftService onCallShiftService = new OnCallShiftService(onCallShiftRepository);

            int numberOfCallShifts = onCallShiftService.GetOnCallShiftByDoctorId(1).Count;

            Assert.True(numberOfCallShifts > 0);
        }

        [Fact]
        public void Get_on_call_shift_by_month()
        {
          var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);
            OnCallShiftRepository onCallShiftRepository = new OnCallShiftRepository(_context);
            OnCallShiftService onCallShiftService = new OnCallShiftService(onCallShiftRepository);
          
          int numberOfCallShifts = onCallShiftService.GetNumOfOnCallShift(1,2,2022);

            Assert.True(1 <= numberOfCallShifts);
        }

        [Fact]
        public void Change_on_call_shift()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);
            OnCallShiftRepository onCallShiftRepository = new OnCallShiftRepository(_context);
            OnCallShiftService onCallShiftService = new OnCallShiftService(onCallShiftRepository);
            _context.Database.BeginTransaction();
            OnCallShift shift = onCallShiftService.GetOneById(1);

            onCallShiftService.ChangeById(new OnCallShift(1,new DateTime(),1));

            _context.ChangeTracker.Clear();

            OnCallShift shift2 = onCallShiftService.GetOneById(1);
            Assert.True(shift.Date != shift2.Date);

        }

        [Fact]
        public void Add_on_call_shift_to_doctor()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("HospitalDbConnectionString"));
            var _context = new HospitalDbContext(optionsBuilder.Options);

            OnCallShiftRepository onCallShiftRepository = new OnCallShiftRepository(_context);
            OnCallShiftService onCallShiftService = new OnCallShiftService(onCallShiftRepository);
            List<OnCallShift> onCallShiftsBefore = (List<OnCallShift>)onCallShiftRepository.GetAll();
            OnCallShift newShift = new OnCallShift(7, new DateTime(2022, 1, 1), 1);

            onCallShiftService.Add(newShift);
            List<OnCallShift> onCallShifts = (List<OnCallShift>)onCallShiftRepository.GetAll();
            onCallShiftService.Remove(newShift);

            Assert.Equal(onCallShiftsBefore.Count+1, onCallShifts.Count);
        }


    }
}
