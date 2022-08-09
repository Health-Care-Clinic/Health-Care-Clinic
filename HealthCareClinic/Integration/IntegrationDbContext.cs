using System;
using System.Collections.Generic;
using System.Text;
using Integration.ApiKeys.Model;
using Integration.Notifications.Model;
using Integration.Pharmacy.Model;
using Integration.Promotions.Model;
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

            modelBuilder.Entity<PharmacyPromotion>().HasData(
                new PharmacyPromotion { Id = 1, Title = "Sale", Content = "Samo danas i sutra AKCIJA: Brufen 30% snizenje!!!", PharmacyName = "Tilda", Posted = true, StartTime = new DateTime(2021, 11, 10), EndTime = new DateTime(2022, 02, 10) },
                new PharmacyPromotion { Id = 2, Title = "New season", Content = "Od sutra stupa novi lek na trziste -> VIJAGRA samo tada", PharmacyName = "BENU", Posted = true, StartTime = new DateTime(2021, 12, 10), EndTime = new DateTime(2022, 02, 11) },
                new PharmacyPromotion { Id = 3, Title = "Sale", Content = "Finalna rasprodaja lekova...", PharmacyName = "Biljana i Luka", Posted = true, StartTime = new DateTime(2021, 11, 10), EndTime = new DateTime(2022, 02, 13) },
                new PharmacyPromotion { Id = 4, Title = "Black friday", Content = "Petkom idite u apoteku 'Jankovic'", PharmacyName = "Jankovic", Posted = true, StartTime = new DateTime(2021, 11, 10), EndTime = new DateTime(2022, 02, 15) },
                new PharmacyPromotion { Id = 5, Title = "Halloween action", Content = "Grrrr strasan demetrin", PharmacyName = "Medico", Posted = true, StartTime = new DateTime(2021, 11, 10), EndTime = new DateTime(2022, 02, 12) },
                new PharmacyPromotion { Id = 6, Title = "Sale", Content = "Svugde podji, u Rodu dodji", PharmacyName = "Roda", Posted = true, StartTime = new DateTime(2021, 11, 10), EndTime = new DateTime(2022, 02, 13) }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PharmacyDatabase;User id=postgres;Password=admin").UseLazyLoadingProxies();
            //optionsBuilder.UseNpgsql("Server=postgres-database;Port=5432;Database=PharmacyDatabase;User id=postgres;Password=admin").UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies();
        }
        private static string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "integrationDb";
            var user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "password";

            return
                $"Server={server};Port={port};Database={database};User ID={user};Password={password};";
        }
    }
}
