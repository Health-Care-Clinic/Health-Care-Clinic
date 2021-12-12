using System;
using System.Collections.Generic;
using System.Text;
using Integration.ApiKeys.Model;
using Integration.Notifications.Model;
using Integration.Pharmacy.Model;
using Microsoft.EntityFrameworkCore;

namespace Integration
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<ApiKey> ApiKeys { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackReply> FeedbackReplies { get; set; }
        public DbSet<Integration.Model.Medicine> Medicines { get; set; }
        public DbSet<PharmacyPromotion> PharmacyPromotions { get; set; }
        public DbSet<MedicationConsumption> MedicationConsumptions { get; set; }
        public DbSet<MedicationConsumption> Notifications { get; set; }
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ApiKey>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Feedback>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<FeedbackReply>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Integration.Model.Medicine>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<PharmacyPromotion>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<MedicationConsumption>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Notification>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MedicationConsumption>().HasData(
                new MedicationConsumption { Id = 1, Name = "Brufen", Amount = 30, Date = new DateTime(2021, 11, 10) },
                new MedicationConsumption { Id = 2, Name = "Brufen", Amount = 25, Date = new DateTime(2021, 11, 12) },
                new MedicationConsumption { Id = 3, Name = "Panadol", Amount = 40, Date = new DateTime(2021, 11, 10) },
                new MedicationConsumption { Id = 4, Name = "Paracetamol", Amount = 33, Date = new DateTime(2021, 11, 5) },
                new MedicationConsumption { Id = 5, Name = "Robenan", Amount = 15, Date = new DateTime(2021, 11, 9) },
                new MedicationConsumption { Id = 6, Name = "Andol", Amount = 10, Date = new DateTime(2021, 11, 13) }
                );
        }
    }
}
