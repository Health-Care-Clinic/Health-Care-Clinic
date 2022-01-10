using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Advertisements.Model;
using Pharmacy.ApiKeys.Model;
using Pharmacy.ApiKeys.Repository;
using Pharmacy.Feedbacks.Model;
using Pharmacy.Model;
using Pharmacy.Prescriptions.Model;
using Pharmacy.Tendering.Model;

namespace Pharmacy
{
    public class PharmacyDbContext : DbContext
    {
        public DbSet<AdvertisementMedicine> AdvertisementMedicine { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackReply> FeedbackReplies { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderResponse> TenderResponses { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Brufen", Quantity = 400, Manufacturer = "Bayer", Usage = "Pain relief", Weight = 400, SideEffects = "Rash, Stomach pain", Reactions = "Headache", CompatibileMedicine = "Aspirin", Price = 4.50},
                new Medicine { Id = 2, Name = "Klacid", Quantity = 200, Manufacturer = "Bayer", Usage = "Lung infections, Bronchitis", Weight = 500, SideEffects = "Rash, Unconsciousness", Reactions = "Headache, Swelling", CompatibileMedicine = "Aspirin", Price = 5.0 },
                new Medicine { Id = 3, Name = "Paracetamol", Quantity = 250, Manufacturer = "Galenika", Usage = "Toothache, Headache", Weight = 500, SideEffects = "None", Reactions = "None", CompatibileMedicine = "Aspirin", Price = 5.25 }
            );

            modelBuilder.Entity<Tender>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Tender>()
                .OwnsOne(p => p.DateRange, y =>
                {
                    y.Property(y => y.Start)
                        .HasColumnName("DateRange_Start");
                    y.Property(y => y.End)
                        .HasColumnName("DateRange_End");
                });
            modelBuilder.Entity<Tender>()
                .OwnsMany(p => p.TenderItems);


            modelBuilder.Entity<TenderResponse>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<TenderResponse>()
                .OwnsOne(p => p.TotalPrice, y =>
                {
                    y.Property(y => y.Amount)
                        .HasColumnName("TotalPrice_Amount");
                });
            modelBuilder.Entity<TenderResponse>()
                .OwnsMany(p => p.TenderItems);

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
            modelBuilder.Entity<Tender>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Advertisement>()
              .Property(p => p.Id)
              .ValueGeneratedOnAdd();

             modelBuilder.Entity<Advertisement>().HasData(
                new Advertisement { Id = 1, Title = "Super ponuda", Description = "NIkada jeftiniji popust"}
            );

            modelBuilder.Entity<AdvertisementMedicine>().HasKey(sc => new { sc.AdvertisementId, sc.MedicineId });

            modelBuilder.Entity<AdvertisementMedicine>()
                .HasOne<Medicine>(sc => sc.Medicine)
                .WithMany(s => s.AdvertisementMedicines)
                .HasForeignKey(sc => sc.MedicineId);


            modelBuilder.Entity<AdvertisementMedicine>()
                .HasOne<Advertisement>(sc => sc.Advertisement)
                .WithMany(s => s.AdvertisementMedicines)
                .HasForeignKey(sc => sc.AdvertisementId);




        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PharmacyDatabase;User id=postgres;Password=admin").UseLazyLoadingProxies();
            //optionsBuilder.UseNpgsql("Server=postgres-database;Port=5432;Database=PharmacyDatabase;User id=postgres;Password=admin").UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies();
        }
        private static string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "127.0.0.1";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "pharmacyDb";
            var user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "password";

            return
                $"Server={server};Port={port};Database={database};User ID={user};Password={password};";
        }
    }
}
