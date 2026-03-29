using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// VehileModelYearNotValidException.
    /// </summary>
    public sealed class VehileModelYearNotValidException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehileModelYearNotValidException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public VehileModelYearNotValidException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehileModelYearNotValidException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="innerException">innerException.</param>
        public VehileModelYearNotValidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehileModelYearNotValidException"/> class.
        /// </summary>
        public VehileModelYearNotValidException()
        {
        }
    }
}
