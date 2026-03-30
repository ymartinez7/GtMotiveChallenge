using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.HasKey(booking => booking.Id);

            builder.OwnsOne(booking => booking.PriceForPeriod, builderPrice =>
            {
                builderPrice.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.OwnsOne(booking => booking.TotalPrice, builderPrice =>
            {
                builderPrice.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });

            builder.OwnsOne(booking => booking.Duration);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Vehicle)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VehicleId);
        }
    }
}
