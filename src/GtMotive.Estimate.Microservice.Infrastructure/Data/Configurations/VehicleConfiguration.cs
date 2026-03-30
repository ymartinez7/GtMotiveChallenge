using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.HasKey(x => x.Id);

            builder.OwnsOne(vehicle => vehicle.Model, modelBuilder =>
            {
                modelBuilder.Property(m => m.Brand).IsRequired();
                modelBuilder.Property(m => m.Name).IsRequired();
                modelBuilder.Property(m => m.Year).IsRequired();
            });

            builder.Property(vehicle => vehicle.Vpn)
                .HasMaxLength(200)
                .HasConversion(vsn => vsn.Value, value => new Vpn(value));

            builder.OwnsOne(x => x.Price, priceBuilder =>
            {
                priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
            });
        }
    }
}
