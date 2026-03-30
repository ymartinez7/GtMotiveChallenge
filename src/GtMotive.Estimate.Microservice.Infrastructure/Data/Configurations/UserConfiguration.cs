using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(200)
                .HasConversion(firstName => firstName.Value, value => new FirstName(value));

            builder.Property(user => user.LastName)
                .HasMaxLength(200)
                .HasConversion(lastName => lastName.Value, value => new LastName(value));

            builder.Property(user => user.Email)
                .HasMaxLength(400)
                .HasConversion(email => email.Value, value => new Email(value));

            builder.HasIndex(user => user.Email)
                .IsUnique();

            builder.HasData(
                User.Create(
                        new FirstName("Yansel"),
                        new LastName("Martinez"),
                        new Email("YanselMartinez@test.com")),
                User.Create(
                        new FirstName("Test"),
                        new LastName("User"),
                        new Email("TestUser@test.com")));
        }
    }
}
