using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// UserActiveBookingException.
    /// </summary>
    public sealed class UserHasActiveBookingException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserHasActiveBookingException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public UserHasActiveBookingException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHasActiveBookingException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="innerException">innerException.</param>
        public UserHasActiveBookingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHasActiveBookingException"/> class.
        /// </summary>
        public UserHasActiveBookingException()
        {
        }
    }
}
