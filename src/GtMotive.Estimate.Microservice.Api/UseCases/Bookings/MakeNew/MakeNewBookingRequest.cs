using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.MakeNew
{
    public class MakeNewBookingRequest(
        Guid userId,
        Guid vehicleId,
        DateOnly startDate,
        DateOnly endDate) : IRequest<IWebApiPresenter>
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
