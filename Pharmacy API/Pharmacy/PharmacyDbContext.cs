using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pharmacy.ApiKeys.Model;
using Pharmacy.Feedbacks.Model;
using Pharmacy.Model;
using Pharmacy.Prescriptions.Model;

namespace Pharmacy
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackReply> FeedbackReplies { get; set; }

        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Brufen", Quantity = 400, Manufacturer = "Bayer", Usage = "Pain relief", Weight = 400, SideEffects = "Rash, Stomach pain", Reactions = "Headache", CompatibileMedicine = "Aspirin"},
                new Medicine { Id = 2, Name = "Klacid", Quantity = 200, Manufacturer = "Bayer", Usage = "Lung infections, Bronchitis", Weight = 500, SideEffects = "Rash, Unconsciousness", Reactions = "Headache, Swelling", CompatibileMedicine = "Aspirin" },
                new Medicine { Id = 3, Name = "Paracetamol", Quantity = 250, Manufacturer = "Galenika", Usage = "Toothache, Headache", Weight = 500, SideEffects = "None", Reactions = "None", CompatibileMedicine = "Aspirin" }
            );

            modelBuilder.Entity<ApiKey>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Message>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Feedback>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<FeedbackReply>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
