﻿using Hospital.Events.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Mapper
{
    public class EventsDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public EventsDbContext() { }

        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Timestamp = new DateTime(2022, 01, 03, 12, 35, 42), Content = "", UserId = 1 },
                new Event { Id = 2, Timestamp = new DateTime(2022, 01, 03, 13, 32, 17), Content = "", UserId = 1 },
                new Event { Id = 3, Timestamp = new DateTime(2022, 01, 04, 18, 21, 8), Content = "", UserId = 2 },
                new Event { Id = 4, Timestamp = new DateTime(2022, 01, 05, 9, 41, 28), Content = "", UserId = 3 }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies();
        }

        private static string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST_EVENT") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA_EVENT") ?? "eventsDb";
            var user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "password";

            return
                $"Server={server};Port={port};Database={database};User ID={user};Password={password};";
        }
    }
}
