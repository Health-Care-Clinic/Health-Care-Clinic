using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pharmacy;
using System;
using System.IO;
using Xunit;

namespace PharmacyIntegrationTests
{
    public class PhrarmacyTenderingTest
    {
        [Fact]
        public void Add_tender()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<PharmacyDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PharmacyDbConnectionString"));
            var _context = new PharmacyDbContext(optionsBuilder.Options);
        }
    }
}
