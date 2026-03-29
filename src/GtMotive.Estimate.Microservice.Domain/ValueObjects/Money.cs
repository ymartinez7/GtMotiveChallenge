using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Money value object.
    /// </summary>
    /// <param name="Amount">aaa.</param>
    /// <param name="Currency">ppp.</param>
    public sealed record Money(
        decimal Amount,
        Currency Currency)
    {
        /// <summary>
        /// Sum operator.
        /// </summary>
        /// <param name="first">first.</param>
        /// <param name="second">second.</param>
        /// <returns>Money.</returns>
        /// <exception cref="InvalidOperationException">exception.</exception>
        public static Money operator +(Money first, Money second)
        {
            ArgumentNullException.ThrowIfNull(first);
            ArgumentNullException.ThrowIfNull(second);

            return first.Currency != second.Currency
                ? throw new InvalidCurrencyException("Currencies have to be equal")
                : new Money(first.Amount + second.Amount, first.Currency);
        }

        /// <summary>
        /// Method to initialize money.
        /// </summary>
        /// <returns>Money.</returns>
        public static Money Zero() => new(0, Currency.None);

        /// <summary>
        /// Method to initialize money.
        /// </summary>
        /// <param name="currency">efef.</param>
        /// <returns>tryyt.</returns>
        public static Money Zero(Currency currency) => new(0, currency);

        /// <summary>
        /// Method for condition.
        /// </summary>
        /// <returns>boolean.</returns>
        public bool IsZero() => this == Zero(Currency);
    }
}
