using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Events;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Services;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// BookingService.
    /// </summary>
    public class BookingService(
        IAppLogger<BookingService> logger,
        IBookingRepository bookingRepository,
        IUserRepository userRepository,
        IVehicleRepository vehicleRepository,
        IPaymentRepository paymentRepository) : IBookingService
    {
        private readonly IAppLogger<BookingService> _logger = logger;
        private readonly IBookingRepository _bookingRepository = bookingRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IPaymentRepository _paymentRepository = paymentRepository;

        /// <summary>
        /// Gets a booking.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <returns>A Booking.</returns>
        /// <exception cref="BookingNotFoundException">BookingNotFoundException.</exception>
        public async Task<Booking> GetDetailsAsync(Guid bookingId)
        {
            _logger.LogInformation("Gettings booking detailf of BookingId {BookingId}", bookingId);

            var booking = await _bookingRepository.GetByIdAsync(bookingId);

            return booking is null ? throw new BookingNotFoundException("Booking not found") : booking;
        }

        /// <summary>
        /// Generate a new booking.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="startDate">startDate.</param>
        /// <param name="endDate">endDate.</param>
        /// <returns>A Booking.</returns>
        /// <exception cref="UserNotFoundException">UserNotFoundException.</exception>
        /// <exception cref="VehicleNotFoundException">VehicleNotFoundException.</exception>
        /// <exception cref="UserHasActiveBookingException">UserActiveBookingException.</exception>
        public async Task<Booking> MakeNewAsync(
            Guid userId,
            Guid vehicleId,
            DateOnly startDate,
            DateOnly endDate)
        {
            _logger.LogInformation("Generating new booking");

            var user = await _userRepository.GetByIdAsync(userId)
                    ?? throw new UserNotFoundException($"User not exists");

            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId)
                ?? throw new VehicleNotFoundException($"Vehicle not exists");

            var duration = new DateRange(startDate, endDate);

            var hasUserAnActiveBooking = await _bookingRepository.HasUserAnActiveBookingAsync(user.Id);

            if (hasUserAnActiveBooking)
            {
                throw new UserHasActiveBookingException("User already has an active booking");
            }

            var booking = Booking.Reserve(
                vehicle,
                user.Id,
                duration,
                DateTime.UtcNow);

            await _bookingRepository.AddAsync(booking);

            // Raise a domain event when a booking is created
            EventsRegister.BookingCreated.Publish(new BookingCreatedDomainEvent(booking.Id));

            return booking;
        }

        /// <summary>
        /// Pay a booking.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <param name="paymentype">paymentype.</param>
        /// <returns>Task.</returns>
        /// <exception cref="BookingNotFoundException">BookingNotFoundException.</exception>
        public async Task<Booking> PayAsync(
            Guid bookingId,
            string paymentype)
        {
            _logger.LogInformation("Pay Booking {BookingId}", bookingId);

            var booking = await _bookingRepository.GetByIdAsync(bookingId)
                ?? throw new BookingNotFoundException("Booking not found");

            var payment = booking.Pay(
                Enum.Parse<Paymentype>(paymentype),
                DateTime.UtcNow);

            _bookingRepository.Update(booking);
            await _paymentRepository.AddAsync(payment);

            // Raise a domain event when a booking is paid
            EventsRegister.BookingConfirmed.Publish(new BookingConfirmedDomainEvent(booking.Id));

            return booking;
        }

        /// <summary>
        /// Cancel a booking.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <returns>Task.</returns>
        /// <exception cref="BookingNotFoundException">BookingNotFoundException.</exception>
        public async Task<Booking> CancelAsync(Guid bookingId)
        {
            _logger.LogInformation("Cancel Booking {BookingId}", bookingId);

            var booking = await _bookingRepository.GetByIdAsync(bookingId)
                ?? throw new BookingNotFoundException("Booking not found");

            booking.Cancel(DateTime.UtcNow);

            _bookingRepository.Update(booking);

            // Raise a domain event when a booking is cancelled
            EventsRegister.BookingCanceled.Publish(new BookingCanceledDomainEvent(booking.Id));

            return booking;
        }

        /// <summary>
        /// Finish a booking.
        /// </summary>
        /// <param name="bookingId">bookingId.</param>
        /// <returns>Task.</returns>
        /// <exception cref="BookingNotFoundException">BookingNotFoundException.</exception>
        public async Task<Booking> FinishAsync(Guid bookingId)
        {
            _logger.LogInformation("Finish booking {BookingId}", bookingId);

            var booking = await _bookingRepository.GetByIdAsync(bookingId)
                ?? throw new BookingNotFoundException("Booking not found");

            booking.Finish(DateTime.UtcNow);

            _bookingRepository.Update(booking);

            // Raise a domain event when a booking is finished
            EventsRegister.BookingFinished.Publish(new BookingFinishedDomainEvent(booking.Id));

            return booking;
        }
    }
}
