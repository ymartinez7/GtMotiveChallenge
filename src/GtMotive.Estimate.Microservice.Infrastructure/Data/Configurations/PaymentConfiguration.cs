using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.HasKey(payment => payment.Id);

            builder.HasOne(p => p.Booking)
                   .WithOne(b => b.Payment)
                   .HasForeignKey<Payment>(p => p.BookingId);
        }
    }
}
