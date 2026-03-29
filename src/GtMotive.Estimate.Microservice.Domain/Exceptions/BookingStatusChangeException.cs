using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// BookingStatusChangeException.
    /// </summary>
    public sealed class BookingStatusChangeException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingStatusChangeException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public BookingStatusChangeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingStatusChangeException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="innerException">innerException.</param>
        public BookingStatusChangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingStatusChangeException"/> class.
        /// </summary>
        public BookingStatusChangeException()
        {
        }
    }
}
