using System;
using System.Globalization;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.Pay
{
    /// <summary>
    /// PayBookingUseCase.
    /// </summary>
    public class PayBookingUseCase(
        IAppLogger<PayBookingUseCase> logger,
        IPayBookingOutputPort outputPort,
        IBookingService bookingService,
        IUnitOfWork unitOfWork,
        ICache cacheService) : IPayBookingUseCase
    {
        private readonly IAppLogger<PayBookingUseCase> _logger = logger;
        private readonly IPayBookingOutputPort _outputPort = outputPort;
        private readonly IBookingService _bookingService = bookingService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICache _cacheService = cacheService;
        private readonly string _cacheKeyTemplate = "bookings:booking-{0}";

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>sdpl.</returns>
        public async Task Execute(PayBookingInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            _logger.LogInformation("Executing PayBookingUseCase with BookingId {BookingId}", input.Id.ToString());

            try
            {
                var booking = await _bookingService.PayAsync(
                    input.Id,
                    input.PaymentDetails.Paymentype);

                await _unitOfWork.Save();

                // Invalide cache
                var cacheKey = string.Format(CultureInfo.InvariantCulture, _cacheKeyTemplate, input.Id);
                await _cacheService.RemoveAsync(cacheKey);

                _logger.LogInformation("Booking {BookingId} paid", booking.Id.ToString());

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
            var output = new PayBookingOutput("Booking Paid sucessfully!");
            _outputPort.StandardHandle(output);
        }
    }
}
