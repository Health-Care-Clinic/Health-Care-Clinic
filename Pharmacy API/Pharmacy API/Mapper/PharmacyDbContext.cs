using Microsoft.EntityFrameworkCore;
using Pharmacy_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy_API.Mapper
{
    public class PharmacyDbContext: DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }

        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Brufen", Quantity = 400},
                new Medicine { Id = 2, Name = "Klacid", Quantity = 200 },
                new Medicine { Id = 3, Name = "Paracetamol", Quantity = 250 }
                );
        }
    }
}
