using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Model;

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
                new Medicine { Id = 1, Name = "Brufen", Quantity = 400, Manufacturer = "Galenika", Usage = "Lek BRUFEN se može kratkotrajno upotrebljavati u terapiji bolnih stanja poput zubobolje, bolova nakon operativnih zahvata, bolnih menstruacija i glavobolje (uključujući migrenu).Brufen može da se koristi kod povreda mekih tkiva kao što su uganuća i istegnuća.Aktivna supstanca leka BRUFEN je ibuprofen i svaka tableta sadrži 200 mg ibuprofena", Weight = 200, SideEffects = { }, Reactions = { }, CompatibileMedicine = { } },
                new Medicine { Id = 2, Name = "Klacid", Quantity = 200, Manufacturer = "Galenika", Usage = "Klacid tablete se koriste za lečenje infekcija kao što su infekcije donjih disajnih puteva pluća, kao što je bronhitis i zapaljenje pluća, infekcije gornjih disajnih puteva kao što je infekcija grla i sinusa, infekcije kože i mekih tkiva, infekcije Helicobacter pylori kod pacijenata sa čirom na dvanaestopalačnom crevu Lek Klacid MR namenjen je odraslima i deci", Weight = 200, SideEffects = { }, Reactions = { }, CompatibileMedicine = { } },
                new Medicine { Id = 3, Name = "Paracetamol", Quantity = 250, Manufacturer = "Galenika", Usage = "Paracetamol je blag analgetik i antipiretik. Upotreba tableta se preporučuje za lečenje bolnih i febrilnih stanja kao što su glavobolja(uključujući i migrenu i tenzionu glavobolju), zubobolja, bol u leđima, reumatski, bolovi i bolovi u mišićima, dismenoreja, bol u grlu, kao i za ublažavanje groznice, odnosno tegoba i bolova koji prate prehladu i grip.Lek se takođe može koristiti kao simptomatska terapija kod bolova povezanih sa osteoartritisom", Weight = 200, SideEffects = { }, Reactions = { }, CompatibileMedicine = { } }
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
