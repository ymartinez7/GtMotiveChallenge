namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay
{
    /// <summary>
    /// PayBookingOutput.
    /// </summary>
    public class PayBookingOutput(string message) : IUseCaseOutput
    {
        /// <summary>
        /// Gets Message.
        /// </summary>
        public string Message { get; private set; } = message;
    }
}
