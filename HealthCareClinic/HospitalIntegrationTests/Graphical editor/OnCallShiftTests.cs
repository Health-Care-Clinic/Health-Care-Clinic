using Hospital.Mapper;
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


    }
}
