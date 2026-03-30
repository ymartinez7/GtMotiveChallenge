namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel
{
    /// <summary>
    /// CancelBookingOutput.
    /// </summary>
    public class CancelBookingOutput(string message) : IUseCaseOutput
    {
        /// <summary>
        /// Gets Message.
        /// </summary>
        public string Message { get; private set; } = message;
    }
}
