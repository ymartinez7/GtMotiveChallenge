using System;
using System.Globalization;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Cancel
{
    /// <summary>
    /// CancelBookingUseCase.
    /// </summary>
    /// <param name="logger">logger.</param>
    /// <param name="outputPort">outputPort.</param>
    /// <param name="bookingService">bookingService.</param>
    /// <param name="unitOfWork">unitOfWork.</param>
    /// <param name="cacheService">cacheService.</param>
    public class CancelBookingUseCase(
        IAppLogger<CancelBookingUseCase> logger,
        ICancelBookingOutputPort outputPort,
        IBookingService bookingService,
        IUnitOfWork unitOfWork,
        ICache cacheService) : ICancelBookingUseCase
    {
        private readonly IAppLogger<CancelBookingUseCase> _logger = logger;
        private readonly ICancelBookingOutputPort _outputPort = outputPort;
        private readonly IBookingService _bookingService = bookingService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICache _cacheService = cacheService;
        private readonly string _cacheKeyTemplate = "bookings:booking-{0}";

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">aaa.</param>
        /// <returns>aa.</returns>
        public async Task Execute(CancelBookingInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            _logger.LogInformation("Executing CancelBookingUseCase to BookingId {BookingId}", input.Id.ToString());

            try
            {
                var booking = await _bookingService.CancelAsync(input.Id);
                await _unitOfWork.Save();

                // Invalide cache
                var cacheKey = string.Format(CultureInfo.InvariantCulture, _cacheKeyTemplate, input.Id);
                await _cacheService.RemoveAsync(cacheKey);

                _logger.LogInformation("Booking {BookingId} cancelled", booking.Id.ToString());

                BuildOutput();
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

        private void BuildOutput()
        {
            var output = new CancelBookingOutput("Booking cancelled ok!");
            _outputPort.StandardHandle(output);
        }
    }
}
