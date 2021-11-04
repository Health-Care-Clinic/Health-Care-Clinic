using System;
using System.Collections.Generic;
using System.Text;
using Integration.ApiKeys.Model;
using Microsoft.EntityFrameworkCore;

namespace Integration
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<ApiKey> ApiKeys { get; set; }

        public DbSet<Message> Messages { get; set; }
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ApiKey>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
