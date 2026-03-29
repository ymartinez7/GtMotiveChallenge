using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// BookingNotFoundException.
    /// </summary>
    public sealed class BookingNotFoundException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingNotFoundException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public BookingNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingNotFoundException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="innerException">innerException.</param>
        public BookingNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingNotFoundException"/> class.
        /// </summary>
        public BookingNotFoundException()
        {
        }
    }
}
