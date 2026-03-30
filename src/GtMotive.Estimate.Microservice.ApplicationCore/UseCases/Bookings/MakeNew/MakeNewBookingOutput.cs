using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew
{
    /// <summary>
    /// MakeNewBookingOutput.
    /// </summary>
    public class MakeNewBookingOutput(
        Guid id,
        Guid userId,
        Guid vehicleId,
        DateOnly startDate,
        DateOnly endDate,
        decimal totalPrice,
        string status) : IUseCaseOutput
    {
        /// <summary>
        /// Gets Id.
        /// </summary>
        public Guid Id { get; private set; } = id;

        /// <summary>
        /// Gets VehicleId.
        /// </summary>
        public Guid VehicleId { get; private set; } = vehicleId;

        /// <summary>
        /// Gets UserId.
        /// </summary>
        public Guid UserId { get; private set; } = userId;

        /// <summary>
        /// Gets StartDate.
        /// </summary>
        public DateOnly StartDate { get; private set; } = startDate;

        /// <summary>
        /// Gets EndDate.
        /// </summary>
        public DateOnly EndDate { get; private set; } = endDate;

        /// <summary>
        /// Gets TotalPrice.
        /// </summary>
        public decimal TotalPrice { get; private set; } = totalPrice;

        /// <summary>
        /// Gets Status.
        /// </summary>
        public string Status { get; private set; } = status;
    }
}
