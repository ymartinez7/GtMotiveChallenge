using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Booking repository interface.
    /// </summary>
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        /// <summary>
        /// Evaluate if user has an active booking.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Boolean.</returns>
        Task<bool> HasUserAnActiveBookingAsync(
            Guid userId,
            CancellationToken cancellationToken = default);
    }
}
