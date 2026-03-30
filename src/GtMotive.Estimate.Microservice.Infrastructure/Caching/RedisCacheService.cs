using System;
using System.Buffers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace GtMotive.Estimate.Microservice.Infrastructure.Caching
{
    /// <summary>
    /// RedisCacheService.
    /// </summary>
    /// <param name="cache">cache.</param>
    public sealed class RedisCacheService(IDistributedCache cache) : ICache
    {
        private readonly IDistributedCache _cache = cache;

        /// <summary>
        /// GetAsync.
        /// </summary>
        /// <typeparam name="T">Class.</typeparam>
        /// <param name="key">key.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Item.</returns>
        public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            var bytes = await _cache.GetAsync(key, cancellationToken);
            return bytes is null ? default : Deserialize<T>(bytes);
        }

        /// <summary>
        /// SetAsync.
        /// </summary>
        /// <typeparam name="T">Class.</typeparam>
        /// <param name="key">key.</param>
        /// <param name="value">value.</param>
        /// <param name="expiration">expiration.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Task.</returns>
        public Task SetAsync<T>(
            string key,
            T value,
            TimeSpan? expiration = null,
            CancellationToken cancellationToken = default)
        {
            var bytes = Serialize(value);
            return _cache.SetAsync(key, bytes, RedisCacheOptions.Create(expiration), cancellationToken);
        }

        /// <summary>
        /// RemoveAsync.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Task.</returns>
        public Task RemoveAsync(string key, CancellationToken cancellationToken = default) =>
            _cache.RemoveAsync(key, cancellationToken);

        private static T Deserialize<T>(byte[] bytes)
        {
            return JsonSerializer.Deserialize<T>(bytes)!;
        }

        private static byte[] Serialize<T>(T value)
        {
            var buffer = new ArrayBufferWriter<byte>();

            using var writer = new Utf8JsonWriter(buffer);

            JsonSerializer.Serialize(writer, value);

            return buffer.WrittenSpan.ToArray();
        }
    }
}
