namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Finish
{
    /// <summary>
    /// FinishBookingOutput.
    /// </summary>
    public class FinishBookingOutput(string message) : IUseCaseOutput
    {
        /// <summary>
        /// Gets Message.
        /// </summary>
        public string Message { get; private set; } = message;
    }
}
