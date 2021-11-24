using System;
using System.Collections.Generic;
using System.Text;
using Integration.ApiKeys.Model;
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
        }
    }
}
