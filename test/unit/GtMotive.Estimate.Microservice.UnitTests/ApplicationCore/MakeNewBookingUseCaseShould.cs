using System;
using System.Globalization;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    /// <summary>
    /// MakeNewBookingShould.
    /// </summary>
    public class MakeNewBookingUseCaseShould
    {
        /// <summary>
        /// CreateBookingShouldThrowAnExceptionwWhenInvalidDateRange.
        /// </summary>
        /// <param name="startDate">dfssf.</param>
        /// <param name="endDate">fggsg.</param>
        [Theory]
        [InlineData("2026-02-01", "2026-01-10")]
        [InlineData("2026-01-01", "2026-01-01")]
        public void CreateBookingShouldThrowAnExceptionwWhenInvalidDateRange(string startDate, string endDate)
        {
            // Arrange
            var start = DateOnly.Parse(startDate, CultureInfo.InvariantCulture);
            var end = DateOnly.Parse(endDate, CultureInfo.InvariantCulture);

            // Act
            var exception = Assert.Throws<BookingDateRangeException>(
                () => new DateRange(start, end));

            // Assert
            Assert.IsType<BookingDateRangeException>(exception);
        }

        /// <summary>
        /// CreateBookingShouldReturnANewBooking.
        /// </summary>
        [Fact]
        public void CreateBookingShouldReturnANewBooking()
        {
            // Arrange
            var user = User.Create(
                UserData.FirstName,
                UserData.LastName,
                UserData.Email);

            var price = new Money(
                10.0m,
                Currency.USD);

            var vehicle = VehicleData.Create(price);

            var duration = new DateRange(
                new DateOnly(2024, 1, 1),
                new DateOnly(2024, 1, 10));

            // Act
            var booking = Booking.Reserve(
                vehicle,
                user.Id,
                duration,
                DateTime.UtcNow);

            // Assert
            Assert.NotNull(user);
            Assert.NotNull(vehicle);
            Assert.NotNull(booking);
            Assert.NotEqual(Guid.Empty, user.Id);
            Assert.NotEqual(Guid.Empty, vehicle.Id);
            Assert.NotEqual(Guid.Empty, booking.Id);
            Assert.Equal(BookingStatus.Pending, booking.Status);
        }
    }
}
