using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Payment entity.
    /// </summary>
    public class Payment : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        private Payment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        /// <param name="id">ppf.</param>
        /// <param name="bookingId">ppdd.</param>
        /// <param name="paymentype">ppld.</param>
        /// <param name="paidOnUtc">ppdllm.</param>
        private Payment(
            Guid id,
            Guid bookingId,
            Paymentype paymentype,
            DateTime paidOnUtc)
            : base(id)
        {
            BookingId = bookingId;
            Paymentype = paymentype;
            PaidOnUtc = paidOnUtc;
        }

        /// <summary>
        /// Gets bookingId.
        /// </summary>
        public Guid BookingId { get; private set; }

        /// <summary>
        /// Gets Paymentype.
        /// </summary>
        public Paymentype Paymentype { get; private set; }

        /// <summary>
        /// Gets PaidOnUtc.
        /// </summary>
        public DateTime PaidOnUtc { get; private set; }

        /// <summary>
        /// Gets or sets ppp.
        /// </summary>
        public virtual Booking Booking { get; set; }

        /// <summary>
        /// Create an instance of payment.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <param name="paymentType">paymentType.</param>
        /// <param name="utcNow">utcNow.</param>
        /// <returns>An instance of payment.</returns>
        public static Payment Create(
            Guid bookingId,
            Paymentype paymentType,
            DateTime utcNow)
        {
            var payment = new Payment(
                Guid.NewGuid(),
                bookingId,
                paymentType,
                utcNow);

            return payment;
        }
    }
}
