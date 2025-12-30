using AgrimanAPI.Infrastructure.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;



namespace AgrimanAPI.Infrastructure.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<AgriWorkEntity> AgriWorks { get; set; }
        public DbSet<AgriThingEntity> AgriThings { get; set; }
        public DbSet<PackingEntity> PackingsEntity { get; set; }
        public DbSet<TransactionThingsEntity> TransactionThingsEntity { get; set; }
        public DbSet<TransactionWorkDetailEntity> TransactionWorkDetails { get; set; }
        public DbSet<PackingDetail> PackingTransactions { get; set; }
        public DbSet<Packing> Packings { get; set; }

        public DbSet<ProfitLossEntity> ProfitLossDetails { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Master tables
            //modelBuilder.Entity<AgriWorkEntity>()
            //    .ToTable("work_details")
            //    .Property(p => p.Amount).HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<AgriThingEntity>()
            //    .ToTable("things_details")
            //    .Property(p => p.Amount).HasColumnType("decimal(18,2)");

            // Transaction tables
            modelBuilder.Entity<TransactionWorkDetailEntity>()
                .ToTable("TransactionWorkDetails") // exact table name
                .Property(p => p.Amount).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TransactionThingsEntity>()
                .ToTable("TransactionThingsDetails") // exact table name
                .Property(p => p.AmountSpend).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PackingDetail>()
                .ToTable("packing_transactions")
                .Property(p => p.UnitAmount).HasColumnType("decimal(18,2)");

            // Profit/Loss table
            modelBuilder.Entity<ProfitLossEntity>()
                .ToTable("profit_loss")
                .Property(p => p.WorkTotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ProfitLossEntity>()
                .Property(p => p.ThingsTotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ProfitLossEntity>()
                .Property(p => p.PackingTotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ProfitLossEntity>()
                .Property(p => p.ProfitOrLoss).HasColumnType("decimal(18,2)");


            // Master data seeding
            modelBuilder.Entity<AgriWorkEntity>().HasData(

                new AgriWorkEntity
                {
                    Id = 1,
                    WorkName = "Ploughing",
                    WorkDescription = "Loosening and preparing the soil for cultivation"
                },
                new AgriWorkEntity
                {
                    Id = 2,
                    WorkName = "Sowing",
                    WorkDescription = "Planting seeds into the prepared soil"
                },
                new AgriWorkEntity
                {
                    Id = 3,
                    WorkName = "Irrigation",
                    WorkDescription = "Supplying water to crops at regular intervals"
                },
                new AgriWorkEntity
                {
                    Id = 4,
                    WorkName = "Fertilization",
                    WorkDescription = "Applying nutrients to improve crop growth"
                },
                new AgriWorkEntity
                {
                    Id = 5,
                    WorkName = "Weed Control",
                    WorkDescription = "Removing or controlling unwanted plants"
                },
                new AgriWorkEntity
                {
                    Id = 6,
                    WorkName = "Herbicide Spraying",
                    WorkDescription = "Spraying chemicals to control weeds and pests"
                },
                new AgriWorkEntity
                {
                    Id = 7,
                    WorkName = "Harvesting",
                    WorkDescription = "Collecting mature crops from the field"
                },
                new AgriWorkEntity
                {
                    Id = 8,
                    WorkName = "Storage",
                    WorkDescription = "Storing harvested crops safely to prevent damage"
                },
                new AgriWorkEntity
                {
                    Id = 9,
                    WorkName = "Packing",
                    WorkDescription = "Packing crops for transport or sale"
                },
                new AgriWorkEntity
                {
                    Id = 10,
                    WorkName = "Export",
                    WorkDescription = "Sending agricultural products to other regions or countries"
                }

            );

            modelBuilder.Entity<AgriThingEntity>().HasData(
                new AgriThingEntity
                {
                    Id = 1,
                    ThingName = "Seeds"
                },
                new AgriThingEntity
                {
                    Id = 2,
                    ThingName = "Soil"
                },
                new AgriThingEntity
                {
                    Id = 3,
                    ThingName = "Water"
                },
                new AgriThingEntity
                {
                    Id = 4,
                    ThingName = "Fertilizer"
                },
                new AgriThingEntity
                {
                    Id = 5,
                    ThingName = "Manure"
                },
                new AgriThingEntity
                {
                    Id = 6,
                    ThingName = "Pesticide"
                },
                new AgriThingEntity
                {
                    Id = 7,
                    ThingName = "Form Machinery"
                },
                new AgriThingEntity
                {
                    Id = 8,
                    ThingName = "Irrigation systems"
                },
                new AgriThingEntity
                {
                    Id = 9,
                    ThingName = "Fungicide"
                },
                new AgriThingEntity
                {
                    Id = 10,
                    ThingName = "Bio Fertilizer"
                }
             );


            modelBuilder.Entity<PackingEntity>().HasData(
                new PackingEntity
                {
                    Id = 1,
                    PackingName = "GunningBag",
                    Unit = 1,
                    UnitAmount = 1000
                },
                new PackingEntity
                {
                    Id = 2,
                    PackingName = "Kg",
                    Unit = 1,
                    UnitAmount = 100
                }
            );
        }



       
    }
}

