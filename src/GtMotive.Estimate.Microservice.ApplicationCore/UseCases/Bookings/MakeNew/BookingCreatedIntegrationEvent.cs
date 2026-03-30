using System;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew
{
    /// <summary>
    /// dwdwd.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="BookingCreatedIntegrationEvent"/> class.
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <param name="userId">userId.</param>
    /// <param name="vehicleId">vehicleId.</param>
    /// <param name="duration">duration.</param>
    /// <param name="priceForPeriod">priceForPeriod.</param>
    /// <param name="totalPrice">totalPrice.</param>
    /// <param name="status">status.</param>
    /// <param name="createdOnUtc">createdOnUtc.</param>
    public class BookingCreatedIntegrationEvent(
        Guid id,
        Guid userId,
        Guid vehicleId,
        DateRange duration,
        Money priceForPeriod,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc)
    {
        /// <summary>
        /// Gets or sets duration.
        /// </summary>
        public Guid Id { get; set; } = id;

        /// <summary>
        /// Gets or sets userId.
        /// </summary>
        public Guid UserId { get; set; } = userId;

        /// <summary>
        /// Gets or sets vehicleId.
        /// </summary>
        public Guid VehicleId { get; set; } = vehicleId;

        /// <summary>
        /// Gets or sets duration.
        /// </summary>
        public DateRange Duration { get; set; } = duration;

        /// <summary>
        /// Gets or sets priceForPeriod.
        /// </summary>
        public Money PriceForPeriod { get; set; } = priceForPeriod;

        /// <summary>
        /// Gets or sets totalPrice.
        /// </summary>
        public Money TotalPrice { get; set; } = totalPrice;

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public BookingStatus Status { get; set; } = status;

        /// <summary>
        /// Gets or sets createdOnUtc.
        /// </summary>
        public DateTime CreatedOnUtc { get; set; } = createdOnUtc;
    }
}
