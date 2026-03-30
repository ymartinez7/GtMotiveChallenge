using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ArgumentNullException.ThrowIfNull(optionsBuilder);

            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings =>
            {
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
