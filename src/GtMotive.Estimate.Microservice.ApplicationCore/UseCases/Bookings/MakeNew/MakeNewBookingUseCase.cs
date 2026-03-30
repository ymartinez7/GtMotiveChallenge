using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Bookings.MakeNew
{
    /// <summary>
    /// MakeNewBookingUseCase.
    /// </summary>
    /// <param name="logger">logger.</param>
    /// <param name="outputPort">outputPort.</param>
    /// <param name="bookingService">bookingService.</param>
    /// <param name="unitOfWork">unitOfWork.</param>
    public class MakeNewBookingUseCase(
        IAppLogger<MakeNewBookingUseCase> logger,
        IMakeNewBookingOutputPort outputPort,
        IBookingService bookingService,
        IUnitOfWork unitOfWork) : IMakeNewBookingUseCase
    {
        private readonly IAppLogger<MakeNewBookingUseCase> _logger = logger;
        private readonly IMakeNewBookingOutputPort _outputPort = outputPort;
        private readonly IBookingService _bookingService = bookingService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">input.</param>
        /// <returns>aaa.</returns>
        public async Task Execute(MakeNewBookingInput input)
        {
            ArgumentNullException.ThrowIfNull(input);
            _logger.LogInformation("Executing MakeNewBookingUseCase");

            try
            {
                var booking = await _bookingService.MakeNewAsync(
                    input.UserId,
                    input.VehicleId,
                    input.StartDate,
                    input.EndDate);

                await _unitOfWork.Save();

                _logger.LogInformation("Booking {BookingId} created", booking.Id.ToString());

                BuildOutput(booking);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {message}", ex.Message);
                _outputPort.NotFoundHandle(ex.Message);
            }
            catch (VehicleNotFoundException ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {message}", ex.Message);
                _outputPort.NotFoundHandle(ex.Message);
            }
            catch (BookingDateRangeException ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {message}", ex.Message);
                _outputPort.BadRequestHandle(ex.Message);
            }
            catch (UserHasActiveBookingException ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {message}", ex.Message);
                _outputPort.BadRequestHandle(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has ocurred. Message {message}", ex.Message);
                throw;
            }
        }

        private void BuildOutput(Booking booking)
        {
            var output = new MakeNewBookingOutput(
                booking.Id,
                booking.UserId,
                booking.VehicleId,
                booking.Duration.StartDate,
                booking.Duration.EndDate,
                booking.TotalPrice.Amount,
                booking.Status.ToString());

            _outputPort.StandardHandle(output);
        }
    }
}
