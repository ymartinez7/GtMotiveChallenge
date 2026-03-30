using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Data.Repositories
{
    public class BookingRepository(AppDbContext dbContext,
        IAppLogger<BaseRepository<Booking>> logger)
        : BaseRepository<Booking>(dbContext, logger), IBookingRepository
    {
        public async Task<bool> HasUserAnActiveBookingAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            return await Context.Set<Booking>().AnyAsync(r => r.UserId == userId && (r.Status == BookingStatus.Pending || r.Status == BookingStatus.Confirmed), cancellationToken);
        }
    }
}
