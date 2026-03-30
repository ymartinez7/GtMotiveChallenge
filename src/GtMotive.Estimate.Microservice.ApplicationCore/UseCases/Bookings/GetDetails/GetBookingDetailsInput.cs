using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.GetDetails
{
    /// <summary>
    /// GetBookingDetailsInput.
    /// </summary>
    public class GetBookingDetailsInput(Guid id) : IUseCaseInput
    {
        /// <summary>
        /// Gets Id.
        /// </summary>
        public Guid Id { get; private set; } = id;
    }
}
