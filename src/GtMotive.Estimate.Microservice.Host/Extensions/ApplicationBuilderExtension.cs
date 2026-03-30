using GtMotive.Estimate.Microservice.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Host.Extensions
{
    /// <summary>
    /// ApplicationBuilderExtension.
    /// </summary>
    internal static class ApplicationBuilderExtension
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
