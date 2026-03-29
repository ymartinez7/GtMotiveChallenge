using System.Collections.Generic;
using System.Linq;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Currency value object.
    /// </summary>
    public sealed record Currency
    {
        /// <summary>
        /// None.
        /// </summary>
        internal static readonly Currency None = new(string.Empty);

        /// <summary>
        /// Dollar.
        /// </summary>
        public static readonly Currency USD = new("USD");

        /// <summary>
        /// Euro.
        /// </summary>
        public static readonly Currency EUR = new("EUR");

        /// <summary>
        /// Pounds.
        /// </summary>
        public static readonly Currency GBP = new("GBP");

        /// <summary>
        /// Collection of currencies.
        /// </summary>
        public static readonly IReadOnlyCollection<Currency> All =
        [
            None,
            USD,
            EUR,
            GBP
        ];

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="code">code.</param>
        private Currency(string code)
        {
            Code = code;
        }

        /// <summary>
        /// Gets Code.
        /// </summary>
        public string Code { get; init; }

        /// <summary>
        /// Currency resolver.
        /// </summary>
        /// <param name="code">code.</param>
        /// <returns>A Currency.</returns>
        /// <exception cref="DomainException">exception.</exception>
        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ??
                throw new DomainException("The currency code is invalid");
        }
    }
}
