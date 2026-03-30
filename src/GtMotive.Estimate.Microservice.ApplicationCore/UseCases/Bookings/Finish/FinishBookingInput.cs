using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Finish
{
    /// <summary>
    /// FinishBookingInput.
    /// </summary>
    public class FinishBookingInput(Guid id,
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
