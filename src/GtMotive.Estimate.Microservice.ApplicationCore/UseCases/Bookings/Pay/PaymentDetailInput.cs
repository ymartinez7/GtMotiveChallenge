using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay
{
    /// <summary>
    /// PaymentDetailInput.
    /// </summary>
    public class PaymentDetailInput(
        string paymentType,
        int cardNumber,
        DateOnly expirationDate)
    {
        /// <summary>
        /// Gets or sets Paymentype.
        /// </summary>
        public string Paymentype { get; set; } = paymentType;

        /// <summary>
        /// Gets or sets CardNumber.
        /// </summary>
        public int CardNumber { get; set; } = cardNumber;

        /// <summary>
        /// Gets or sets ExpirationDate.
        /// </summary>
        public DateOnly ExpirationDate { get; set; } = expirationDate;
    }
}
