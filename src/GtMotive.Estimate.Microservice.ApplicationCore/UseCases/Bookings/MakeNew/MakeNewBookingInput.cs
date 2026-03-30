using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew
{
    /// <summary>
    /// MakeNewBookingInput.
    /// </summary>
    public class MakeNewBookingInput(
        Guid userId,
        Guid vehicleId,
        DateOnly startDate,
        DateOnly endDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets UserId.
        /// </summary>
        public Guid UserId { get; private set; } = userId;

        /// <summary>
        /// Gets VehicleId.
        /// </summary>
        public Guid VehicleId { get; private set; } = vehicleId;

        /// <summary>
        /// Gets StartDate.
        /// </summary>
        public DateOnly StartDate { get; private set; } = startDate;

        /// <summary>
        /// Gets EndDate.
        /// </summary>
        public DateOnly EndDate { get; private set; } = endDate;
    }
}
