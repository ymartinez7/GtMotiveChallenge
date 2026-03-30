using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay
{
    /// <summary>
    /// PayBookingInput.
    /// </summary>
    public class PayBookingInput(
        Guid id,
        PaymentDetailInput payment) : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public Guid Id { get; set; } = id;

        /// <summary>
        /// Gets or sets PaymentDetails.
        /// </summary>
        public PaymentDetailInput PaymentDetails { get; set; } = payment;
    }
}
