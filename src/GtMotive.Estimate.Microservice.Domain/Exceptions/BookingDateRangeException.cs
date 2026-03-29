using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// BookingDateRangeException.
    /// </summary>
    public sealed class BookingDateRangeException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingDateRangeException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public BookingDateRangeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingDateRangeException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="innerException">innerException.</param>
        public BookingDateRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingDateRangeException"/> class.
        /// </summary>
        public BookingDateRangeException()
        {
        }
    }
}
