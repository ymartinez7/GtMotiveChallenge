using System;
using Microsoft.Extensions.Caching.Distributed;

namespace GtMotive.Estimate.Microservice.Infrastructure.Caching
{
    public static class RedisCacheOptions
    {
        public static DistributedCacheEntryOptions DefaultCacheOptions => new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public static DistributedCacheEntryOptions Create(TimeSpan? expiration) =>
            expiration is not null ?
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration.Value
            }
            : DefaultCacheOptions;
    }
}
