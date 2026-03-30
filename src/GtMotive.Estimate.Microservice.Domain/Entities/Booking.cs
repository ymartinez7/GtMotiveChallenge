using System;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Booking entity.
    /// </summary>
    public class Booking : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        private Booking()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="vehicleId">vehicleId.</param>
        /// <param name="userId">userId.</param>
        /// <param name="duration">duration.</param>
        /// <param name="priceForPeriod">priceForPeriod.</param>
        /// <param name="totalPrice">totalPrice.</param>
        /// <param name="bookingStatus">bookingStatus.</param>
        /// <param name="createdOnUtc">createdOnUtc.</param>
        private Booking(
            Guid id,
            Guid vehicleId,
            Guid userId,
            DateRange duration,
            Money priceForPeriod,
            Money totalPrice,
            BookingStatus bookingStatus,
            DateTime createdOnUtc)
            : base(id)
        {
            VehicleId = vehicleId;
            UserId = userId;
            Duration = duration;
            PriceForPeriod = priceForPeriod;
            TotalPrice = totalPrice;
            Status = bookingStatus;
            CreatedOnUtc = createdOnUtc;
        }

        /// <summary>
        /// Gets VehicleId.
        /// </summary>
        public Guid VehicleId { get; private set; }

        /// <summary>
        /// Gets UserId.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Gets Duration.
        /// </summary>
        public DateRange Duration { get; private set; }

        /// <summary>
        /// Gets PriceForPeriod.
        /// </summary>
        public Money PriceForPeriod { get; private set; }

        /// <summary>
        /// Gets TotalPrice.
        /// </summary>
        public Money TotalPrice { get; private set; }

        /// <summary>
        /// Gets Status.
        /// </summary>
        public BookingStatus Status { get; private set; }

        /// <summary>
        /// Gets CreatedOnUtc.
        /// </summary>
        public DateTime CreatedOnUtc { get; private set; }

        /// <summary>
        /// Gets ConfirmeddOnUtc.
        /// </summary>
        public DateTime? ConfirmeddOnUtc { get; private set; }

        /// <summary>
        /// Gets FinishedOnUtc.
        /// </summary>
        public DateTime? FinishedOnUtc { get; private set; }

        /// <summary>
        /// Gets CanceledOnUtc.
        /// </summary>
        public DateTime? CanceledOnUtc { get; private set; }

        /// <summary>
        /// Gets or sets User.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets Vehicle.
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets or sets Payments.
        /// </summary>
        public virtual Payment Payment { get; set; }

        /// <summary>
        /// Create an instance of Booking.
        /// </summary>
        /// <param name="vehicle">vehicle.</param>
        /// <param name="userId">userId.</param>
        /// <param name="duration">duration.</param>
        /// <param name="utcNow">utcNow.</param>
        /// <returns>An instance of Booking.</returns>
        public static Booking Reserve(
            Vehicle vehicle,
            Guid userId,
            DateRange duration,
            DateTime utcNow)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            ArgumentNullException.ThrowIfNull(duration);

            var pricingDetail = CalculatePrice(vehicle, duration);

            var booking = new Booking(
                Guid.NewGuid(),
                vehicle.Id,
                userId,
                duration,
                pricingDetail?.PriceByPeriod,
                pricingDetail?.TotalPrice,
                BookingStatus.Pending,
                utcNow);

            vehicle.LastBookedOnUtc = utcNow;

            return booking;
        }

        /// <summary>
        /// Pay a booking.
        /// </summary>
        /// <param name="paymentType">paymentType.</param>
        /// <param name="utcNow">utcNow.</param>
        /// <returns>An instance of payment.</returns>
        /// <exception cref="BookingStatusChangeException">exception.</exception>
        public Payment Pay(
            Paymentype paymentType,
            DateTime utcNow)
        {
            if (Status != BookingStatus.Pending)
            {
                throw new BookingStatusChangeException("Booking can not be finished, because is not Confirmed");
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.StartDate)
            {
                throw new BookingStatusChangeException("Booking already started");
            }

            var payment = Payment.Create(
                Id,
                paymentType,
                DateTime.UtcNow);

            Status = BookingStatus.Confirmed;
            ConfirmeddOnUtc = utcNow;

            return payment;
        }

        /// <summary>
        /// Cancel a booking.
        /// </summary>
        /// <param name="utcNow">utcNow.</param>
        public void Cancel(DateTime utcNow)
        {
            if (Status is not BookingStatus.Pending and not BookingStatus.Confirmed)
            {
                throw new BookingStatusChangeException("Booking can not be canceled, because is not Pending or Confirmed status");
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.StartDate)
            {
                throw new BookingStatusChangeException("Booking already started");
            }

            Status = BookingStatus.Cancelled;
            CanceledOnUtc = utcNow;
        }

        /// <summary>
        /// Finish a booking.
        /// </summary>
        /// <param name="utcNow">utcNow.</param>
        /// <exception cref="UserHasActiveBookingException">exception.</exception>
        public void Finish(DateTime utcNow)
        {
            if (Status != BookingStatus.Confirmed)
            {
                throw new BookingStatusChangeException("Booking can not be finished, because is not Confirmed");
            }

            Status = BookingStatus.Finished;
            FinishedOnUtc = utcNow;
        }

        /// <summary>
        /// CalculatePrice.
        /// </summary>
        /// <param name="vehicle">vehicle.</param>
        /// <param name="period">period.</param>
        /// <returns>PricingDetail.</returns>
        private static PricingDetail CalculatePrice(Vehicle vehicle, DateRange period)
        {
            var currency = vehicle.Price.Currency;

            var priceByPeriod = new Money(
                vehicle.Price.Amount * period.LengthInDays,
                currency);

            var totalPrice = Money.Zero(currency);
            totalPrice += priceByPeriod;

            return new PricingDetail(
                priceByPeriod,
                totalPrice);
        }
    }
}
