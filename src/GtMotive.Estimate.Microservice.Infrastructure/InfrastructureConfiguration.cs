using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Data.Context;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Logging;
using GtMotive.Estimate.Microservice.Infrastructure.Telemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        [ExcludeFromCodeCoverage]
        public static IInfrastructureBuilder AddBaseInfrastructure(
            this IServiceCollection services,
            bool isDevelopment)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            if (!isDevelopment)
            {
                services.AddScoped<ITelemetry, AppTelemetry>();
            }
            else
            {
                services.AddScoped<ITelemetry, NoOpTelemetry>();
            }

            return new InfrastructureBuilder(services);
        }

        /// <summary>
        /// AddPersistence.
        /// </summary>
        /// <param name="services">services.</param>
        /// <param name="configuration">configuration.</param>
        /// <exception cref="ArgumentNullException">ruutr.</exception>
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        private sealed class InfrastructureBuilder(IServiceCollection services) : IInfrastructureBuilder
        {
            public IServiceCollection Services { get; } = services;
        }
    }
}
