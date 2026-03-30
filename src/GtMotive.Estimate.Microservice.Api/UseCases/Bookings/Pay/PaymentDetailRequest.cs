using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Bookings.Pay
{
    public class PaymentDetailRequest
    {
        /// <summary>
        /// Gets or sets Paymentype.
        /// </summary>
        public string Paymentype { get; set; }

        /// <summary>
        /// Gets or sets CardNumber.
        /// </summary>
        public int? CardNumber { get; set; }

        /// <summary>
        /// Gets or sets ExpirationDate.
        /// </summary>
        public DateOnly? ExpirationDate { get; set; }
    }
}
