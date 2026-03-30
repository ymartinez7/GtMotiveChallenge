using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel
{
    /// <summary>
    /// CancelBookingInput.
    /// </summary>
    public class CancelBookingInput(Guid id,
        string observations) : IUseCaseInput
    {
        /// <summary>
        /// Gets Id.
        /// </summary>
        public Guid Id { get; private set; } = id;

        /// <summary>
        /// Gets Observations.
        /// </summary>
        public string Observations { get; private set; } = observations;
    }
}
