using System;
using System.Globalization;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.GetDetails
{
    /// <summary>
    /// GetBookingDetailsUseCase.
    /// </summary>
    /// <param name="logger">logger.</param>
    /// <param name="bookingService">bookingService.</param>
    /// <param name="outputPort">outputPort.</param>
    /// <param name="cacheService">cacheService.</param>
    public class GetBookingDetailsUseCase(
        IAppLogger<GetBookingDetailsUseCase> logger,
        IBookingService bookingService,
        IGetBookingDetailsOutputPort outputPort,
        ICache cacheService) : IGetBookingDetailsUseCase
    {
        private readonly IAppLogger<GetBookingDetailsUseCase> _logger = logger;
        private readonly IBookingService _bookingService = bookingService;
        private readonly IGetBookingDetailsOutputPort _outputPort = outputPort;
        private readonly ICache _cacheService = cacheService;
        private readonly string _cacheKeyTemplate = "bookings:booking-{0}";

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>ae.</returns>
        public async Task Execute(GetBookingDetailsInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            _logger.LogInformation("Executing GetBookingDetailsUseCase with BookingId {BookingId}", input.Id.ToString());

            try
            {
                var cacheKey = string.Format(CultureInfo.InvariantCulture, _cacheKeyTemplate, input.Id);
                var cachedBooking = await _cacheService.GetAsync<GetBookingDetailsOutput>(cacheKey);

                if (cachedBooking is not null)
                {
                    _outputPort.StandardHandle(cachedBooking);
                    return;
                }

                var booking = await _bookingService.GetDetailsAsync(input.Id);

                if (booking is null)
                {
                    _outputPort.NotFoundHandle($"BookingId {input.Id} not found");
                    return;
                }

                await BuildOutput(booking, cacheKey);
            }
            catch (BookingNotFoundException ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {ex.Message}", ex.Message);
                _outputPort.NotFoundHandle(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {ex.Message}", ex.Message);
                throw;
            }
        }

        private async Task BuildOutput(Booking booking, string cacheKey)
        {
            var output = new GetBookingDetailsOutput(
                booking.Id,
                booking.VehicleId,
                booking.UserId,
                booking.Duration.StartDate,
                booking.Duration.EndDate,
                booking.TotalPrice.Amount,
                booking.Status);

            await _cacheService.SetAsync(cacheKey, output, TimeSpan.FromMinutes(2));
            _outputPort.StandardHandle(output);
        }
    }
}
