using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Services
{
    /// <summary>
    /// Booking Service interface.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// GetDetailsAsync.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <returns>Booking.</returns>
        Task<Booking> GetDetailsAsync(Guid bookingId);

        /// <summary>
        /// MakeNewAsync.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="startDate">startDate.</param>
        /// <param name="endDate">endDate.</param>
        /// <returns>Booking.</returns>
        Task<Booking> MakeNewAsync(
            Guid userId,
            Guid vehicleId,
            DateOnly startDate,
            DateOnly endDate);

        /// <summary>
        /// PayAsync.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <param name="paymentype">paymentype.</param>
        /// <returns>Task.</returns>
        Task<Booking> PayAsync(
            Guid bookingId,
            string paymentype);

        /// <summary>
        /// CancelAsync.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <returns>Task.</returns>
        Task<Booking> CancelAsync(Guid bookingId);

        /// <summary>
        /// /FinishAsync.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <returns>Task.</returns>
        Task<Booking> FinishAsync(Guid bookingId);
    }
}
