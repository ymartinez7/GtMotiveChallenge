using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// InvalidCurrencyException.
    /// </summary>
    public sealed class InvalidCurrencyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public InvalidCurrencyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="innerException">innerException.</param>
        public InvalidCurrencyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyException"/> class.
        /// </summary>
        public InvalidCurrencyException()
        {
        }
    }
}
