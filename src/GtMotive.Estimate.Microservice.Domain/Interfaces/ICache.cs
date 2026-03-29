using System;
using System.Threading;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Cache interface.
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Getan item.
        /// </summary>
        /// <typeparam name="T">Class.</typeparam>
        /// <param name="key">key.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>An item.</returns>
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set an item.
        /// </summary>
        /// <typeparam name="T">Class.</typeparam>
        /// <param name="key">key.</param>
        /// <param name="value">value.</param>
        /// <param name="expiration">expiration.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Task.</returns>
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove an item.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Task.</returns>
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    }
}
